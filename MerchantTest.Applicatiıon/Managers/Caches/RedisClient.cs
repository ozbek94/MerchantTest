using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace MerchantTest.Applicatiıon.Managers.Caches
{
    public class RedisClient
    {
        public RedisCache RedisCache { get; private set; }

        public RedisClient()
        {
            var redisOptions = new RedisCacheOptions
            {
                ConfigurationOptions = new ConfigurationOptions
                {
                    EndPoints = { { "merchanttest.cache", 6379 } },
                    //Password = "" 
                }
            };

            var opts = Options.Create(redisOptions);
            RedisCache = new Microsoft.Extensions.Caching.StackExchangeRedis.RedisCache(opts);
        }
    }
}