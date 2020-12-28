using HX.Rider.Common;
using HX.Rider.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// ServiceStackReids服务扩展
    /// </summary>
    public static class RedisServiceExtensions
    {
        /// <summary>
        /// 依赖注入，redis服务注入容器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddRedisCache(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddOptions();
            services.Add(ServiceDescriptor.Singleton<IRedisCacheService, RedisCacheService>());
            return services;
        }
        /// <summary>
        /// 依赖注入，redis服务注入容器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration config)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            services.AddRedisCache();
            services.Configure<RedisOptions>(config.GetSection(RedisOptions.Redis));
            return services;
        }
        /// <summary>
        /// 依赖注入，redis服务注入容器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddRedisCache(this IServiceCollection services, Action<RedisOptions> setupAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (setupAction == null)
                throw new ArgumentNullException(nameof(setupAction));
            services.AddRedisCache();
            services.Configure(setupAction);
            return services;
        }
    }
}
