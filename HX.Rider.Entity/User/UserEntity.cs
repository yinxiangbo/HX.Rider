using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    [SugarTable("Rider_User")]
    public class UserEntity:EntityBase
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 密码盐
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 身份照号
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 真是姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 微信openId
        /// </summary>
        public string WxOpenId { get; set; }
    }
}
