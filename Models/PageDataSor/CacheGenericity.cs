using Models.PageDataSor.ProgremData;

namespace Models.PageDataSor
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    /// <typeparam name="T">缓存的类型</typeparam>
    public class CacheGenericity<T> where T : class, new()
    {
        static SessionCache<T> sessionCache = new SessionCache<T>();
        public static SessionCache<T> Data
        {
            get { return sessionCache; }
            set { sessionCache = value; }
        }
    }
}
