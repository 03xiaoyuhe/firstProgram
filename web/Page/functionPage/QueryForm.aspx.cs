using System;

namespace WebForm.functionPage
{
    public partial class QueryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                Request.Cookies[i].Expires = DateTime.Now.AddDays(-1);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script type='text/javascript'>document.getElementById(\"test\").src = \"QF-ChildPage/PeopleInform.aspx\";</script>");
        }
    }
}