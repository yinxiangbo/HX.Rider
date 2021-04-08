using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// SqlSugarOptions
    /// </summary>
    public class SqlSugarOptions
    {
        /// <summary>
        /// SqlSugar
        /// </summary>
        public const string DbName = "CommonSqlOptions";

        /// <summary>
        /// SQL连接字符创
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 是否
        /// </summary>
        public bool OutPutSql { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public int DbType { get; set; }
    }
}
