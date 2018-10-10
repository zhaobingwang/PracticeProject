using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using Newtonsoft.Json;
using System.Linq;

namespace PracticeProject.Core.Cache
{
    public class RedisOperator
    {
        private int DbNum { get; }
        private readonly ConnectionMultiplexer _conn;

        /// <summary>
        /// Redis key prefix
        /// </summary>
        public string CustomKey;

        #region ctor
        public RedisOperator(int dbNum = 0) : this(dbNum, null)
        {

        }
        public RedisOperator(int dbNum, string readWriteHosts)
        {
            DbNum = dbNum;
            _conn = string.IsNullOrEmpty(readWriteHosts) ? RedisManager.GetInstance : RedisManager.GetConnectionMultiplexer(readWriteHosts);
        }
        #endregion ctor

        #region String-同步方法
        /// <summary>
        /// 保存单个Key,Value
        /// </summary>
        /// <param name="key">Redis键</param>
        /// <param name="value">Redis值</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool StringSet(string key, string value, TimeSpan? expiry = default(TimeSpan?))
        {
            key = AddSysCustomKey(key);
            return Do(db => db.StringSet(key, value, expiry));
        }

        /// <summary>
        /// 保存多个Key,Value
        /// </summary>
        /// <param name="keyValues">Redis键值对</param>
        /// <returns></returns>

        public bool StringSet(List<KeyValuePair<RedisKey, RedisValue>> keyValues)
        {
            List<KeyValuePair<RedisKey, RedisValue>> newKeyValues = keyValues.Select(r => new KeyValuePair<RedisKey, RedisValue>(AddSysCustomKey(r.Key), r.Value)).ToList();
            return Do(db => db.StringSet(newKeyValues.ToArray()));
        }

        /// <summary>
        /// 保存一个对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">Redis键</param>
        /// <param name="obj">对象</param>
        /// <param name="expiry">过期时间</param>
        /// <returns></returns>
        public bool StringSet<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            key = AddSysCustomKey(key);
            string json = ConvertToJson(obj);
            return Do(r => r.StringSet(key, json, expiry));
        }

        /// <summary>
        /// 获取单个key值
        /// </summary>
        /// <param name="key">Redis键</param>
        /// <returns></returns>
        public string StringGet(string key)
        {
            key = AddSysCustomKey(key);
            return Do(r => r.StringGet(key));
        }

        /// <summary>
        /// 获取多个key的值
        /// </summary>
        /// <param name="listKey">Redis键集合</param>
        /// <returns></returns>
        public RedisValue[] StringGet(List<string> listKey)
        {
            List<string> newKeys = listKey.Select(AddSysCustomKey).ToList();
            return Do(db => db.StringGet(ConvertToRedisKeys(newKeys)));
        }

        /// <summary>
        /// 获取一个key的对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="key">Redis键</param>
        /// <returns>对象</returns>
        public T StringGet<T>(string key)
        {
            key = AddSysCustomKey(key);
            return Do(db => ConvertToObj<T>(StringGet(key)));
        }

        /// <summary>
        /// 为数字增加val
        /// </summary>
        /// <param name="key">Redis键</param>
        /// <param name="val">增加的值，可为负</param>
        /// <returns>增加后的值</returns>
        public double StringIncrement(string key, double val = 1)
        {
            key = AddSysCustomKey(key);
            return Do(db => db.StringIncrement(key, val));
        }

        /// <summary>
        /// 为数字减少val
        /// </summary>
        /// <param name="key">Redis键</param>
        /// <param name="val">减少的值，可为负</param>
        /// <returns>减少后的值</returns>
        public double StringDecrement(string key, double val = 1)
        {
            key = AddSysCustomKey(key);
            return Do(db => db.StringDecrement(key, val));
        }
        #endregion String-同步方法

        #region String-异步方法

        #endregion String-异步方法

        #region private method
        private string AddSysCustomKey(string oldKey)
        {
            var prefixKey = CustomKey ?? RedisManager.SysCustomKey;
            return prefixKey + oldKey;
        }

        private T Do<T>(Func<IDatabase, T> func)
        {
            var database = _conn.GetDatabase(DbNum);
            return func(database);
        }
        private string ConvertToJson<T>(T value)
        {
            string result = value is string ? value.ToString() : JsonConvert.SerializeObject(value);
            return result;
        }
        private T ConvertToObj<T>(RedisValue value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        private List<T> ConvertToList<T>(RedisValue[] values)
        {
            List<T> result = new List<T>();
            foreach (var item in values)
            {
                var model = ConvertToObj<T>(item);
                result.Add(model);
            }
            return result;
        }
        private RedisKey[] ConvertToRedisKeys(List<string> redisKeys)
        {
            return redisKeys.Select(redisKey => (RedisKey)redisKey).ToArray();
        }
        #endregion
    }
}
