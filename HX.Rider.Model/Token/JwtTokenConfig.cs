using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HX.Rider.Model
{
    /// <summary>
    /// JwtTokenConfig
    /// </summary>
    public class JwtTokenConfig
    {
        /// <summary>
        /// Secret
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        /// <summary>
        /// Issuer
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// Audience
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// AccessTokenExpiration
        /// </summary>
        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// RefreshTokenExpiration
        /// </summary>
        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
}
