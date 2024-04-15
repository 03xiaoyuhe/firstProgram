using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX;
using WebForm.ASCX.Table;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class selectAll1 : System.Web.UI.Page
    {
        #region 自定义属性

        int Index;

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



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int a;
                if (Request.QueryString["index"] != null) a = int.Parse(Request.QueryString["index"]);
                else a = 1;
                if (a > 0)
                {
                    aaa.Index = a;
                    PageNum = a;
                }
            }
            InitData();
            Loding();
            LoadTable();
        }

        void InitData()
        {
            Data = PageApart.Apart("ProjectApplications", "project_id", PageNum - 1);
        }

        void Loding()
        {
            Loading NewLine = (Loading)LoadControl("~/ASCX/Loading.ascx");
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
        list.Add("team_id");
        list.Add("project_name");
        list.Add("project_level");
        list.Add("project_number");
        list.Add("project_category");
        list.Add("project_youth");
        list.Add("project_research");
        list.Add("project_view");
        list.Add("project_References");
        list.Add("project_time");
        list.Add("project_form");
        //list.Add("proposal_number");
        //list.Add("project_title");
        //list.Add("project_description");
        //list.Add("team_id");
        //list.Add("achievement_form");
        //list.Add("achievement_brief");

        Dictionary<string, string> map = new Dictionary<string, string>();
        map.Add("team_id", "小队id ");
        map.Add("project_name", "项目名称");
        map.Add("project_level", "项目评级");
        map.Add("project_number", "立项编号");
        map.Add("project_category", "项目类别");
        map.Add("project_youth", "是否符合青年项目申报条件");
        map.Add("project_research", "本项目国内外研究现状述评，选题意义与价值");
        map.Add("project_view", "本项目研究的主要观点等");
        map.Add("project_References", "主要参考文献");
        map.Add("project_time", "项目完成时间");
        map.Add("project_form", "成果形式");

        //map.Add("proposal_number", "立项编号");
        //map.Add("project_title", "项目主题");
        //map.Add("project_description", "项目描述");
        //map.Add("team_id", "小队id");
        //map.Add("achievement_form", "成果形式");
        //map.Add("achievement_brief", "成果简述");

            TableAttribute tableAttribute = new TableAttribute(
                "project_id",
                "项目信息",
                map,
                list
                );
            MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
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
}