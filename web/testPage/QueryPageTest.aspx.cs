using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

//HtmlGenericControl hgc = (HtmlGenericControl)Page.FindControl(div); 获取ID对应的标签变量

public partial class QueryPage : System.Web.UI.Page
{
    /* 注册侧边栏名称 */
    protected bool isPageLoging = false;

    /// <summary>
    /// 创建导航栏按钮与对应Div关系
    /// </summary>
    protected Dictionary<string, string> navigationBarRelation = new Dictionary<string, string>();

    /// <summary>
    /// 创建侧边栏按钮树对应关系
    /// </summary>
    protected Dictionary<string, string> TreeRelation = new Dictionary<string, string>();
    protected void Page_Load(object sender, EventArgs e)
    {

        // 初始化导航栏与对应功能映射关系
        navigationBarRelation.Clear();
        navigationBarRelation.Add("filtrateBtm", "filtrateSidebar");
        navigationBarRelation.Add("pagingBtm", "PagingSidebar");
        //navigationBarRelation.Add("fenture2", "sidebar2");
        //navigationBarRelation.Add("fenture3", "sidebar3");

        // 初始化按钮树功能映射关系
        TreeRelation.Clear();
        TreeRelation.Add("filtratePrincipal", "filtratePrincipalDiv");
        TreeRelation.Add("PagingSidebarButton2", "PagingSidebarPlaceHolder2");
        TreeRelation.Add("PagingSidebarButton1", "PagingSidebarPlaceHolder1");

        if (!IsPostBack)
        {
            checkLodeSuccess();

            // 初始化功能
            InitDivDisplayMode();
            initTreeButton();
        }
    }

