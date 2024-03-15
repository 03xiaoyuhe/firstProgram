using System;

namespace WebForm.ASCX
{
    public partial class Timer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Interval = 1000;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            timeLock.Text = DateTime.Now.ToString();
        }
    }
}