using HX.Rider.Entity;
using HX.Rider.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HX.Rider.IRepository
{
    public interface ITokenRepository
    {
        /// <summary>
        /// 添加或者更新，如果存在更新，否则插入
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddOrUpdate(RefreshTokenEntity entity);
        /// <summary>
        /// 根据Token获取RefreshToken
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<RefreshTokenEntity> GetByToken(string token);
        /// <summary>
        /// 根据用户Id移除RefreshToken
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> RemoveByUserId(long userId);
        /// <summary>
        /// 根据用户姓名移除RefreshToken
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> RemoveByUserName(string userName);
        /// <summary>
        /// 根据过期日期获取RefreshToken
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Task<List<RefreshTokenEntity>> GetByExpireAt(DateTime dateTime);

    }
}
