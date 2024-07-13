using System;

namespace WebForm
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                Request.Cookies[i].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}