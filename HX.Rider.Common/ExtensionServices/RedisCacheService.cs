using HX.Rider.Model;
using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicOptions = Microsoft.Extensions.Options;

namespace HX.Rider.Common
{
    public class RedisCacheService : IRedisCacheService
    {
        /// <summary>
        /// Redis连接池管理实例
        /// </summary>
        private readonly PooledRedisClientManager pooledClientManager;
        
        public RedisCacheService(MicOptions.IOptions<RedisOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
                throw new ArgumentNullException(nameof(optionsAccessor));
            var options = optionsAccessor.Value;
            if (options.ReadWriteServers == null && options.ReadOnlyServers == null &&
                string.IsNullOrEmpty(options.SingleServer))
            {
                throw new ArgumentNullException(nameof(options.SingleServer));
            }

            if (options.ReadWriteServers?.Length < 1 && options.ReadOnlyServers?.Length < 1 &&
                string.IsNullOrEmpty(options.SingleServer))
            {
                throw new ArgumentNullException(nameof(options.SingleServer));
            }

            var config = new RedisClientManagerConfig
            {
                AutoStart = true,
                MaxWritePoolSize = options.MaxWritePoolSize,
                MaxReadPoolSize = options.MaxReadPoolSize,
                DefaultDb = options.DefaultDb,
            };
            pooledClientManager = new PooledRedisClientManager(
                options.ReadWriteServers ?? new[] { options.SingleServer }
                , options.ReadOnlyServers ?? new[] { options.SingleServer },
                config)
            {
                ConnectTimeout = options.ConnectTimeout,
                SocketSendTimeout = options.SendTimeout,
                SocketReceiveTimeout = options.ReceiveTimeout,
                IdleTimeOutSecs = options.IdleTimeOutSecs,
                PoolTimeout = options.PoolTimeout
            };
        }

        /// <summary>
        /// 获取Redis客户端连接对象，有连接池管理。
        /// </summary>
        /// <param name="isReadOnly">是否取只读连接。Get操作一般是读，Set操作一般是写</param>
        /// <returns></returns>
        public RedisClient GetRedisClient(bool isReadOnly = false)
        {
            if (pooledClientManager == null)
                throw new ArgumentNullException(nameof(pooledClientManager));
            if (!isReadOnly)
                return pooledClientManager.GetClient() as RedisClient;
            else
                return pooledClientManager.GetReadOnlyClient() as RedisClient;
        }
        /// <summary>
        /// 设置redis哈希缓存
        /// </summary>
        /// <param name="hashid">缓存哈希Id</param>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存数据</param>
        /// <returns></returns>
        public bool SetEntryInHash(string hashid, string key, string value)
        {
            var redisClient = GetRedisClient();
            return redisClient.SetEntryInHash(hashid, key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashid">缓存哈希Id</param>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存对象</param>
        /// <returns></returns>
        public bool SetEntryInHash<T>(string hashid, string key, T value)
        {
            var redisClient = GetRedisClient();
            return redisClient.SetEntryInHash(hashid, key, JsonConvert.SerializeObject(value));
        }
        /// <summary>
        /// 获取redis哈希缓存
        /// </summary>
        /// <param name="hashid">缓存哈希Id</param>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        public string GetValueFromHash(string hashid, string key)
        {
            var redisClient = GetRedisClient();
            return redisClient.GetValueFromHash(hashid, key);
        }


    }
}
