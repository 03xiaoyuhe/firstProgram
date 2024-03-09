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
        Response.Write("<div>Path:"+ path +"</div>");
        EXEHelper a = new EXEHelper();
        a.path = path+@"\exeFile\test\main.exe";
        a.Arguments = "hellow";
        string data = a.OperationReturn();
        Response.Write(data);
    }
}