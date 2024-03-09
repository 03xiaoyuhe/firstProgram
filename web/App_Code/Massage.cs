using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
namespace MyWeb
{
    public enum TimeModo
    {
        Hour,
        Second,
        Minute,
        Day,
    }

    /// <summary>
    /// Massage 的摘要说明
    /// </summary>
    public class Massage
    {

        public string HeadColor;
        public string HeadText;
        public string MassageText;
        public string DataTime;
        public TimeModo timeModo;
        public int HoldTime;

        /// <summary>
        /// <b>构造一个消息，便于产生Cookie</b> <br/>
        /// <br/>
        /// 参数说明:<br/>
        /// "headColor"   >  标题栏颜色 <br/>
        /// "headText"    >  标题栏内容 <br/>
        /// "massageText" >  消息内容 <br/>
        /// "timeModo"    >  消息的时间单位 <br/>
        /// "holdTime"    >  消息销毁的时间
        /// </summary>
        /// <param name="headColor">标题栏颜色</param>
        /// <param name="headText">标题栏内容</param>
        /// <param name="massageText">消息内容</param>
        /// <param name="timeModo">消息的时间单位</param>
        /// <param name="holdTime">消息销毁的时间</param>
        public Massage(
            string headColor = "blue",
            string headText = "Massage",
            string massageText = "",
            TimeModo timeModo = TimeModo.Minute,
            int holdTime = 30
            )
        {
            HeadColor = headColor;
            HeadText = headText;
            MassageText = massageText;
            DataTime = DateTime.Now.ToString();
            HoldTime = holdTime;
        }

        public void PostMassage()
        {
            HttpCookie aCookie = new HttpCookie("Massage" + DataTime);
            aCookie.Values["Type"] = "Massage-1.0";
            aCookie.Values["HeadColor"] = HeadColor;
            aCookie.Values["HeadText"] = HeadText;
            aCookie.Values["DataTime"] = DataTime;
            aCookie.Values["MassageText"] = HttpUtility.UrlEncode(MassageText);

            /// 识别消息的时间单位并设置销毁时间
            switch (timeModo)
            {
                case TimeModo.Day:
                    aCookie.Expires = DateTime.Now.AddDays(HoldTime);
                    break;
                case TimeModo.Second:
                    aCookie.Expires = DateTime.Now.AddSeconds(HoldTime);
                    break;
                case TimeModo.Minute:
                    aCookie.Expires = DateTime.Now.AddMinutes(HoldTime);
                    break;
                case TimeModo.Hour:
                    aCookie.Expires = DateTime.Now.AddHours(HoldTime);
                    break;
            }
            HttpContext.Current.Response.Cookies.Add(aCookie);
        }
    }
}