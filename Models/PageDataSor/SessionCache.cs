using System.Web;

namespace Models.PageDataSor.ProgremData
{
    public class SessionCache<T> where T : class, new()
    {

        /// <summary>
        /// 缓存机制泛型类
        /// </summary>
        /// <param name="index">缓存内容名</param>
        /// <returns></returns>
        public T this[string index]
        {
            get
            {
                if (HttpContext.Current.Session[index] == null) HttpContext.Current.Session[index] = new T();
                return HttpContext.Current.Session[index] as T;
            }
            set
            {
                HttpContext.Current.Session[index] = value;
            }
        }
    }
}
