using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Exception
{
    /// <summary>
    /// 异常级别
    /// </summary>
    public enum HXExceptionLevel
    {
        /// <summary>
        /// 可识别补货的异常
        /// </summary>
        Warning,
        /// <summary>
        /// 未知异常
        /// </summary>
        Error,
    }
}
