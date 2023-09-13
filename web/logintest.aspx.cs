using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string UserName = "abc";
    string UserPwd = "zzz1001";

    string AdmName = "TTT";
    string AdmPwd = "zzz101";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ID"] = 111;

        if (!IsPostBack)
        {
            Session["userName"] = null;
            Session["loginSuccess"] = "unlogin";
        }
        if (Session["loginSuccess"].ToString() == "success")
        {
            turnToLoginSuccessModo();
        }
    }

    //将页面调整为登陆完成状态
    protected void turnToLoginSuccessModo()
    {
        this.unLogin.Attributes.Add("style","display:none");
        this.LoginSuccess.Attributes.Add("style", "display:block");
    }


    protected void BtmLogin_Click(object sender, EventArgs e)
    {
        if(this.CheckAdm.Checked)
        {
            if(this.userName.Text == AdmName & this.userPwd.Text == AdmPwd)
            {
                Session["userName"] = this.userName.Text;
                Session["loginSuccess"] = "success";
            }
            else
            {
                Response.Write("<script>alert('用户名或密码输入错误')</script>");
            }
        }
        else
        {
            if (this.userName.Text == UserName & this.userPwd.Text == UserPwd)
            {
                Session["userName"] = this.userName.Text;
                Session["loginSuccess"] = "success";
            }
            else
            {
                Response.Write("<script>alert('用户名或密码输入错误')</script>");
            }
        }
        if (Session["loginSuccess"].ToString() == "success")
        {
            turnToLoginSuccessModo();
        }
        
    }
    protected bool IfLoginSeccess(object sender, ServerValidateEventArgs args)
    {
        if (this.CheckAdm.Checked)
        {
            if (this.userName.Text == AdmName & args.Value == AdmPwd)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
        else
        {
            if (this.userName.Text == UserName & args.Value == UserPwd)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }

    
}