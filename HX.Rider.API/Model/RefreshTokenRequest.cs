using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HX.Rider.API
{
    /// <summary>
    /// RefreshToken请求Model
    /// </summary>
    public class RefreshTokenRequest
    {
        /// <summary>
        /// AccessToken
        /// </summary>
        [Required]
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        /// <summary>
        /// RefreshToken
        /// </summary>
        [Required]
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
