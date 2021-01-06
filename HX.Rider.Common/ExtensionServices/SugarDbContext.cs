using HX.Rider.Entity;
using HX.Rider.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HX.Rider.Common
{
    /// <summary>
    /// SugarDbContext
    /// </summary>
    public class SugarDbContext : ISugarDbContext
    {
        #region 构造器，ConnectionConfig DI
        private readonly ILogger<SugarDbContext> logger;
        private readonly SqlSugarOptions options;
        public SugarDbContext(IOptions<SqlSugarOptions> optionsAccessor, ILogger<SugarDbContext> logger)
        {
            this.options = optionsAccessor.Value;
            this.logger = logger;
        }
        /// <summary>
        /// 获取数据库执行Client
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public SqlSugarClient GetDbContext(DbType dbType = DbType.MySql)
        {
            var dbContext = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = options.ConnectionString,
                DbType = dbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
                IsShardSameThread = true
            });
            if (options.OutPutSql)
            {
                dbContext.Aop.OnLogExecuted = (sql, pars) =>
                {
                    logger.LogInformation(new SqlLogInfo()
                    {
                        Sql = sql,
                        SqlExecutionTime = dbContext.Ado.SqlExecutionTime.ToString(),
                        SqlExecutionParams = string.Join(",", pars?.Select(it => it.ParameterName + ":" + it.Value))
                    }.ToString());
                };
            }
            return dbContext;
        }
        #endregion
    }
}
