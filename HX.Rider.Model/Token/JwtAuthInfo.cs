using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HX.Rider.Model
{
    /// <summary>
    /// JWT认证信息
    /// </summary>
    public class JwtAuthInfo
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// RefreshToken
        /// </summary>
        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
