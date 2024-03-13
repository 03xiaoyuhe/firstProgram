using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class functionPage_test1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int a;
        if(Request.QueryString["index"] != null) a = int.Parse(Request.QueryString["index"]);
        else a = 1;
        if (a > 0) {

            Label1.Text = a.ToString();
            aaa.Index = a;
        }
    }
}