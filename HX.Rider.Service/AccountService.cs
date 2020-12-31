using HX.Rider.IService;
using HX.Rider.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HX.Rider.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class AccountService : IAccountService
    {

        /// <summary>
        /// CheckUserNameAndPwd
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserInfo> IsValidUserCredentials(string userName, string password)
        {
            if (userName == "admin" && password == "123")
            {
                return new UserInfo() { UserId = 123, UserName = "admin" };
            }
            return null;
        }

        public async Task<List<UserInfo>> GetUserList()
        {
            var userList = new List<UserInfo>();
            userList.Add(new UserInfo() { UserId = 123, UserName = "admin" });
            userList.Add(new UserInfo() { UserId = 234, UserName = "用户1" });
            userList.Add(new UserInfo() { UserId = 345, UserName = "用户2" });
            userList.Add(new UserInfo() { UserId = 456, UserName = "用户3" });
            userList.Add(new UserInfo() { UserId = 567, UserName = "用户4" });
            return userList;
        }

    }
}
