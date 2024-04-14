using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class UserLoginon_ : System.Web.UI.Page
{
    //管理员

    static string a = null;
    static string b = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //useNumber
            userName.Attributes["onblur"] = ClientScript.GetPostBackEventReference(this.userName, "setModo");
            useNumber.Attributes["onblur"] = ClientScript.GetPostBackEventReference(this.useNumber, "setModo");

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'>window.location='home.aspx'</script>");
    }

    protected void userName_TextChanged(object sender, EventArgs e)
    {
        DBHelper.Mode = 1;
        DBHelper.Setting();

        if (DAL.Control.CheckIfAccountExists((this.userName.Text.ToString())))
        {
            a = this.userPwd.Text.ToString();
            b = this.userPwd2.Text.ToString();
            this.SameName.Text = "账号已存在，请重新输入！";

        }
        else
        {

            a = this.userPwd.Text.ToString();
            b = this.userPwd2.Text.ToString();
            this.SameName.Text = null;
        }



    }

    protected void BtmLogin_Click(object sender, EventArgs e)
    {
        DBHelper.Mode = 1;
        DBHelper.Setting();
        if (DAL.Control.CheckIfAccountExists((this.userName.Text.ToString())))
        {
            Response.Write("<script>alert('用户名已存在！')</script>");

        }
        else if (DAL.Control.CheckIfUserNumberExists(this.useNumber.Text.ToString()))
        {
            Response.Write("<script>alert('联系电话已被注册！')</script>");
        }
        else
        {
            this.SameName.Text = null;
            if (DAL.Control.InsertId(this.userName.Text.ToString(), this.userPwd.Text.ToString(), this.useNumber.Text.ToString()))
            {
                Response.Write("<script>alert('注册成功！')</script>");
                Response.Write("<script language='javascript'>window.location='home.aspx'</script>");
            }
            else
                Response.Write("<script>alert('发生未知错误，请联系工作人员！')</script>");



        }


    }

    protected void useNumber_TextChanged(object sender, EventArgs e)
    {
        DBHelper.Mode = 1;
        DBHelper.Setting();
        if (DAL.User.CheckIfUserNumberExists(this.useNumber.Text.ToString()))
        {
            a = this.userPwd.Text.ToString();
            b = this.userPwd2.Text.ToString();
            this.sameUserNumber.Text = "联系电话已被注册，请重新输入！";

        }
        else
        {
            a = this.userPwd.Text.ToString();
            b = this.userPwd2.Text.ToString();
            this.sameUserNumber.Text = null;

        }


    }

    protected void setModo()
    {
        this.userPwd.Text = a;
        this.userPwd2.Text = b;
    }


    //用户
    //static string a = null;
    //static string b = null;
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //    if (!IsPostBack)
    //    {
    //        //useNumber
    //        userName.Attributes["onblur"] = ClientScript.GetPostBackEventReference(this.userName, "setModo");
    //        useNumber.Attributes["onblur"] = ClientScript.GetPostBackEventReference(this.useNumber, "setModo");

    //    }

    //}

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Write("<script language='javascript'>window.location='home.aspx'</script>");
    //}

    //protected void userName_TextChanged(object sender, EventArgs e)
    //{
    //    DBHelper.Mode = 1;
    //    DBHelper.Setting();

    //    if (DAL.User.CheckIfAccountExists((this.userName.Text.ToString())))
    //    {
    //        a = this.userPwd.Text.ToString();
    //        b = this.userPwd2.Text.ToString();
    //        this.SameName.Text = "账号已存在，请重新输入！";

    //    }
    //    else
    //    {

    //        a = this.userPwd.Text.ToString();
    //        b = this.userPwd2.Text.ToString();
    //        this.SameName.Text = null;
    //    }



    //}

    //protected void BtmLogin_Click(object sender, EventArgs e)
    //{
    //    DBHelper.Mode = 1;
    //    DBHelper.Setting();
    //    if (DAL.User.CheckIfAccountExists((this.userName.Text.ToString())))
    //    {
    //        Response.Write("<script>alert('用户名已存在！')</script>");

    //    }
    //    else if (DAL.User.CheckIfUserNumberExists(this.useNumber.Text.ToString()))
    //    {
    //        Response.Write("<script>alert('联系电话已被注册！')</script>");
    //    }
    //    else
    //    {
    //        this.SameName.Text = null;
    //        if (DAL.User.InsertId(this.userName.Text.ToString(), this.userPwd.Text.ToString(), this.useNumber.Text.ToString()))
    //        {
    //            Response.Write("<script>alert('注册成功！')</script>");
    //            Response.Write("<script language='javascript'>window.location='home.aspx'</script>");
    //        }
    //        else
    //            Response.Write("<script>alert('发生未知错误，请联系工作人员！')</script>");



    //    }


    //}

    //protected void useNumber_TextChanged(object sender, EventArgs e)
    //{
    //    DBHelper.Mode = 1;
    //    DBHelper.Setting();
    //    if (DAL.User.CheckIfUserNumberExists(this.useNumber.Text.ToString()))
    //    {
    //         a = this.userPwd.Text.ToString();
    //         b = this.userPwd2.Text.ToString();
    //        this.sameUserNumber.Text = "联系电话已被注册，请重新输入！";

    //    }
    //    else
    //    {
    //         a = this.userPwd.Text.ToString();
    //         b = this.userPwd2.Text.ToString();
    //        this.sameUserNumber.Text = null;

    //    }


    //}

    //protected void setModo()
    //{
    //    this.userPwd.Text = a;
    //    this.userPwd2.Text = b;
    //}
}