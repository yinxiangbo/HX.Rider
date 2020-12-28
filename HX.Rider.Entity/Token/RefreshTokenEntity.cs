using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Entity
{
    /// <summary>
    /// RefreshTokenEntity
    /// </summary>
    [SugarTable("Rider_RefreshToken")]
    public class RefreshTokenEntity : EntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)] //是主键, 还是标识列
        public int Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// RefreshToken凭证
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime ExpireAt { get; set; }
    }
}
