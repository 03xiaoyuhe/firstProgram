using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX;
using WebForm.ASCX.MassageForm;

namespace WebForm.functionPage
{
    public partial class QueryForm1 : System.Web.UI.Page
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