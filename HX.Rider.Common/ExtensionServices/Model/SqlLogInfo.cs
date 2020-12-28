using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Common
{
    public class SqlLogInfo
    {
        /// <summary>
        /// Sql语句
        /// </summary>
        public string Sql { get; set; }
        /// <summary>
        /// 执行耗时
        /// </summary>
        public string SqlExecutionTime { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string SqlExecutionParams { get; set; }
        public override string ToString()
        {
            return $"SQL语句:{Sql},  耗时:{SqlExecutionTime}, 参数：{SqlExecutionParams}";
        }
    }
}
