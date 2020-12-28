using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HX.Rider.Model
{
    /// <summary>
    /// RefreshToken Model
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }    // can be used for usage tracking
        // can optionally include other metadata, such as user agent, ip address, device name, and so on

        /// <summary>
        /// Token
        /// </summary>
        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
}
