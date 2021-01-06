using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HX.Rider.API
{
    /// <summary>
    /// 注册request
    /// </summary>
    public class RegisterRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="密码不能为空")]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required(ErrorMessage = "手机号不能为空")]
        [RegularExpression(@"^1[3|4|5|7|8][0-9]\d{8}$", ErrorMessage = "手机号格式错误")]
        [JsonPropertyName("mobilephone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 真是姓名
        /// </summary>
        [JsonPropertyName("realName")]
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonPropertyName("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required(ErrorMessage = "身份证号不能为空")]
        [JsonPropertyName("idNumber")]
        public string IDNumber { get; set; }
    }
}
