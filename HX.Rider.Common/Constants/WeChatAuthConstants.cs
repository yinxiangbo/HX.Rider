using System;
using System.Collections.Generic;
using System.Text;

namespace HX.Rider.Common.Constants
{
    /// <summary>
    /// 微信登录授权相关信息
    /// </summary>
    public static class WeChatAuthConstants
    {
        public const string AuthenticationScheme = "WeChat";

        public const string AuthorizationEndpoint = "https://open.weixin.qq.com/connect/oauth2/authorize";

        public const string TokenEndpoint = "https://api.weixin.qq.com/sns/oauth2/access_token";

        public const string UserInformationEndpoint = "https://api.weixin.qq.com/sns/userinfo";
    }
}
