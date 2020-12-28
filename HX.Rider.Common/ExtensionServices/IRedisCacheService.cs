using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HX.Rider.Common
{
    /// <summary>
    /// Redis ConfigService
    /// </summary>
    public interface IRedisCacheService
    {

        /// <summary>
        ///  向hashid集合中添加key/value
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetEntryInHash(string hashid, string key, string value);

        /// <summary>
        /// 向hashid集合中添加key/value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetEntryInHash<T>(string hashid, string key, T value);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetValueFromHash(string hashid, string key);

        
    }
}
