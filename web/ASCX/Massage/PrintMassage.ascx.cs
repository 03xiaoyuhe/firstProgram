using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


/// <summary>
/// <b>消息输出控件</b><br/>
/// <br/>
/// 通过<u>Cookie</u>实现的发送并显示消息的控件<br/>
/// 在需要发送消息的地方产生一个Cookie<i>(<带有type属性并且为Massage)</i><br/>
/// 然后该控件就能通过读取特定Cookie来进行消息显示<br/>
/// </summary>
public partial class ASCX_PrintMassage : System.Web.UI.UserControl
{

    int Count
    {
        get
        {
            if (ViewState["ControlCount"] == null)
                ViewState["ControlCount"] = 0;
            return (int)ViewState["ControlCount"];
        }
        set
        {
            ViewState["ControlCount"] = value;
        }
    }

    static List<HttpCookie> AllCookies = new List<HttpCookie>();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }

    void LoadUserControl(
        string HeadColor,
        string HeadLine,
        string Massage,
        string DataTime,
        string Name
        )
    {
        ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/Massage/opMassage.ascx");
        ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml(HeadColor);
        ErroMassage.HeadLine = HeadLine;
        ErroMassage.Massage = Massage;
        ErroMassage.DataTime = DataTime;
        ErroMassage.CookieName = Name;
        //up1.ContentTemplateContainer.Controls.Add
        MassageP.ContentTemplateContainer.Controls.Add(ErroMassage);
    }

    void LoadUserControl(HttpCookie cookie)
    {
        ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/Massage/popMassage.ascx");
        ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml(cookie.Values["HeadColor"].ToString());
        ErroMassage.HeadLine = Server.UrlDecode(cookie.Values["HeadText"]);
        ErroMassage.Massage = Server.UrlDecode(cookie.Values["MassageText"]);
        ErroMassage.DataTime = Server.UrlDecode(cookie.Values["DataTime"]);
        ErroMassage.CookieName = Server.UrlDecode(cookie.Name);
        //up1.ContentTemplateContainer.Controls.Add
        MassageP.ContentTemplateContainer.Controls.Add(ErroMassage);
    }

    /// <summary>
    /// 在消息显示控件刷新时调用，读取消息Cookie，创建并将消息控件添加到消息显示控件中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MassageP_Load(object sender, EventArgs e)
    {
        /// 直接读取Cookie会使运行效率过慢
        /// 可尝试在上文，判断消息Cookie数量是否与显示数量相等的部分
        /// 将读取到的消息Cookie存放在变量中
        /// 在本处直接读取需要显示的部分进而加快速率
        for (int i = Request.Cookies.Count - 1; i > -1; i--)
        {
            if (Request.Cookies[i].Values["Type"] != null)
            {
                if (Request.Cookies[i].Values["Type"].ToString() == "Massage-1.0")
                {
                    LoadUserControl(Request.Cookies[i]);
                }
            }
        }
    }

    protected void updateFlight_Load(object sender, EventArgs e)
    {
        //time.Text = DateTime.Now.ToString();
        int count = 0;

        /// 统计消息Cookie数量在与显示数量不同时刷新消息显示控件
        for (int i = Request.Cookies.Count - 1; i > -1; i--)
        {
            if (Request.Cookies[i].Values["Type"] != null)
            {
                if (Request.Cookies[i].Values["Type"].ToString() == "Massage-1.0")
                {
                    AllCookies.Add(Request.Cookies[i]);
                    count++;
                }
            }
        }
        if (count != Count)
        {
            MassageP.Update();
            Count = count;
        }
        else
        {
            AllCookies.Clear();
        }
    }
}