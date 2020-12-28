using HX.Rider.Common;
using HX.Rider.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class SqlSuguarExtensions
    {
        /// <summary>
        /// SqlSugar服务注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddSqlSugar(this IServiceCollection services, IConfiguration config, ServiceLifetime lifetime = ServiceLifetime.Singleton)
        {
            //services.AddOptions();
            services.Configure<SqlSugarOptions>(config.GetSection(SqlSugarOptions.SqlSugar));
            services.Add(ServiceDescriptor.Singleton<ISugarDbContext, SugarDbContext>());
            return services;
        }
    }
}
