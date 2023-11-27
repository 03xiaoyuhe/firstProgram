using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class WorkerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void BtmLogin_Click(object sender, EventArgs e)
    {
        string a = this.userPwd.Text.ToString();
        string b = this.userPwd.Text.ToString();
        workerLogin Workerlogin = new workerLogin();
        Workerlogin.UID = a;
        Workerlogin.Password = b;
    }
}