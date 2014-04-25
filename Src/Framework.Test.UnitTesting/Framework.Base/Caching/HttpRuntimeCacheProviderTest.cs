using Framework.Base.Caching.HttpRuntime;
using NUnit.Framework;

namespace Framework.Test.UnitTesting.Framework.Base.Caching
{
    /// <summary>
    /// Framework.Caching.AspNetCacheProvider 单元测试
    /// </summary>
    [TestFixture]
    public class HttpRuntimeCacheProviderTest
    {
        /// <summary>
        /// AspNetCacheProvider
        /// </summary>
        private HttpRuntimeCacheProvider aspNetCacheProviderTest = new HttpRuntimeCacheProvider();

        [Test]
        public void 添加获取缓存测试()
        {
            var key = "AddCacheTest";

            var value = "Hello, This is AddCacheTest.";

            aspNetCacheProviderTest.Add(key, value);

            Assert.AreEqual(aspNetCacheProviderTest.Get(key), value);
        }

        [Test]
        public void 缓存过期测试()
        {
            var key = "CacheExpireTest";

            var value = "Hello, This is CacheExpireTest.";

            aspNetCacheProviderTest.Add(key, value, 2);

            Assert.AreEqual(aspNetCacheProviderTest.Get(key), value);

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(aspNetCacheProviderTest.Get(key), null);
        }

        [Test]
        public void 缓存清空测试()
        {
            var key = "CacheClearTest";

            var value = "Hello, This is CacheClearTest.";

            aspNetCacheProviderTest.Add(key, value, 10000);

            Assert.AreEqual(aspNetCacheProviderTest.Get(key), value);

            aspNetCacheProviderTest.Clear();

            Assert.AreEqual(aspNetCacheProviderTest.Get(key), null);
        }
    }
}
