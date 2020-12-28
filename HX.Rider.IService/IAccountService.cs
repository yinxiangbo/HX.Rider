using HX.Rider.Model;
using System;
using System.Threading.Tasks;

namespace HX.Rider.IService
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 校验用户名和密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<UserInfo> IsValidUserCredentials(string userName,string password);

    }
}
