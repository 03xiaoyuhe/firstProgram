using System;
using System.ComponentModel;

namespace WebForm.ASCX.Table
{
    public partial class CellForBody : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string cellData = "";
        [Description("单元格内容"), Category("自定义属性")]
        public string CellData                  // 控件的自定义属性值
        {
            get
            {
                return cellData;
            }
            set
            {
                cellData = value;
                Data.Text = value;
            }
        }
    }
}