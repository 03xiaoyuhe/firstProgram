using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Models.PageDataSor
{
    public class CacheGenericity<T> : UserControl where T : class
    {
        public T this[string index]
        {
            get
            {
                return Session[index] as T;
            }
            set
            {
                Session[index] = value;
            }
        }
    }
}
