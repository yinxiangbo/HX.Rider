using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        
        [JsonProperty("userId")]
        public long Id { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Required]
        [JsonProperty("idNumber")]
        public string IDNumber { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [JsonProperty("realname")]
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

       
        /// <summary>
        /// 手机号
        /// </summary>
        [JsonProperty("mobilephone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
