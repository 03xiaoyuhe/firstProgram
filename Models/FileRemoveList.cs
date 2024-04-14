using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FileRemoveList : System.Web.UI.UserControl
    {

        /// <summary>
        /// 移除文件ID列表
        /// </summary>
        public List<string> Data
        {
            get
            {
                return (List<string>)ViewState["FileRemoveList"];
            }
            set
            {
                ViewState["FileRemoveList"] = value;
            }
        }

        public void Add(string value)
        {
            Data.Add(value);
        }
    }
}
