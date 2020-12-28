using Newtonsoft.Json;
using System;

namespace HX.Rider.Model
{
    /// <summary>
    /// API返回值数据传输对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> : ApiResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("data")]
        public virtual T Data { get; set; }
    }
}
