using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HX.Rider.API
{
    /// <summary>
    /// LoginResult
    /// </summary>
    public class LoginResult
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("originalUserName")]
        public string OriginalUserName { get; set; }
        /// <summary>
        /// AccessToken
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        /// <summary>
        /// RefreshToken
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
