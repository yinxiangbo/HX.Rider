using HX.Rider.IRepository;
using HX.Rider.IService;
using HX.Rider.Model;
using HX.Rider.Repository;
using HX.Rider.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// RiderServiceExtensions
    /// </summary>
    public static class RiderServiceExtensions
    {
        /// <summary>
        /// 注入骑手服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddRiderServices(this IServiceCollection services, IConfiguration config)
        {
            //Options DI
            services.Configure<JwtTokenOptions>(config.GetSection(
                                       JwtTokenOptions.JwtToken));
            services.AddSingleton<ITokenRepository, TokenRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            //Service DI
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITokenService, TokenService>();
            return services;
        }
    }
}
