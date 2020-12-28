using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API
{
    /// <summary>
    /// 微信登录Request Model
    /// </summary>
    public class WxLoginRequest
    {
        /// <summary>
        /// 微信OpenId
        /// </summary>
        [Required]
        public string OpenId { get; set; }

        /// <summary>
        /// 微信联合Id，用于关联其他OpenId
        /// </summary>
        [Required]
        public string UnionId { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 所在省分
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; set; }
    }
}
