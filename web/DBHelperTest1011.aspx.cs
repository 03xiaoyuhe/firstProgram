using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DBHelperTest : System.Web.UI.Page
{
    public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //创建一个临时数据库
            DataSet ds = new DataSet();
            //创建一个临时表
            dt = new DataTable();
        }
    }
}
