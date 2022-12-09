using IFS.DB.Application.Domain.Attributes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IFS.DB.OpenAPI
{
    public partial class Startup
    {
        private void SetupOpenApi(AspNetCoreOpenApiDocumentGeneratorSettings setting)
        {
            setting.Title = "IFS Digital Banking OpenAPI";
            setting.Version = "1.0.0";
            setting.DocumentName = "v1.0.0";
            setting.Description = "OpenAPI for IFS Digital Banking Open API";

            //Add Required Header
            setting.OperationProcessors.Add(new RequiredHeaderParameter());

            //Add Authorization
            setting.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
            setting.AddSecurity("JWT Token", new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                Description = "Copy 'Bearer ' + valid JWT token into field",
                In = OpenApiSecurityApiKeyLocation.Header
            });
        }

        private void UseOpenApi3WithSwaggerUi(IApplicationBuilder app)
        {
            string path = "/docs/{documentName}/digital-banking-openapi.json";

            app.UseOpenApi(c =>
            {
                c.Path = path; //write
            });
            app.UseSwaggerUi3(c =>
            {
                c.DocExpansion = "list";
                c.DocumentPath = path; //read
                c.TagsSorter = "alpha";
            });
        }

        private class RequiredHeaderParameter : IOperationProcessor
        {
            public bool Process(OperationProcessorContext context)
            {
                IEnumerable<ParameterInfo> parameters = context.MethodInfo.GetParameters()
                    .Where(x => x.CustomAttributes.Any(y => y.AttributeType.IsSubclassOf(typeof(APIFromHeaderAttribute))));

                foreach (ParameterInfo pi in parameters)
                {
                    APIFromHeaderAttribute attribute = pi.GetCustomAttribute<APIFromHeaderAttribute>();

                    if (attribute != null)
                    {
                        OpenApiParameter param = context.OperationDescription.Operation.Parameters
                            .FirstOrDefault(x => x.Name == attribute.Name);

                        param.IsRequired = attribute.Required;
                    }
                }

                return true;
            }
        }
    }
}
