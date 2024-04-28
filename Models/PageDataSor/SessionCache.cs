using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Models.PageDataSor.ProgremData
{
    public class SessionCache<T>  where T : class, new()
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
