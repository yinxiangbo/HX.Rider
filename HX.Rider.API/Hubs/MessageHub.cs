using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API
{
    /// <summary>
    /// 消息hub
    /// </summary>
    public class MessageHub:Hub
    {
        /// <summary>
        /// 发送消息hub
        /// </summary>
        /// <returns></returns>
        public async Task SendMessage(string content)
        {
            await Clients.All.SendAsync("ReceiveMessage", content);
        }
    }
}
