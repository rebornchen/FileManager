using System.Collections;
using System.Collections.Generic;
using System.Web.Caching;
namespace CL.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class CacheExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        public static void Clear(this Cache cache)
        {
            List<string> keys = new List<string>();
            IDictionaryEnumerator items = cache.GetEnumerator();
            while (items.MoveNext())
                keys.Add(items.Key.ToString());

            foreach (string key in keys)
                cache.Remove(key);
        }
    }
}
