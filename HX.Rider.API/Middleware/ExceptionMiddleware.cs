using HX.Rider.Exception;
using HX.Rider.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HX.Rider.API.Middleware
{
    /// <summary>
    /// 异常处理中间件
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        /// <summary>
        /// InvokeAsync
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (HXException ex)
            {
                logger.LogError(ex, "业务异常");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
            catch (System.Exception ex)
            {
                logger.LogError(ex, "系统异常");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, System.Exception ex)
        {
            ApiResult apiResult = ApiResult.FailedResult(ApiResultCode.SERIVCEERROR,"系统异常");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(apiResult));
        }
    }
}
