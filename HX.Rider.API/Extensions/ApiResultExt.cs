using HX.Rider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Extensions
{
    /// <summary>
    /// ApiResult扩展，简化Controller中返回结果的调用
    /// </summary>
    public class ApiResultExt
    {
        
        /// <summary>
        /// 失败结果
        /// </summary>
        /// <param name="code">失败编码</param>
        /// <param name="errMsg">失败信息</param>
        /// <returns></returns>
        public static ApiResult<string> FailedResult(int code, string errMsg="")
        {
            return ApiResult<string>.FailedResult(code, errMsg);
        }
    }
}
