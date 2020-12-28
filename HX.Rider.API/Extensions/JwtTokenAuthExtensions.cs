using HX.Rider.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// JwtToken认证服务注入扩展
    /// </summary>
    public static class JwtTokenAuthExtensions
    {
        /// <summary>
        /// JwtToken认证服务注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddJwtTokenAuth(this IServiceCollection services,IConfiguration config)
        {
            if(services==null)
                throw new ArgumentNullException(nameof(services));

            var tokenOptions = config.GetSection(JwtTokenOptions.JwtToken).Get<JwtTokenOptions>();
            //读取配置文件
            var keyByteArray = Encoding.ASCII.GetBytes(tokenOptions.SecretKey);
            var signingKey = new SymmetricSecurityKey(keyByteArray);
            var issur = tokenOptions.Issuer;
            var audience = tokenOptions.Audience;
            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = issur,//发行人
                ValidateAudience = true,
                ValidAudience = audience,//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(30)
            };
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = tokenValidationParameters;
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // 如果过期，则把<是否过期>添加到，返回头信息中
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
