using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal=1,
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted=2,
        /// <summary>
        /// 禁用失效
        /// </summary>
        Disable=3,
        /// <summary>
        /// 锁定
        /// </summary>
        Lock=4
    }
}
