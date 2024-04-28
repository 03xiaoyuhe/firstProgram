using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Models.PageDataSor.ProgremData
{
    public class SessionCache<T> : UserControl where T : class, new()
    {
        public SessionCache(): base() { }

        /// <summary>
        /// 缓存机制泛型类
        /// </summary>
        /// <param name="index">缓存内容名</param>
        /// <returns></returns>
        public T this[string index]
        {
            get
            {
                if (Session[index] == null) Session[index] = new T();
                return Session[index] as T;
            }
            set
            {
                Session[index] = value;
            }
        }
    }
}
