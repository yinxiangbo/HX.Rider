using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [JsonProperty("userId")]
        public long UserId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
