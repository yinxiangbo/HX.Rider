using HX.Rider.Common;
using HX.Rider.Entity;
using HX.Rider.Exception;
using HX.Rider.IRepository;
using HX.Rider.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(ISugarDbContext context) :
            base(context)
        { }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        /// <returns></returns>
        public async Task<bool> AddUser(UserEntity entity)
        {
            return await Insert(entity);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId">user实体</param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(UserEntity entity)
        {
            return await Delete(entity);
        }
        /// <summary>
        /// 根据用户Id删除用户
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(long userId)
        {
            var user=await GetById(userId);
            if (user == null)
                throw new HXException(HXExceptionCode.USER_NOT_EXISTS,HXExceptionLevel.Warning);
            return await Delete(user);
        }
        /// <summary>
        /// 根据用户Id获取用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserEntity> GetUser(long userId)
        {
            return await GetById(userId);
        }
        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<UserEntity> GetUser(string userName)
        {
            return await Get(x => x.UserName == userName);
        }

        public Task<List<UserEntity>> GetUsers()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<bool> UpdateUser(UserEntity entity)
        {
            return Update(entity);
        }
    }
}
