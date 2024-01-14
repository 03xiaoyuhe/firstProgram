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
/// 
/// 
/// <!-- 
/// 
/// 接下来的任务:
///     将Cookie的产生过程封装起来，
///     并编写一个专门用于发送消息的类，
///     将所有消息的发送集成到该类中
///     
/// -->
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
        for (int i = Request.Cookies.Count - 1; i > -1; i--)
        {
            //由于控件刷新过快，导致一定情况下用户无法流畅的关闭提示框
            //可以通过设置判断条件来选择性的刷新
            //可采取的判断条件如：通过查看cookie是否发生变化来选择性的刷新控件
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


    protected void MassageP_Load(object sender, EventArgs e)
    {
    //    foreach (var item in AllCookies)
    //    {
    //        LoadUserControl(item);
    //    }

        for (int i = Request.Cookies.Count - 1; i > -1; i--)
        {
            //由于控件刷新过快，导致一定情况下用户无法流畅的关闭提示框
            //可以通过设置判断条件来选择性的刷新
            //可采取的判断条件如：通过查看cookie是否发生变化来选择性的刷新控件
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