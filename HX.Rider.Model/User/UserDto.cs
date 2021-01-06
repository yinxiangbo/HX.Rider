using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 添加用户的Model
    /// </summary>
    public class UserDto : UserModel
    {
        /// <summary>
        /// 密码
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
