using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// JwtToken配置项
    /// </summary>
    public class JwtTokenOptions
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public const string JwtToken = "JwtTokenOptions";
        /// <summary>
        /// Issuer
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// AccessToken过期时间（当前时间+AccessTokenExpiration）
        /// </summary>
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// RefreshToken过期时间（当前时间+RefreshTokenExpiration）
        /// </summary>
        public int RefreshTokenExpiration { get; set; }
    }
}
