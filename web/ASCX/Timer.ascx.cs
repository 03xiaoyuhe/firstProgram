using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Timer : System.Web.UI.UserControl
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