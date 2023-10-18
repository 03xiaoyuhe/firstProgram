using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testPage_Default : System.Web.UI.Page
{
    public string outputString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            test();
            this.HyperLink1.Text = outputString;
        }
    }
    public void test()
    {
        ///放置测试代码
        ///并将输出结果转化为字符串赋给outputString
        string Out = "hhhh";
        outputString = Out;

    }
}