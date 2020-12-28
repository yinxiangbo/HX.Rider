using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// Api返回结果
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// 成功结果
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">成功信息</param>
        /// <returns>Result</returns>
        public static ApiResult<T> SuccessResult<T>(T data, string message = "")
        {
            var result = new ApiResult<T>();
            result.Code = ApiResultCode.SUCCESS;
            result.Success = true;
            result.Message = message;
            result.Data = data;
            return result;
        }
        /// <summary>
        /// 失败结果
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="errorCode">错误编码</param>
        /// <param name="message">错误信息</param>
        /// <returns>Result</returns>
        public static ApiResult<T> FailedResult<T>(T data, int errorCode, string message = "")
        {
            var result = new ApiResult<T>();
            result.Code = errorCode;
            result.Success = false;
            result.Message = message;
            result.Data = data;
            return result;
        }
        /// <summary>
        /// 失败结果
        /// </summary>
        /// <param name="errorCode">错误编码</param>
        /// <param name="message">错误信息</param>
        /// <returns>Result</returns>
        public static ApiResult<T> FailedResult<T>(int errorCode, string message = "")
        {
            var result = new ApiResult<T>();
            result.Code = errorCode;
            result.Success = false;
            result.Message = message;
            return result;
        }

        /// <summary>
        /// 失败结果
        /// </summary>
        /// <param name="errorCode">错误编码</param>
        /// <param name="message">错误信息</param>
        /// <returns></returns>
        public static ApiResult<string> FailedResult(int errorCode, string message = "")
        {
            return FailedResult<string>(errorCode, message);
        }
    }
}
