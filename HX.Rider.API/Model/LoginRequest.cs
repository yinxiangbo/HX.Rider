using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HX.Rider.API
{
    /// <summary>
    /// 认证请求信息
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
