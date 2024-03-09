using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class masterPage_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* 如果userName为空则初始化 */
        if (Session["loginSuccess"] == null)
        {
            Session["userName"] = null;
            Session["loginSuccess"] = "unlogin";
        }
    }

    
}
