using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sistema.Infra.Redis.Constants;
using Sistema.Infra.Redis.Repositorios;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Infra.Redis.Extensions
{
    public static class RedisDiExtensions
    {
        public static IServiceCollection AddRedisRepository(this IServiceCollection services, IConfiguration config, string environmentName)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetConnectionString("Redis");
                options.InstanceName = CacheKeys.PrefixWithEnvironment(environmentName);
            });

            services
                .AddSingleton(sp =>
                {
                    return ConnectionMultiplexer.Connect(config.GetConnectionString("Redis"));
                });

            services.AddTransient<ICacheRepository, RedisCacheRepository>();

            return services;
        }
    }
}
