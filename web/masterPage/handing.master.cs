using System;

namespace WebForm.masterPage
{
    public partial class Site1 : System.Web.UI.MasterPage
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
}