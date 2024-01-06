using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie aCookie = new HttpCookie("Massage"+ DateTime.Now.ToString());
            aCookie.Values["Type"] = "Massage";
            aCookie.Values["HeadColor"] = "Blue";
            aCookie.Values["HeadLine"] = "Success";
            aCookie.Values["DataTime"] = DateTime.Now.ToString();
            aCookie.Values["Massage"] = "添加成功";
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
            HttpCookie ACookie = new HttpCookie("Massage" + DateTime.Now.ToString());
            ACookie.Values["Type"] = "Massage";
            ACookie.Values["HeadColor"] = "Blue";
            ACookie.Values["HeadLine"] = "Success";
            ACookie.Values["DataTime"] = DateTime.Now.ToString();
            ACookie.Values["Massage"] = "添加成功";
            ACookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(ACookie);
        }
    }
}