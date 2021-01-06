using HX.Rider.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HX.Rider.IService
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 校验用户名和密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<UserModel> IsValidUserCredentials(string userName,string password);
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        Task<bool> CreateUser(UserDto user);

        Task<List<UserModel>> GetUserList();

        //Task<bool> UpdateLoginTime();
    }
}
