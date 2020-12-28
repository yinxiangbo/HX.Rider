using HX.Rider.Entity;
using HX.Rider.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.IRepository
{
    /// <summary>
    /// 基类接口,其他接口继承该接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        #region 根据主键获取实体对象
        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <typeparam name="T">数据源类型</typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity> GetById(dynamic id);
        #endregion
        #region 根据Linq表达式条件获取单个实体对象

        /// <summary>
        /// 根据条件获取单个实体对象
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="whereExp"></param>
        /// <returns></returns>
        public Task<TEntity> Get(Expression<Func<TEntity, bool>> whereExp);
        #endregion

        #region 获取所有实体列表
        /// <summary>
        /// 获取所有实体列表
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <returns></returns>
        public Task<List<TEntity>> GetList();
        #endregion
        #region 根据Linq表达式条件获取列表
        /// <summary>
        /// 根据条件获取实体列表
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> whereExp);
        #endregion

        #region 根据Sugar条件获取列表

        /// <summary>
        /// 根据条件获取实体列表
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="conditionals">Sugar调价表达式集合</param>
        /// <returns></returns>
        public Task<List<TEntity>> GetList(List<IConditionalModel> conditionals);
        #endregion

        #region 是否包含某个元素
        /// <summary>
        /// 是否包含某个元素
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public Task<bool> Exist(Expression<Func<TEntity, bool>> whereExp);
        #endregion

        #region 新增实体对象
        /// <summary>
        /// 新增实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="insertObj"></param>
        /// <returns></returns>
        public Task<bool> Insert(TEntity insertObj);
        #endregion

        #region 批量新增实体对象
        /// <summary>
        /// 批量新增实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="insertObjs"></param>
        /// <returns></returns>
        public Task<bool> InsertRange(List<TEntity> insertObjs);
        #endregion
        #region 更新单个实体对象
        /// <summary>
        /// 更新单个实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="updateObj"></param>
        /// <returns></returns>
        public Task<bool> Update(TEntity updateObj);
        #endregion

        #region 根据条件批量更新实体指定列
        /// <summary>
        /// 根据条件批量更新实体指定列
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="columns">需要更新的列</param>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public Task<bool> Update(Expression<Func<TEntity, TEntity>> columns, Expression<Func<TEntity, bool>> whereExp);
        #endregion

        #region 物理删除实体对象
        /// <summary>
        /// 物理删除实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        public Task<bool> Delete(TEntity deleteObj);
        /// <summary>
        /// 物理删除实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereExp">条件表达式</param>
        /// <returns></returns>
        public Task<bool> Delete(Expression<Func<TEntity, bool>> whereExp);
        /// <summary>
        /// 根据主键物理删除实体对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteById(dynamic id);
        /// <summary>
        /// 根据主键批量物理删除实体集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<bool> DeleteByIds(dynamic[] ids);
        #endregion

        #region 分页查询
        /// <summary>
        /// 获取分页列表【页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public Task<PagedList<TEntity>> GetPageList(int pageIndex, int pageSize);
        #endregion

        #region 分页查询（排序）
        /// <summary>
        /// 获取分页列表【排序，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="orderExp">排序表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public Task<PagedList<TEntity>> GetPageList(Expression<Func<TEntity, object>> orderExp, OrderByType orderType, int pageIndex, int pageSize);
        #endregion

        #region 分页查询（Linq表达式条件）
        /// <summary>
        /// 获取分页列表【Linq表达式条件，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="whereExp">Linq表达式条件</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public Task<PagedList<TEntity>> GetPageList(Expression<Func<TEntity, bool>> whereExp, int pageIndex, int pageSize);
        #endregion

        #region 分页查询（Linq表达式条件，排序）

        /// <summary>
        /// 获取分页列表【Linq表达式条件，排序，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="whereExp">Linq表达式条件</param>
        /// <param name="orderExp">排序表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public Task<PagedList<TEntity>> GetPageList(Expression<Func<TEntity, bool>> whereExp, Expression<Func<TEntity, object>> orderExp, OrderByType orderType, int pageIndex, int pageSize);
        #endregion

        #region 分页查询（Sugar条件）
        /// <summary>
        /// 获取分页列表【Sugar表达式条件，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity">数据源类型</typeparam>
        /// <param name="conditionals">Sugar条件表达式集合</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public Task<PagedList<TEntity>> GetPageList(List<IConditionalModel> conditionals, int pageIndex, int pageSize);
        #endregion

        #region 分页查询（Sugar条件，排序）
        /// <summary>
        ///  获取分页列表【Sugar表达式条件，排序，页码，每页条数】
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="conditionals">Sugar条件表达式集合</param>
        /// <param name="orderExp">排序表达式</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public Task<PagedList<TEntity>> GetPageList(List<IConditionalModel> conditionals, Expression<Func<TEntity, object>> orderExp, OrderByType orderType, int pageIndex, int pageSize);
        #endregion
    }
}
