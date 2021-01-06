using HX.Rider.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.Controllers
{
    /// <summary>
    /// 基础控制器
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class BaseController: ControllerBase
    {
        
        /// <summary>
        /// 当前登录用户Id
        /// </summary>
        protected long UserId
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return 0;
                var jtiValue= User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
                if (!long.TryParse(jtiValue,out long userId) || jtiValue=="0")
                    throw new HXException(HXExceptionCode.AUTH_FAILED, "用户认证失效");
                return userId;
            }
        }

    }
}