    #region 页面常规加载

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
            Server.Transfer("~/homeTest.aspx", true);
        }
    }


    #endregion

    #region 数组常规方法

    /// <summary>
    /// 查找指定元素在数组中的位置
    /// </summary>
    /// <typeparam name="T">可以转化为字符串的变量</typeparam>
    /// <param name="datas">变量的数组</param>
    /// <param name="data">被查询的值</param>
    /// <returns>
    /// 查询成功返回其索引<br/>
    /// 不成功返回 -1
    /// </returns>
    protected int FindDataIndex<T>(T[] datas, T data)
    {
        for (int i = 0; i < datas.Length; i++)
        {
            if (data.ToString() == datas[i].ToString())
            {
                return i;
            }
        }
        return -1;
    }
    #endregion

    #region 标签常用方法

    protected string classSetToClassString(string[] classSet)
    {
        string classString = "";
        for(int i = 0; i < classSet.Length; i++)
        {
            if(i == 0)
            {
                classString = classString + classSet[i];
            }
            else
            {
                classString = classString + " " + classSet[i];
            }
        }
        return classString;
    }

    #endregion

    #region 常规控制显示PlaceHolder模块


    /// <summary>
    /// 无返回值迭代器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="B"></typeparam>
    protected void foreachDo<T, B>(Func<T, B> func, params object[] datas)
    {

        foreach(T data in datas)
        {
            func((T)data);
        }
    }

    /// <summary>
    /// 判断侧边栏是否已经显示
    /// </summary>
    /// <param name="a">侧边栏的ID</param>
    /// <returns>如果显示则返回true 如果不显示则返回false</returns>
    protected bool checkPlaceHolderIsShow(string a)
    {
        if(a == null) return false;
        if (Session[a].ToString() == "Show"){ return true; }
        else { return false; }
    }

    /// <summary>
    /// 根据控件id得到控件
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private Control getSidebarItemByID(string name)
    {
        object o = this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
        return ((Control)o);
    }

    /// <summary>
    /// 根据多个ID获取对应的前端标签变量数组
    /// </summary>
    /// <param name="IDs">多个ID</param>
    /// <returns>
    /// <b>如果存在返回Control类型数组</b><br/>
    /// <b>如果不存在则返回null</b><br/>
    /// <br/>
    /// <i>(若要使用请转化为对应标签的类型)</i><br/>
    /// <i>(如 Div标签的类型为HtmlGenericControl)</i>
    /// </returns>
    protected Control[] getSidebarItemByID(params string[] IDs)
    {
        Control[] controls = null;
        if (ID.Length == 0) return null;
        controls = new Control[IDs.Length];
        for (int i = 0;i < IDs.Length; i++)
        {
            controls[i] = getSidebarItemByID((string)IDs[i]);
        }
        return controls;
    }

    /// <summary>
    /// 将一个标签设为可见
    /// </summary>
    /// <param name="controls">一个或一组标签</param>
    protected int setSidebarShow(PlaceHolder control)
    {
        if (control == null) { return -1; }
        control.Visible = true;
        Session[control.ID] = "Show";
        return 0;
    }

    /// <summary>
    /// 将一组标签设为可见
    /// </summary>
    /// <param name="controls">一个或一组标签</param>
    /// <returns>
    /// 成功返回0 否则返回-1
    /// </returns>
    protected int setSidebarShow(params PlaceHolder[] controls)
    {
        if (controls == null) { return -1; }

        foreach(PlaceHolder control in controls)
        {
            setSidebarShow(control);
        }
        return 0;
    }

    /// <summary>
    /// 将一组标签设为不可见
    /// </summary>
    /// <param name="controls"></param>
    /// <returns>
    /// 成功返回0 否则返回-1
    /// </returns>
    protected int setSidebarUnShow(params PlaceHolder[] controls)
    {
        if(controls == null){ return -1; }

        foreach (PlaceHolder control in controls)
        {
            setSidebarUnShow(control);
        }
        return 0;
    }

    /// <summary>
    /// 将一个标签设为不可见
    /// </summary>
    /// <param name="controls"></param>
    /// <returns>
    /// 成功返回0 否则返回-1
    /// </returns>
    protected int setSidebarUnShow(PlaceHolder control)
    {
        if (control == null) { return -1; }
        control.Visible = false;
        Session[control.ID] = "UnShow";
        return 0;
    }


    #endregion


    #region 导航栏响应编写

    /// <summary>
    /// 初始化控制显示Div的显示状态
    /// </summary>
    protected void InitDivDisplayMode()
    {
        foreach (KeyValuePair<string, string> item in navigationBarRelation)
        {
            Session[item.Value.ToString()] = "UnShow";
            getSidebarItemByID(item.Value.ToString()).Visible = false;
        }
    }

    /// <summary>
    /// 将所有侧边栏设为不可见
    /// </summary>
    void setAllUnShow()
    {
        foreach(KeyValuePair<string,string> kvp in navigationBarRelation)
        {
            setSidebarUnShow((PlaceHolder)getSidebarItemByID(kvp.Value.ToString()));
        }
    }

    /// <summary>
    /// 将按钮显示样式刷新为未按下状态
    /// </summary>
    /// <param name="controls">一个或多个asp按钮变量</param>
    protected void setButtonPopOff(params Button[] controls)
    {
        foreach (Button control in controls)
        {
            control.CssClass = "fenture1";
        }
    }

    /// <summary>
    /// 将按钮显示样式刷新为按下状态
    /// </summary>
    /// <param name="controls">一个或多个asp按钮变量</param>
    protected void setButtomPopOn(params Button[] controls)
    {
        foreach(Button control in controls)
        {
            control.CssClass = "fenture1OverCleck";
        }
    }

    /// <summary>
    /// 将所有导航栏按钮设为未按下状态
    /// </summary>
    protected void setAllPopOff()
    {
        foreach(KeyValuePair<string ,string> kvp in navigationBarRelation)
        {
            setButtonPopOff((Button)getSidebarItemByID(kvp.Key.ToString()));
        }
    }


    #region 按键响应

    /// <summary>
    /// 导航栏键响应
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void allNavigationBarBtm_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        string divID;
        navigationBarRelation.TryGetValue(button.ID, out divID);

        if (checkPlaceHolderIsShow(divID))
        {
            setSidebarUnShow((PlaceHolder)getSidebarItemByID(divID));
            setAllPopOff();
        }
        else
        {
            setAllUnShow();
            setSidebarShow((PlaceHolder)getSidebarItemByID(divID));
            setAllPopOff();
            setButtomPopOn(button);
        }
    }

    #endregion


    #endregion


    #region 侧边栏按钮树响应编写

    /// <summary>
    /// 初始化侧边栏按钮树
    /// </summary>
    protected void initTreeButton()
    {
        foreach (KeyValuePair<string,string> item in TreeRelation)
        {
            Session[item.Value] = "Unshow";
            getSidebarItemByID(item.Value.ToString()).Visible = false;
        }
    }

    /// <summary>
    /// 侧边栏按钮树点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void TreeButton_Click(object sender, EventArgs e)
    {
        //检查filtratePrincipalDiv是否显示

        Button button = (Button)sender;
        string divID;
        TreeRelation.TryGetValue(button.ID, out divID);
        bool flag = checkPlaceHolderIsShow(divID);
        if (flag)
        {
            setSidebarUnShow((PlaceHolder)getSidebarItemByID(divID));
        }
        else
        {
            setSidebarShow((PlaceHolder)getSidebarItemByID(divID));
        }
    }

    #endregion


    protected void turnBackToHome_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/home.aspx", false);
    }


    void txt_LostFocus(object sender, EventArgs e)
    {
        ((TextBox)sender).Text = "aaa";
    }


}
