using Autofac;
using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.Application.Domain.API;
using IFS.DB.EF;
using IFS.DB.Infrastructure.Repo;
using IFS.DB.Infrastructure.Repo.Cache;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IFS.DB.OpenAPI
{
    public partial class Startup
    {
        public IConfiguration _Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // XmlConfigurationProvider
            IConfigurationRoot xmlConfigurationProvider = new ConfigurationBuilder()
                .AddXmlFile("ConnectionStrings.config", optional: false, reloadOnChange: true)
                .Build();
            string digitalBankingConnectionStrValue = xmlConfigurationProvider["add:DigitalBanking:connectionString"];

            //Setting connection string
            services.AddDbContext<DigitalBankingDBContext>(options => options.UseSqlServer(digitalBankingConnectionStrValue));

            // Register and share across the application
            services.AddSingleton<IConfiguration>(xmlConfigurationProvider);

            //Setting Jwt Config
            IConfigurationSection jwtConfigSection = _Configuration.GetSection("Jwt");
            services.Configure<JwtConfig>(jwtConfigSection);

            //Setting Entity Framework
            //services.AddEntityFrameworkSqlServer();

            //Setting HttpContext
            services.AddHttpContextAccessor();

            //Setting MVC
            services.AddMvc();

            //Setting Redis Cache
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = _Configuration.GetSection("RedisURL").Value;
            });

            //Setting Cors
            services.AddCors(o => o.AddPolicy("DigitalBankingOpenAPI", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            //Setting Authentication
            JwtConfig jwtConfig = jwtConfigSection.Get<JwtConfig>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidAudience = jwtConfig.Audience,
                        ValidIssuer = jwtConfig.Issuer,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddSwaggerDocument(c => SetupOpenApi(c));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Config Forwarded Header to get Client IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //Config Mapster
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            //Config JSon
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter>
                {
                    // [EnumMember(Value = "Some enum value")]
                    new StringEnumConverter()
                }
            };

            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Return static files and end the pipeline.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("DigitalBankingOpenAPI");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler(builder => SetExceptionError(builder, env.IsDevelopment()));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated OpenApi specs as a JSON endpoint.
            UseOpenApi3WithSwaggerUi(app);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Register your own things directly with Autofac here
            containerBuilder.RegisterAssemblyTypes(Assembly.Load("IFS.DB.Application"), Assembly.Load("IFS.DB.Infrastructure"))
                .AsImplementedInterfaces();

            //Register decorate
            containerBuilder.RegisterType<APIErrorResourceRepo>().As<IAPIErrorResourceRepo>().AsSelf();
            containerBuilder.RegisterDecorator<CacheAPIErrorResourceRepo, IAPIErrorResourceRepo>();
            
        }
    }
}
