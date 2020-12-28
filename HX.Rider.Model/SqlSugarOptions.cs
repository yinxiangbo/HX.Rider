using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Model
{
    /// <summary>
    /// SqlSugarOptions
    /// </summary>
    public class SqlSugarOptions : IOptions<SqlSugarOptions>
    {
        public const string SqlSugar = "SqlSugarOptions";

        /// <summary>
        /// SQL连接字符创
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 是否
        /// </summary>
        public bool OutPutSql { get; set; }


        SqlSugarOptions IOptions<SqlSugarOptions>.Value => this;
    }
}
