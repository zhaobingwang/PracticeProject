using PracticeProject.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Configuration;

namespace PracticeProject.Core.Tests
{
    public class RedisOperatorTest
    {
        private int DbIndex = 15;
        private string RedisHost = "127.0.0.1:6379";
        private string CustomKey = string.Empty;

        public RedisOperatorTest()
        {
        }

        [Fact]
        public void StringSetTestWithExpectedParameters()
        {
            // arrange
            var db = new RedisOperator(DbIndex, RedisHost);
            db.CustomKey = CustomKey;

            // act
            var result = db.StringSet("a", "test value");

            // assert
            Assert.True(result);
        }
    }
}
