using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_popMassage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //Head


    Color headColor;
    [Description("标题颜色"), Category("自定义属性")]
    public Color HeadColor                  // 控件的自定义属性值
    {
        get
        {
            return headColor;
        }
        set
        {
            headColor = value;
            Head.ForeColor = value;
        }
    }

    string headLine = "错误信息";
    [Description("消息类型"), Category("自定义属性")]
    public string HeadLine                  // 控件的自定义属性值
    {
        get
        {
            return headLine;
        }
        set
        {
            headLine = value;
            Head.Text = value;
        }
    }


    string massage = "错误信息";
    [Description("错误信息"), Category("自定义属性")]
    public string Massage                  // 控件的自定义属性值
    {
        get
        {
            return massage;
        }
        set
        {
            massage = value;
            MAssage.Text = value;
        }
    }


    string time = "";
    [Description("消息产生时间"), Category("自定义属性")]
    public string DataTime                  // 控件的自定义属性值
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
            second.Text = value;
        }
    }

    string cookiename = "";
    [Description("对应的消息Cookie"), Category("自定义属性")]
    public string CookieName                  // 控件的自定义属性值
    {
        get
        {
            return cookiename;
        }
        set
        {
            cookiename = value;
        }
    }

    public void Quit_Click(object sender, EventArgs e)
    {
        string cookiesName = CookieName;
        HttpCookie cookie = new HttpCookie(cookiesName);
        cookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookie);
    }
    public UserControl GetUC()
    {
        return this;
    }
}
