using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// SwaggerService扩展
    /// </summary>
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));
            var ApiName = "HX.Rider.API";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档——Netcore 3.1",
                    Description = $"{ApiName} HTTP API V1",


                });

                c.OrderActionsBy(o => o.RelativePath);
                // 获取xml注释文件的目录
                var xmlPath = Path.Combine(AppContext.BaseDirectory, "HX.Rider.API.xml");
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "HX.Rider.Model.xml");//这个就是Model层的xml文件名
                c.IncludeXmlComments(xmlModelPath, true);
                // 在header中添加token，传递到后台
                //c.OperationFilter<SecurityRequirementsOperationFilter>();

                #region Token绑定到ConfigureServices
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Token无需添加Bearer \"",
                    Name = "JWT Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
                #endregion
            });

        }
    }
}
