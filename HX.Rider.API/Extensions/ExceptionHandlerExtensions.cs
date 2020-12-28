using HX.Rider.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public static class AppExceptionHandlerExtensions
    {
        /// <summary>
        /// 管道中间件扩展
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
