using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// 返回结果编码
    /// </summary>
    public class ApiResultCode
    {
        /// <summary>
        /// 未知
        /// </summary>
        public const int UNKOWN = 1000;

        /// <summary>
        /// 成功
        /// </summary>
        public const int SUCCESS = 2000;

        /// <summary>
        /// 参数错误
        /// </summary>
        public const int ARGSERROR = 3000;
        /// <summary>
        /// 服务错误
        /// </summary>
        public const int SERIVCEERROR = 5000;

        /// <summary>
        /// 认证错误
        /// </summary>
        public const int PERMISSIONDENIED = 4001;
    }
}
