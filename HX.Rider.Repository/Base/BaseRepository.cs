using HX.Rider.Common;
using HX.Rider.Entity;
using HX.Rider.IRepository;
using HX.Rider.Model;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HX.Rider.Repository.Base
{
    /// <summary>
    /// 基础Repository
    /// </summary>

    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly string dbName;
        private readonly ISugarDbContext db;
        public BaseRepository(ISugarDbContext db, string dbName= SqlSugarOptions.DbName)
        {
            this.db = db;
            this.dbName = dbName;
        }

        protected ISqlSugarClient dbContext => db.GetDbContext(dbName);
        #region 暂时去掉
        #region 根据主键获取实体对象
        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetById(dynamic id)
        {
            return await dbContext.Queryable<TEntity>().InSingleAsync(id);
        }
        #endregion
        #region 根据Linq表达式条件获取单个实体对象

        /// <summary>
        /// 根据条件获取单个实体对象
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="whereExp"></param>
        /// <returns></returns>
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> whereExp)
        {
            return await dbContext.Queryable<TEntity>().Where(whereExp).SingleAsync();
        }
        #endregion

        #region 获取所有实体列表

        /// <summary>
        /// 获取所有实体列表
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetList()
        {
            return await dbContext.Queryable<TEntity>().ToListAsync();
        }
        #endregion

        #region 根据Linq表达式条件获取列表

        /// <summary>
        /// 根据条件获取实体列表
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> whereExp)
        {
            return await dbContext.Queryable<TEntity>().Where(whereExp).ToListAsync();
        }
        #endregion

        #region 根据Sugar条件获取列表

        /// <summary>
        /// 根据条件获取实体列表
        /// </summary>

        /// <param name="db"></param>
        /// <param name="conditionals">Sugar调价表达式集合</param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetList(List<IConditionalModel> conditionals)
        {
            return await dbContext.Queryable<TEntity>().Where(conditionals).ToListAsync();
        }
        #endregion

        #region 是否包含某个元素
        /// <summary>
        /// 是否包含某个元素
        /// </summary>
        /// <param name="db"></param>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public async Task<bool> Exist(Expression<Func<TEntity, bool>> whereExp)
        {
            return await dbContext.Queryable<TEntity>().Where(whereExp).AnyAsync();
        }
        #endregion

        #region 新增实体对象
        /// <summary>
        /// 新增实体对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public async Task<bool> Insert(TEntity insertObj)
        {
            return await dbContext.Insertable(insertObj).ExecuteCommandAsync() > 0;
        }
        #endregion

        #region 批量新增实体对象
        /// <summary>
        /// 批量新增实体对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public async Task<bool> InsertRange(List<TEntity> insertObjs)
        {
            return await dbContext.Insertable(insertObjs).ExecuteCommandAsync() > 0;
        }
        #endregion
        #region 更新单个实体对象
        /// <summary>
        /// 更新单个实体对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity updateObj)
        {
            return await dbContext.Updateable(updateObj).ExecuteCommandAsync() > 0;
        }
        #endregion

        #region 根据条件批量更新实体指定列
        /// <summary>
        /// 根据条件批量更新实体指定列
        /// </summary>

        /// <param name="db"></param>
        /// <param name="columns">需要更新的列</param>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public async Task<bool> Update(Expression<Func<TEntity, TEntity>> columns, Expression<Func<TEntity, bool>> whereExp)
        {
            return await dbContext.Updateable<TEntity>().SetColumns(columns).Where(whereExp).ExecuteCommandAsync() > 0;
        }
        #endregion

        #region 物理删除实体对象

        /// <summary>
        /// 物理删除实体对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        public async Task<bool> Delete(TEntity deleteObj)
        {
            return await dbContext.Deleteable<TEntity>().Where(deleteObj).ExecuteCommandAsync() > 0;
        }

        /// <summary>
        /// 物理删除实体对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public async Task<bool> Delete(Expression<Func<TEntity, bool>> whereExp)
        {
            return await dbContext.Deleteable<TEntity>().Where(whereExp).ExecuteCommandAsync() > 0;
        }

        /// <summary>
        /// 根据主键物理删除实体对象
        /// </summary>

        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteById(dynamic id)
        {
            return await dbContext.Deleteable<TEntity>().In(id).ExecuteCommandAsync() > 0;
        }

        /// <summary>
        /// 根据主键批量物理删除实体集合
        /// </summary>

        /// <param name="db"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByIds(dynamic[] ids)
        {
            return await dbContext.Deleteable<TEntity>().In(ids).ExecuteCommandAsync() > 0;
        }

        #endregion

        #region 分页查询

        /// <summary>
        /// 获取分页列表【页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<PagedList<TEntity>> GetPageList(int pageIndex, int pageSize)
        {
            RefAsync<int> count = 0;
            var result =await dbContext.Queryable<TEntity>().ToPageListAsync(pageIndex, pageSize,count);
            return new PagedList<TEntity>(result, pageIndex, pageSize, count);
        }



        #endregion

        #region 分页查询（排序）

        /// <summary>
        /// 获取分页列表【排序，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="orderExp">排序表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<PagedList<TEntity>> GetPageList(Expression<Func<TEntity, object>> orderExp, OrderByType orderType, int pageIndex, int pageSize)
        {
            RefAsync<int> count = 0;
            var result = await dbContext.Queryable<TEntity>().OrderBy(orderExp, orderType).ToPageListAsync(pageIndex, pageSize, count);
            return new PagedList<TEntity>(result, pageIndex, pageSize, count);
        }



        #endregion

        #region 分页查询（Linq表达式条件）

        /// <summary>
        /// 获取分页列表【Linq表达式条件，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="whereExp">Linq表达式条件</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<PagedList<TEntity>> GetPageList(Expression<Func<TEntity, bool>> whereExp, int pageIndex, int pageSize)
        {
            RefAsync<int> count = 0;
            var result = await dbContext.Queryable<TEntity>().Where(whereExp).ToPageListAsync(pageIndex, pageSize,count);
            return new PagedList<TEntity>(result, pageIndex, pageSize, count);
        }


        #endregion

        #region 分页查询（Linq表达式条件，排序）

        /// <summary>
        /// 获取分页列表【Linq表达式条件，排序，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="whereExp">Linq表达式条件</param>
        /// <param name="orderExp">排序表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<PagedList<TEntity>> GetPageList(Expression<Func<TEntity, bool>> whereExp, Expression<Func<TEntity, object>> orderExp, OrderByType orderType, int pageIndex, int pageSize)
        {
            RefAsync<int> count = 0;
            var result =await dbContext.Queryable<TEntity>().Where(whereExp).OrderBy(orderExp, orderType).ToPageListAsync(pageIndex, pageSize, count);
            return new PagedList<TEntity>(result, pageIndex, pageSize, count);
        }


        #endregion

        #region 分页查询（Sugar条件）

        /// <summary>
        /// 获取分页列表【Sugar表达式条件，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="db"></param>
        /// <param name="conditionals">Sugar条件表达式集合</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<PagedList<TEntity>> GetPageList(List<IConditionalModel> conditionals, int pageIndex, int pageSize)
        {
            RefAsync<int> count = 0;
            var result =await dbContext.Queryable<TEntity>().Where(conditionals).ToPageListAsync(pageIndex, pageSize, count);
            return new PagedList<TEntity>(result, pageIndex, pageSize, count);
        }


        #endregion

        #region 分页查询（Sugar条件，排序）

        /// <summary>
        ///  获取分页列表【Sugar表达式条件，排序，页码，每页条数】
        /// </summary>
        /// <param name="db"></param>
        /// <param name="conditionals">Sugar条件表达式集合</param>
        /// <param name="orderExp">排序表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public async Task<PagedList<TEntity>> GetPageList(List<IConditionalModel> conditionals, Expression<Func<TEntity, object>> orderExp, OrderByType orderType, int pageIndex, int pageSize)
        {
            RefAsync<int> count = 0;
            var result =await dbContext.Queryable<TEntity>().Where(conditionals).OrderBy(orderExp, orderType).ToPageListAsync(pageIndex, pageSize, count);
            return new PagedList<TEntity>(result, pageIndex, pageSize, count);
        }

        #endregion 
        #endregion

    }
}
