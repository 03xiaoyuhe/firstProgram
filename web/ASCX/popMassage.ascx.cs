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
    DateTime? start = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(start == null)
        {
            start = DateTime.Now;
        }
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
    [Description("错误信息"), Category("自定义属性")]
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


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        DateTime timeB = DateTime.Now;
        TimeSpan ts = (TimeSpan)(timeB - start);
        string time = ts.TotalSeconds.ToString();
        second.Text = time;
    }
}
