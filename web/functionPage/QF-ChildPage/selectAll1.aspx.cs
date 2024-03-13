using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Models;
using System.Web.UI.WebControls;
public partial class test : System.Web.UI.Page
{

    #region 自定义属性

    string searchString;
    /// <summary>
    /// 搜索框字符串
    /// </summary>
    public string SearchSting
    {
        get
        {
            return searchString;
        }
        set
        {
            searchString = value;
        }
    }

    string searchCommend;
    /// <summary>
    /// 查询命令
    /// </summary>
    public string SearchCommend
    {
        get
        {
            if (searchCommend == null)
            {
                if (SearchSting != null)
                {
                    searchCommend = SearchSting;
                }
                else
                {
                    searchCommend = "";
                }
            }
            return searchCommend;
        }
    }

    DataSet ds;
    public DataSet Data
    {
        get
        {
            return ds;
        }
        set
        {
            ds = value;
        }
    }

    int pageNum = 0;
    public int PageNum
    {
        get
        {
            return pageNum;
        }
        set
        {
            pageNum = value;
        }
    }

    #endregion


    //最大页码
    public int maxPage = 3;
    //页数
    int PageSize = 50;

    protected void Page_Load(object sender, EventArgs e)
    {
        int currentPage = 1;
        if (int.TryParse(Request["currentPage"] + "", out currentPage))
        {
        }

        if (currentPage < 1) currentPage = 1;

        if (!IsPostBack)
        {
            PageNum = Convert.ToInt32(Request.QueryString["currentPage"]);
        }
        InitData();
        Loding();
        LoadTable();
        Label1.Text = (PageNum + 1).ToString();
    }

    void InitData()
    {
        Data = PageApart.Apart("ProjectApplications", "project_id", PageNum);
    }

    void Loding()
    {
        ASCX_Loading NewLine = (ASCX_Loading)LoadControl("~/ASCX/Loading.ascx");
        PlaceHolder1.Controls.Clear();
        PlaceHolder1.Controls.Add(NewLine);
    }


    void LoadTable()
    {
        DataTable dataTable;
        try
        {
            dataTable = Data.Tables[0];
        }
        catch
        {
            dataTable = null;
        }
        List<string> list = new List<string>();
        list.Add("proposal_number");
        list.Add("project_title");
        list.Add("project_description");
        list.Add("team_id");
        list.Add("achievement_form");
        list.Add("achievement_brief");

        Dictionary<string, string> map = new Dictionary<string, string>();
        map.Add("proposal_number", "立项编号");
        map.Add("project_title", "项目主题");
        map.Add("project_description", "项目描述");
        map.Add("team_id", "小队id");
        map.Add("achievement_form", "成果形式");
        map.Add("achievement_brief", "成果简述");

        TableAttribute tableAttribute = new TableAttribute(
            "project_id",
            "项目信息",
            map,
            list
            );
        ASCX_Table_Table NewLine = (ASCX_Table_Table)LoadControl("~/ASCX/Table/Table.ascx");
        NewLine.TableBase = tableAttribute;
        NewLine.DataCollection = dataTable;
        NewLine.Height = 400;
        NewLine.TableName = "ProjectApplications";
        PlaceHolder1.Controls.Clear();
        PlaceHolder1.Controls.Add(NewLine);
    }

    protected void PlaceHolder1_Load(object sender, EventArgs e)
    {

    }
}