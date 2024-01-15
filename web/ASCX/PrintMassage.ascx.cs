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
    static int Count = -1;
    static List<HttpCookie> AllCookies = new List<HttpCookie>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Timer1.Interval = 200;
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int count = 0;

        /// 统计消息Cookie数量在与显示数量不同时刷新消息显示控件
        for (int i = Request.Cookies.Count - 1; i > -1; i--)
        {
            if (Request.Cookies[i].Values["Type"] != null)
            {
                if (Request.Cookies[i].Values["Type"].ToString() == "Massage")
                {
                    AllCookies.Add(Request.Cookies[i]);
                    count++;
                }
            }
        }
        if(count != Count)
        {
            MassageP.Update();
            Count = count;
        }
        else
        {
            AllCookies.Clear();
        }
    }

    void LoadUserControl(
        string HeadColor,
        string HeadLine,
        string Massage,
        string DataTime,
        string Name
        )
    {
        ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/popMassage.ascx");
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
        ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/popMassage.ascx");
        ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml(cookie.Values["HeadColor"].ToString());
        ErroMassage.HeadLine = cookie.Values["HeadText"].ToString();
        ErroMassage.Massage = cookie.Values["MassageText"].ToString();
        ErroMassage.DataTime = cookie.Values["DataTime"].ToString();
        ErroMassage.CookieName = cookie.Name.ToString();
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
                if (Request.Cookies[i].Values["Type"].ToString() == "Massage")
                {
                    LoadUserControl(Request.Cookies[i]);
                }
            }
        }
    }
}