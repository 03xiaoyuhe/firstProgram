using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Models.PageDataSor
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    /// <typeparam name="T">缓存的类型</typeparam>
    public class CacheGenericity<T>  where T : class
    {
        public static SessionCache<T> SessionCache { get; set; }
    }
}
