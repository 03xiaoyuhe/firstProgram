using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_CellForTable : System.Web.UI.UserControl
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