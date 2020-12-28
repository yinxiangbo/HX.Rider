using HX.Rider.Common;
using HX.Rider.Entity;
using HX.Rider.Exception;
using HX.Rider.IRepository;
using HX.Rider.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HX.Rider.Repository
{
    /// <summary>
    /// Token数据仓储
    /// </summary>
    public class TokenRepository: BaseRepository<RefreshTokenEntity>, ITokenRepository
    {
        public TokenRepository(ISugarDbContext context):
            base(context)
        {}
        /// <summary>
        /// 添加或者更新，如果存在更新，否则插入
        /// </summary>
        /// <param name="entity">Token实体</param>
        /// <returns></returns>
        public async Task<bool> AddOrUpdate(RefreshTokenEntity entity)
        {
            if (entity == null)
                throw new HXException("10001", "参数错误",HXExceptionLevel.Warning);
            var refreshToken=await GetById(entity.Id);
            if (refreshToken == null)
                return await Insert(entity);
            return await Update(entity);
        }
        /// <summary>
        /// 根据Token获取RefreshToken
        /// </summary>
        /// <param name="token">refreshToken</param>
        /// <returns></returns>
        public async Task<RefreshTokenEntity> GetByToken(string token)
        {
            return await Get(t => t.Token == token);
        }
        /// <summary>
        /// 移除refreshToken
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<bool> RemoveByUserId(long userId)
        {
            return await Delete(t => t.UserId == userId);
        }
        /// <summary>
        /// 根据用户名移除RefreshToken
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> RemoveByUserName(string userName)
        {
            return await Delete(t => t.UserName == userName);
        }
        /// <summary>
        /// 根据过期日期获取RefreshToken
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<List<RefreshTokenEntity>> GetByExpireAt(DateTime dateTime)
        {
            return await GetList(t => t.ExpireAt<dateTime);
        }
    }
}
