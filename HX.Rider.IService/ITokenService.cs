using HX.Rider.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.IService
{
    public interface ITokenService
    {
        //IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
        /// <summary>
        /// 生成Token,包括AccessToken与RefreshToken
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名称</param>
        /// <param name="claims">自定义的信息</param>
        /// <param name="jwtTokenConfig">jwtTokenConfig</param>
        /// <param name="dateTime"></param>
        /// <returns>JwtAuthInfo</returns>
        Task<JwtAuthInfo> GenerateTokens(long userId,string userName, Claim[] claims, DateTime dateTime);
        /// <summary>
        /// 生成Token,包括AccessToken与RefreshToken
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="jwtTokenConfig"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        Task<JwtAuthInfo> GenerateTokens(long userId, string userName, DateTime dateTime);
        /// <summary>
        /// 刷新Token,包括AccessToken与RefreshToken
        /// </summary>
        /// <param name="refreshToken">refreshToken</param>
        /// <param name="accessToken">accessToken</param>
        /// <param name="dateTime"></param>
        /// <returns>JwtAuthInfo</returns>
        Task<JwtAuthInfo> Refresh(string refreshToken, string accessToken, DateTime dateTime);
        /// <summary>
        /// 移除RefreshToken
        /// </summary>
        /// <param name="dateTime"></param>
        Task RemoveExpiredRefreshTokens(DateTime dateTime);
        /// <summary>
        /// 根据用户Id移除RefreshToken
        /// </summary>
        /// <param name="userId">用户Id</param>
        Task RemoveRefreshTokenByUserId(long userId);
        /// <summary>
        /// 根据用户姓名移除RefreshToken
        /// </summary>
        /// <param name="userName"></param>
        Task RemoveRefreshTokenByUserName(string userName);
        /// <summary>
        /// 解码JwtToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="validateLefttime">是否校验过期时间</param>
        /// <returns>UserInfo</returns>
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token, bool validateLefttime = true);
    }
}
