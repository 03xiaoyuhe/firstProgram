using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EXE;

public partial class test : System.Web.UI.Page
{
    string path = System.AppDomain.CurrentDomain.BaseDirectory;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<div>absPath:"+ path +"</div>");
        EXEHelper a = new EXEHelper();
        a.path = path + @"ExeFile\test\main.exe";
        a.arguments = "hellow";
        Response.Write("<div>absPath:" + a.OperationReturn() + "</div>");
    }
}