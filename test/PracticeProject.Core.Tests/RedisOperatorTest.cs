using PracticeProject.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Configuration;
using StackExchange.Redis;

namespace PracticeProject.Core.Tests
{
    [Trait("Redis","String")]
    public class RedisOperatorTest
    {
        private int DbIndex = 15;
        private string RedisHost = "127.0.0.1:6379";
        private string CustomKey = "Demo:Test:";

        RedisOperator db;
        public RedisOperatorTest()
        {

            db = new RedisOperator(DbIndex, RedisHost);
            db.CustomKey = CustomKey;
        }

        [Fact(DisplayName = "保存单个Key,Value正常测试")]
        public void StringSet_WithExpectedParameters()
        {
            // arrange


            // act
            var result = db.StringSet("single", "single value", TimeSpan.FromMinutes(1));

            // assert
            Assert.True(result);
        }

        [Fact(DisplayName = "保存多个Key,Value正常测试")]
        public void StringSetMultiKV_WithExpectedParameters()
        {
            // arrange
            List<KeyValuePair<RedisKey, RedisValue>> list = new List<KeyValuePair<RedisKey, RedisValue>>();

            list.Add(new KeyValuePair<RedisKey, RedisValue>("A", "1"));
            list.Add(new KeyValuePair<RedisKey, RedisValue>("B", "2"));
            list.Add(new KeyValuePair<RedisKey, RedisValue>("C", "3"));

            // act
            var result = db.StringSet(list);

            // assert
            Assert.True(result);
        }
    }
}
