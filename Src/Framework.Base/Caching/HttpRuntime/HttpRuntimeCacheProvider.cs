using Framework.Base.Contract;
using System;
using System.Collections.Generic;

namespace Framework.Base.Caching.HttpRuntime
{
    /// <summary>
    /// HttpRuntime.Cache Provider
    /// </summary>
    public class HttpRuntimeCacheProvider : ICacheProvider
    {
        #region .ctor

        /// <summary>
        /// .ctor
        /// </summary>
        public HttpRuntimeCacheProvider() { }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="defaultExpireSeconds"></param>
        /// <param name="maxNumberElementsInCache"></param>
        public HttpRuntimeCacheProvider(Int32 defaultExpireSeconds, Int32 maxNumberElementsInCache)
        {
            this.defaultExpireSeconds = defaultExpireSeconds;

            this.maxNumberElementsInCache = maxNumberElementsInCache;
        }

        #endregion

        #region Fields

        /// <summary>
        /// Default expire time
        /// </summary>
        private readonly Int32 defaultExpireSeconds = 60;

        /// <summary>
        /// Cache key prefix
        /// </summary>
        private const String keyPrefix = "AspNetCacheProvider_";

        /// <summary>
        /// Max number elements in cache
        /// </summary>
        private readonly Int32 maxNumberElementsInCache = 100000;

        #endregion

        #region Propertys

        /// <summary>
        /// Default expire time
        /// </summary>
        public Int32 DefaultExpireSeconds
        {
            get { return defaultExpireSeconds; }
        }

        /// <summary>
        /// Cache key prefix
        /// </summary>
        public String KeyPrefix
        {
            get { return keyPrefix; }
        }

        /// <summary>
        /// Max number elements in cache
        /// </summary>
        public Int32 MaxNumberElementsInCache
        {
            get { return maxNumberElementsInCache; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Object Get(String key)
        {
            return System.Web.HttpRuntime.Cache.Get(CacheKeyConcatByKeyPrefix(key));
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Add(String key, Object obj)
        {
            Add(key, obj, defaultExpireSeconds);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="seconds"></param>
        public void Add(String key, Object obj, Int32 seconds)
        {
            System.Web.HttpRuntime.Cache.Insert(CacheKeyConcatByKeyPrefix(key), obj, null, DateTime.Now.AddSeconds(seconds), TimeSpan.Zero);
        }

        /// <summary>
        /// Remove 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(String key)
        {
            System.Web.HttpRuntime.Cache.Remove(CacheKeyConcatByKeyPrefix(key));
        }

        /// <summary>
        /// Is contains element by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Boolean Contains(String key)
        {
            var cacheEnumerator = System.Web.HttpRuntime.Cache.GetEnumerator();

            while (cacheEnumerator.MoveNext())
            {
                var cacheItem = System.Web.HttpRuntime.Cache[cacheEnumerator.Key.ToString()];

                if (cacheItem != null && cacheEnumerator.Key.Equals(CacheKeyConcatByKeyPrefix(key)))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Clear caches
        /// </summary>
        public void Clear()
        {
            var cacheEnumerator = System.Web.HttpRuntime.Cache.GetEnumerator();

            var keyList = new List<String>();

            while (cacheEnumerator.MoveNext())
            {
                keyList.Add(cacheEnumerator.Key.ToString());
            }

            foreach (var key in keyList)
            {
                System.Web.HttpRuntime.Cache.Remove(key);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// CacheKey concat by keyPrefix
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private String CacheKeyConcatByKeyPrefix(String key)
        {
            return String.Concat(keyPrefix, key);
        }

        #endregion
    }
}
