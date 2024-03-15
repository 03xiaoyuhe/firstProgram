using System;

namespace WebForm
{
    public partial class home_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        #region 前端控制
        protected void workerLogin_Click(object sender, EventArgs e)
        {

            Response.Write("<script language='javascript'>window.location='WorkerLogin.aspx'</script>");
        }

        #endregion

        #region 后端控制

        #endregion
    }
}