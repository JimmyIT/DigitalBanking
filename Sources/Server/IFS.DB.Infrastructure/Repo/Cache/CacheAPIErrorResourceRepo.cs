using IFS.DB.Application.Common.Interfaces.Repo;
using IFS.DB.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Infrastructure.Repo.Cache
{
    public class CacheAPIErrorResourceRepo : BaseRepo, IAPIErrorResourceRepo
    {
        private readonly IDistributedCache _RedisCache;
        private readonly IAPIErrorResourceRepo _APIErrorResourceRepo;
        private readonly ILogger<CacheAPIErrorResourceRepo> _Logger;

        private string _CachePrefix = "api-error";
        private int _ExpiryTime = 30;

        public CacheAPIErrorResourceRepo(DigitalBankingDBContext dBContext,
            IDistributedCache redisCache,
            IAPIErrorResourceRepo apiErrorResourceRepo,
            ILogger<CacheAPIErrorResourceRepo> logger)
            : base(dBContext)
        {
            _RedisCache = redisCache;
            _APIErrorResourceRepo = apiErrorResourceRepo;
            _Logger = logger;
        }

        #region Queries
        public async Task<ApiErrorResource> GetByKeyAsync(string key)
        {
            string cacheKey = $"{_CachePrefix}-{key}";

            ApiErrorResource result = null;
            //Get from Redis Cache
            try
            {
                var redisResource = await _RedisCache.GetAsync(cacheKey);

                if (redisResource != null)
                    return JsonConvert.DeserializeObject<ApiErrorResource>(Encoding.UTF8.GetString(redisResource));

                //Read from DB
                result = await _APIErrorResourceRepo.GetByKeyAsync(key);

                //Set Redis Cache
                redisResource = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result));
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_ExpiryTime))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(_ExpiryTime));

                await _RedisCache.SetAsync(cacheKey, redisResource, options);
            }
            catch (Exception ex)
            {
                //Write Log
                _Logger.LogError(ex.ToString());

                //Read from DB
                result = await _APIErrorResourceRepo.GetByKeyAsync(key);
            }

            return result;
        }
        #endregion
    }
}
