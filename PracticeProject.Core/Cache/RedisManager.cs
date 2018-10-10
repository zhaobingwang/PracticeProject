using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using StackExchange.Redis;

namespace PracticeProject.Core.Cache
{
    public class RedisManager
    {
        public static readonly string SysCustomKey = ConfigurationManager.AppSettings["redisKey"] ?? "";

        private static ConnectionMultiplexer _instance;
        private static readonly object Locker = new object();
        private static readonly string RedisConnectionString = ConfigurationManager.ConnectionStrings["RedisExchangeHosts"].ConnectionString;
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> ConnectionCache = new ConcurrentDictionary<string, ConnectionMultiplexer>();

        public static ConnectionMultiplexer GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                        {
                            _instance = GetManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            connectionString = connectionString ?? RedisConnectionString;
            var connect = ConnectionMultiplexer.Connect(connectionString);

            connect.ConnectionFailed += MuxerConnectionFailed;
            connect.ConnectionFailed += MuxerConnectionRestored;
            connect.ErrorMessage += MuxerErrorMessage;
            connect.ConfigurationChanged += MuxerConfigurationChanged;
            connect.HashSlotMoved += MuxerHashSlotMoved;
            connect.InternalError += MuxerInternalError;

            return connect;
        }

        #region 事件
        /// <summary>
        /// 连接失败，如果重新连接成功，将不会受到这个通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionFailed(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine($"重新连接：Endpoint failed:{e.EndPoint},{e.FailureType} {(e.Exception == null ? "" : e.Exception.Message)}");
        }

        /// <summary>
        /// 重新建立连接之前的错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConnectionRestored(object sender, ConnectionFailedEventArgs e)
        {
            Console.WriteLine($"ConnectionRestored:{e.EndPoint}");
        }


        /// <summary>
        /// 发生错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerErrorMessage(object sender, RedisErrorEventArgs e)
        {
            Console.WriteLine($"ErrorMessage:{e.Message}");
        }

        /// <summary>
        /// 配置更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerConfigurationChanged(object sender, EndPointEventArgs e)
        {
            Console.WriteLine($"Configuration changed:{e.EndPoint}");
        }

        /// <summary>
        /// 集群更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerHashSlotMoved(object sender, HashSlotMovedEventArgs e)
        {
            Console.WriteLine($"HashSlotMoved:NewEndPoint {e.NewEndPoint},OldEndPoint {e.OldEndPoint}");
        }

        /// <summary>
        /// Redis类库错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MuxerInternalError(object sender, InternalErrorEventArgs e)
        {
            Console.WriteLine($"InternalError:Message {e.Exception.Message}");
        }
        #endregion

        public static ConnectionMultiplexer GetConnectionMultiplexer(string connectionString = null)
        {
            if (!ConnectionCache.ContainsKey(connectionString))
            {
                ConnectionCache[connectionString] = GetManager(connectionString);
            }
            return ConnectionCache[connectionString];
        }
    }
}
