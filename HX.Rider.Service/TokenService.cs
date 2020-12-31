using HX.Rider.Common;
using HX.Rider.Entity;
using HX.Rider.IRepository;
using HX.Rider.IService;
using HX.Rider.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.Service
{
    /// <summary>
    /// JWT Token服务
    /// </summary>
    public class TokenService : ITokenService
    {
        #region private props
        //private readonly string redisCacheHashId = "TokenService";
        /// <summary>
        /// redis缓存服务
        /// </summary>
        private readonly IRedisCacheService redisCacheService;
        /// <summary>
        /// Token服务
        /// </summary>
        private readonly ITokenRepository tokenRepository;
        /// <summary>
        /// Token配置选项
        /// </summary>
        private readonly JwtTokenOptions jwtTokenConfig;
        #endregion
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="redisCacheService">redis缓存服务</param>
        public TokenService(ITokenRepository tokenRepository, IRedisCacheService redisCacheService, IOptions<JwtTokenOptions> options)
        {
            this.redisCacheService = redisCacheService;
            this.tokenRepository = tokenRepository;
            this.jwtTokenConfig = options.Value;
        }
        /// <summary>
        /// 生成JWT Token
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名称</param>
        /// <param name="claims"></param>
        /// <param name="jwtTokenConfig"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<JwtAuthInfo> GenerateTokens(long userId,string userName, Claim[] claims, DateTime dateTime)
        {
            var secret= Encoding.ASCII.GetBytes(jwtTokenConfig.SecretKey);
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var jwtToken = new JwtSecurityToken(
                jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: dateTime.AddMinutes(jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var entity = new RefreshTokenEntity
            {
                UserId= userId,
                UserName = userName,
                Token = GenerateRefreshToken(),
                ExpireAt = dateTime.AddMinutes(jwtTokenConfig.RefreshTokenExpiration)
            };
            //redisCacheService.SetEntryInHash(redisCacheHashId, refreshToken.TokenString, refreshToken);
            await tokenRepository.AddOrUpdate(entity);
            return new JwtAuthInfo
            {
                AccessToken = accessToken,
                RefreshToken = MapperTo(entity)
            };
        }
        /// <summary>
        /// 生成JWT Token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="jwtTokenConfig"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<JwtAuthInfo> GenerateTokens(long userId, string userName,DateTime dateTime)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(JwtRegisteredClaimNames.Jti,userId.ToString()),
            };
            return await GenerateTokens(userId, userName, claims,dateTime);
        }
        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="accessToken"></param>
        /// <param name="jwtTokenConfig"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public async Task<JwtAuthInfo> Refresh(string refreshToken, string accessToken, DateTime dateTime)
        {
            var (principal, jwtToken) = DecodeJwtToken(accessToken,false);
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
                throw new SecurityTokenException("Invalid token");
            var tokenInfo =await tokenRepository.GetByToken(refreshToken);
            if (tokenInfo==null)
                throw new SecurityTokenException("Invalid token");
            var userId = (long)tokenInfo.UserId;
            if (tokenInfo.UserId != userId || tokenInfo.ExpireAt < dateTime)
                throw new SecurityTokenException("Invalid token");
            // need to recover the original claims
            return await GenerateTokens(userId, tokenInfo.UserName, principal.Claims.ToArray(), dateTime);
        }
        /// <summary>
        /// 移除过期的RefreshToken
        /// </summary>
        /// <param name="dateTime"></param>
        public async Task RemoveExpiredRefreshTokens(DateTime dateTime)
        {
            //var expiredTokens = tokenRepository.Where(x => x.Value.ExpireAt < dateTime).ToList();
            //foreach (var expiredToken in expiredTokens)
            //{
            //    tokenRepository.TryRemove(expiredToken.Key, out _);
            //}
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据用户Id移除过期的RefreshToken
        /// </summary>
        /// <param name="userId">用户Id</param>
        public async Task RemoveRefreshTokenByUserId(long userId)
        {
            await tokenRepository.RemoveByUserId(userId);
        }

        public async Task RemoveRefreshTokenByUserName(string userName)
        {
            await tokenRepository.RemoveByUserName(userName);
        }
        /// <summary>
        /// DecodeJwtToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="jwtTokenConfig"></param>
        /// <returns></returns>
        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token,bool validateLefttime=true)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new SecurityTokenException("Invalid token");
            var secret = Encoding.ASCII.GetBytes(jwtTokenConfig.SecretKey);
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = validateLefttime,
                    ClockSkew = TimeSpan.FromSeconds(30)
                }, out var validatedToken);
            return (principal, validatedToken as JwtSecurityToken);
        }



        #region private method
        /// <summary>
        /// 生成RefreshToken
        /// </summary>
        /// <returns>String</returns>
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        /// <summary>
        /// Mapper To RefreshToken
        /// </summary>
        /// <param name="entity">RefreshToken实体</param>
        /// <returns></returns>
        private RefreshToken MapperTo(RefreshTokenEntity entity)
        {
            return new RefreshToken()
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                TokenString = entity.Token,
                ExpireAt = entity.ExpireAt
            };
        } 
        #endregion


    }
}
