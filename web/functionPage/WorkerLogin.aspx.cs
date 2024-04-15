using DAL;
using System;

namespace WebForm
{
    public partial class WorkerLogin : System.Web.UI.Page
    {
        public string UID = "TTT";
        public string PWD = "zzz101";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["loginSuccess"] == null)
            {
                Session["userName"] = null;
                Session["loginSuccess"] = "unlogin";
            }
            if (Session["userName"] != null && Session["loginSuccess"].ToString() == "success")
            {
                Response.Write("<script language='javascript'>window.location='./QueryForm.aspx'</script>");
            }
        }



        protected void BtmLogin_Click(object sender, EventArgs e)
        {
            string a = this.userName.Text.ToString();
            string b = this.userPwd.Text.ToString();
            DBHelper.Mode = 1;
            DBHelper.Setting();
            if (DAL.Control.AuthenticateUser(a, b))
            {
                Session["userName"] = this.userName.Text;
                Session["loginSuccess"] = "success";
                Response.Write("<script language='javascript'>window.location='./QueryForm.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('用户名或密码输入错误')</script>");
            }

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.location='../home.aspx'</script>");
        }
    }
}