using HX.Rider.IService;
using HX.Rider.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HX.Rider.Service
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class AccountService : IAccountService
    {

        private readonly ILogger<AccountService> logger;

        /// <summary>
        /// CheckUserNameAndPwd
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserInfo> IsValidUserCredentials(string userName, string password)
        {
            return new UserInfo() { UserId=123,UserName= "admin" };
        }


    }
}
