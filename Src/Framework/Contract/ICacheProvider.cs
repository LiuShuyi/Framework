using System;

namespace Framework.Contract
{
    /// <summary>
    /// Cache Provider
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Default Expire Time
        /// </summary>
        Int32 DefaultExpireSeconds { get; }

        /// <summary>
        /// Prefix of CacheKey
        /// </summary>
        String KeyPrefix { get; }

        /// <summary>
        /// Max Number Elements In Cache
        /// </summary>
        Int32 MaxNumberElementsInCache { get; }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Object Get(String key);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        void Add(String key, Object obj);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="seconds"></param>
        void Add(String key, Object obj, Int32 seconds);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="key"></param>
        void Remove(String key);

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Boolean Contains(String key);

        /// <summary>
        /// Clear
        /// </summary>
        void Clear();
    }
}
