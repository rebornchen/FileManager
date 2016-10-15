using System;

namespace CL.Common
{
    /// <summary>
    ///Author   : Aricous
    ///Datetime : 20100712
    ///Function : Description
    /// </summary>
    public class Lazy<T>
    {
        /// <summary>
        /// 方法字段
        /// </summary>
        private Func<T> creator;
        /// <summary>
        /// 互斥对象
        /// </summary>
        private readonly object mutex = new object();
        /// <summary>
        /// 缺省构造
        /// </summary>
        public Lazy() : this(() => Activator.CreateInstance<T>()) { }
        /// <summary>
        /// 方法构造
        /// </summary>
        /// <param name="creator"></param>
        public Lazy(Func<T> creator) { this.creator = creator; }

        private T value;
        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get
            {
                lock (mutex)
                {
                    if (value == null && creator != null)
                    {
                        value = creator();
                    }
                    return value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lazy"></param>
        /// <returns></returns>
        public static implicit operator T(Lazy<T> lazy) { return lazy.Value; }
    }
}
