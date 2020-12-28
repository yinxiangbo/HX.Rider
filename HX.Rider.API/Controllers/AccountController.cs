using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HX.Rider.IService;
using HX.Rider.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HX.Rider.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace HX.Rider.API.Controllers
{
    /// <summary>
    /// 骑手身份认证控制器
    /// </summary>
    public class AccountController : BaseController
    {
        #region 构造器注入Service
        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly IAccountService accountService;
        private readonly ITokenService tokenService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accountService">用户服务</param>
        /// <param name="tokenService">用户服务</param>
        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            this.accountService = accountService;
            this.tokenService = tokenService;
        }
        #endregion
        /// <summary>
        /// 登录，获取认证的(JWT)Token
        /// </summary>
        /// <param name="request">用户名&密码</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResult<LoginResult>> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return ApiResult.FailedResult<LoginResult>(ApiResultCode.ARGSERROR, "用户名或密码不能为空！");
            var credentialInfo = await accountService.IsValidUserCredentials(request.UserName, request.Password);
            if (credentialInfo == null || string.IsNullOrEmpty(credentialInfo.UserName))
                return ApiResult.FailedResult<LoginResult>(ApiResultCode.PERMISSIONDENIED, "用户名或密码错误！");
            var userId = credentialInfo.UserId;
            var jwtToken = await tokenService.GenerateTokens(userId, request.UserName, DateTime.Now);
            return ApiResult.SuccessResult(new LoginResult()
            {
                UserName = request.UserName,
                AccessToken = jwtToken.AccessToken,
                RefreshToken = jwtToken.RefreshToken.TokenString
            });
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> Logout()
        {
            await tokenService.RemoveRefreshTokenByUserName(User.Identity.Name);
            return ApiResult.SuccessResult();
        }
        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="refreshToken">refreshToken</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<LoginResult>> RefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return ApiResult.FailedResult<LoginResult>(ApiResultCode.ARGSERROR, "refreshToken不能为空！");
            var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
            var refreshResult =await tokenService.Refresh(refreshToken, accessToken, DateTime.Now);
            return ApiResult.SuccessResult(new LoginResult() {
                UserName = User.Identity.Name,
                AccessToken = refreshResult?.AccessToken,
                RefreshToken = refreshResult?.RefreshToken?.TokenString
            });
        }
        //public async Task<ApiResult<LoginResult>> WeChatLogin([FromBody] WxLoginRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return ApiResult.FailedResult<LoginResult>(ApiResultCode.ARGSERROR, "OpenId或者UnionId不能为空！");
        //    return null;
        //}
    }
}