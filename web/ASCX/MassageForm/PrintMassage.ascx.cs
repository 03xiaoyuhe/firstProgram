using System;
using System.Collections.Generic;
using System.Web;

namespace WebForm.ASCX.MassageForm
{
    public partial class PrintMassageForm : System.Web.UI.UserControl
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
            MassageBox ErroMassage = (MassageBox)LoadControl("~/ASCX/MassageForm/MassageBox.ascx");
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
            MassageBox ErroMassage = (MassageBox)LoadControl("~/ASCX/MassageForm/MassageBox.ascx");
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
}