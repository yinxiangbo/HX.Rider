using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 返回结果基类
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 错误编码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; } = -1;
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; } = false;
        /// <summary>
        /// 消息提示
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// 服务器响应时间
        /// </summary>
        [JsonProperty("timestamp")]
        public string ResponseTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 成功结果
        /// </summary>
        /// <param name="message">成功信息</param>
        /// <returns>Result</returns>
        public static ApiResult SuccessResult(string message = "")
        {
            var result = new ApiResult();
            result.Code = ApiResultCode.SUCCESS;
            result.Success = true;
            result.Message = message;
            return result;
        }


        /// <summary>
        /// 失败结果
        /// </summary>
        /// <param name="errorCode">错误编码</param>
        /// <param name="message">错误信息</param>
        /// <returns>Result</returns>
        public static ApiResult FailedResult(int errorCode, string message = "")
        {
            var result = new ApiResult();
            result.Code = errorCode;
            result.Success = false;
            result.Message = message;
            return result;
        }

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
        /// <param name="data">数据</param>
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

    }
}
