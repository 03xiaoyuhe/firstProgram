using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.BaseForm
{
    public partial class ShowBoxForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string dataHead;
        /// <summary>
        /// 数据项标题
        /// </summary>
        public string DataHead
        {
            get
            {
                return dataHead;
            }
            set
            {
                if (value == null || value == string.Empty || value == "") { value = "无数据"; }
                dataHead = value;
                DataHeadLable.Text = value;
            }
        }

        string data;
        /// <summary>
        /// 数据
        /// </summary>
        public string Data
        {
            get { return data; }
            set
            {
                data = value;
                DataLable.Text = value;
            }
        }
    }
}