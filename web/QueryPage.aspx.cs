using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QueryPage : System.Web.UI.Page
{
    /* 注册侧边栏名称 */
    public string[] SidebarList = new string[4];
    protected bool isPageLoging = false;
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
            Session["filtratePrincipalDiv"] = "unShow";
            checkLodeSuccess();
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
    /// 确保页面在登陆状态下访问
    /// </summary>
    void checkLodeSuccess()
    {
        if (Session["loginSuccess"] != null)
        {
            if (Session["loginSuccess"].ToString() == "success")
            {
                isPageLoging = true;
            }
        }

        if (!isPageLoging)
        {
            Server.Transfer("~/home.aspx", true);
        }
    }

    /// <summary>
    /// 将所有侧边栏设为不可见
    /// </summary>
    void setAllUnShow()
    {
        this.filtrateSidebar.Attributes.Add("style", "display:none");
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
    protected void filtrateBtm_Click(object sender, EventArgs e)
    {
        if (checkSidebarIsShow("sidebar1"))
        {
            this.filtrateSidebar.Attributes.Add("style", "display:none");
            Session["sidebar1"] = "UnShow";
            this.filtrateBtm.CssClass = "fenture1";
            this.fenture2.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
        else
        {
            setAllUnShow();
            this.filtrateSidebar.Attributes.Add("style", "display:block");
            Session["sidebar1"] = "Show";
            this.filtrateBtm.CssClass = "fenture1OverCleck";
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
            this.filtrateBtm.CssClass = "fenture1";
            this.fenture2.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
        else
        {
            setAllUnShow();
            this.sidebar2.Attributes.Add("style", "display:block");
            Session["sidebar2"] = "Show";
            this.fenture2.CssClass = "fenture1OverCleck";
            this.filtrateBtm.CssClass = "fenture1";
            this.fenture3.CssClass = "fenture1";
        }
    }


    protected void fenture3_Click(object sender, EventArgs e)
    {
        if (checkSidebarIsShow("sidebar3"))
        {
            this.sidebar3.Attributes.Add("style", "display:none");
            Session["sidebar3"] = "UnShow";
            this.filtrateBtm.CssClass = "fenture1";
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
            this.filtrateBtm.CssClass = "fenture1";
        }
    }

    protected void turnBackToHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/home.aspx", false);
    }

    protected void filtratePrincipal_Click(object sender, EventArgs e)
    {
        //检查filtratePrincipalDiv是否显示
        bool flag = checkSidebarIsShow("filtratePrincipalDiv");

        if (!flag)
        {
            Session["filtratePrincipalDiv"] = "Show";
            this.filtratePrincipalDiv.Attributes.Add("style", "dispaly:block");
        }
        else
        {
            Session["filtratePrincipalDiv"] = "UnShow";
            this.filtratePrincipalDiv.Attributes.Add("style", "dispaly:none");
        }
    }
}