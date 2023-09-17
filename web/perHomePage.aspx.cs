using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class perMainPage : System.Web.UI.Page
{
    /* 注册侧边栏名称 */
    public string[] SidebarList = new string[4];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SidebarList[0] = "sidebar1";
            SidebarList[1] = "sidebar2";
            SidebarList[2] = "sidebar3";
            SidebarList[3] = "sidebar4";

            Session["sidebar1"] = "UnShow";
            Session["sidebar2"] = "UnShow";
            Session["sidebar3"] = "UnShow";
            Session["sidebar4"] = "UnShow";
        }
    }

    /// <summary>
    /// 判断侧边栏是否已经显示
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    protected bool checkSidebarIsShow(string a)
    {
            if (Session[a].ToString() == "Show")
            {
                return true;
            }
            else { return false; }
    }

    /// <summary>
    /// 将所有侧边栏设为不可见
    /// </summary>
    void setAllUnShow()
    {
        this.sidebar1.Attributes.Add("style", "display:none");
        this.sidebar2.Attributes.Add("style", "display:none");
        this.sidebar3.Attributes.Add("style", "display:none");
        Session["sidebar1"] = "UnShow";
        Session["sidebar2"] = "UnShow";
        Session["sidebar3"] = "UnShow";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void fenture1_Click(object sender, EventArgs e)
    {
        if (checkSidebarIsShow("sidebar1"))
        {
            this.sidebar1.Attributes.Add("style", "display:none");
            Session["sidebar1"] = "UnShow";
            this.fenture1.CssClass = "fenture1";
            this.fenture2.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
        else
        {
            setAllUnShow();
            this.sidebar1.Attributes.Add("style", "display:block");
            Session["sidebar1"] = "Show";
            this.fenture1.CssClass = "fenture1OverCleck";
            this.fenture2.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
    }

    protected void fenture2_Click(object sender, EventArgs e)
    {
        if (checkSidebarIsShow("sidebar2"))
        {
            this.sidebar2.Attributes.Add("style", "display:none");
            Session["sidebar2"] = "UnShow";
            this.fenture1.CssClass = "fenture1";
            this.fenture2.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
        else
        {
            setAllUnShow();
            this.sidebar2.Attributes.Add("style", "display:block");
            Session["sidebar2"] = "Show";
            this.fenture2.CssClass = "fenture1OverCleck";
            this.fenture1.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
    }

    protected void fenture3_Click(object sender, EventArgs e)
    {
        if (checkSidebarIsShow("sidebar3"))
        {
            this.sidebar3.Attributes.Add("style", "display:none");
            Session["sidebar3"] = "UnShow";
            this.fenture1.CssClass = "fenture1";
            this.fenture2.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
        else
        {
            setAllUnShow();
            this.sidebar3.Attributes.Add("style", "display:block");
            Session["sidebar3"] = "Show";
            this.fenture3.CssClass = "fenture1OverCleck";
            this.fenture2.CssClass = "fenture1";
            this.fenture1.CssClass = "fenture1";
        }
    }
}