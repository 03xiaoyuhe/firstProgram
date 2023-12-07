using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLoginon_ : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            userName.Attributes["onblur"] = ClientScript.GetPostBackEventReference(this.userName, null);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'>window.location='home.aspx'</script>");
    }

    protected void userName_TextChanged(object sender, EventArgs e)
    {

    }
}