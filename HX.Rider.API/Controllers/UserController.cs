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
using System.IdentityModel.Tokens.Jwt;
using HX.Rider.Extensions;

namespace HX.Rider.API.Controllers
{
    /// <summary>
    /// 骑手身份认证控制器
    /// </summary>
    public class UserController : BaseController
    {
        #region 构造器注入Service
        /// <summary>
        /// 用户服务
        /// </summary>
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userService">用户服务</param>
        /// <param name="tokenService">用户服务</param>
        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
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
            var credentialInfo = await userService.IsValidUserCredentials(request.UserName, request.Password);
            if (credentialInfo == null || string.IsNullOrEmpty(credentialInfo.UserName))
                return ApiResult.FailedResult<LoginResult>(ApiResultCode.PERMISSIONDENIED, "用户名或密码错误！");
            var userId = credentialInfo.Id;
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
        /// <param name="request">请求实体</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResult<LoginResult>> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
                return ApiResult.FailedResult<LoginResult>(ApiResultCode.ARGSERROR, "refreshToken不能为空！");
            var refreshResult =await tokenService.Refresh(request.RefreshToken, request.AccessToken, DateTime.Now);
            return ApiResult.SuccessResult(new LoginResult() {
                UserName = User.Identity.Name,
                AccessToken = refreshResult?.AccessToken,
                RefreshToken = refreshResult?.RefreshToken?.TokenString
            });
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResult<bool>> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return ApiResult.FailedResult<bool>(ApiResultCode.ARGSERROR, ModelState.GetStateError());
            var user = new UserDto()
            {
                UserName = request.UserName.Trim(),
                IDNumber = request.IDNumber.Trim(),
                RealName = request.RealName?.Trim(),
                NickName = request.NickName?.Trim(),
                Avatar = request.Avatar?.Trim(),
                Email = request.Email?.Trim(),
                MobilePhone = request.MobilePhone.Trim(),
                Password = request.Password.Trim()
            };
            var result = await userService.CreateUser(user);
            return ApiResult.SuccessResult(result);
        }
        //[HttpPost]
        //public async Task<ApiResult<bool>> ChangePassword()
        //{
            
        //}
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<UserModel>>> GetUserList()
        {
            var userList= await userService.GetUserList();
            return ApiResult.SuccessResult(userList);
        }
    }
}