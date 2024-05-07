using DAL;
using Models;
using Models.PageDataSor.Filtrate;
using Models.PageDataSor;
using System;
using System.Collections.Generic;
using System.Data;
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

        public int PageNum
        {
            get
            {
                if(Request.QueryString["index"]!= null)
                {
                    return int.Parse(Request.QueryString["index"]);
                }
                return 1;
            }
        }

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
            Loding();
            LoadTable();

            try
            {
                Dictionary<string,string> translation = new Dictionary<string,string>();
                translation.Add("project_level", "项目评级");
                translation.Add("project_project_youth", "青年项目");
                translation.Add("project_time", "年份");
                translation.Add("project_form", "成果形式");

                Filtrate.AllFiltrateKeyToMean = translation;
                Dictionary<string,HashSet<string>> sons = new Dictionary<string,HashSet<string>>();

                HashSet<string> hashLevel = new HashSet<string>();
                hashLevel.Add("A");
                hashLevel.Add("B");
                hashLevel.Add("C");
                hashLevel.Add("D");
                hashLevel.Add("E");

                HashSet<string> hashYouth = new HashSet<string>();
                hashYouth.Add("是");
                hashYouth.Add("否");

                HashSet<string> hashTime = new HashSet<string>();
                DataSet time = DBHelper.Query("select project_time from ProjectApplications group by project_time");
                DataTable dt = time.Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    string timme = DateTime.Parse(dr["project_time"].ToString()).ToString("yyyy");
                    hashTime.Add(timme);
                }
                
                
                HashSet<string> hashForm = new HashSet<string>();
                hashForm.Add("论文");
                hashForm.Add("书籍");
                hashForm.Add("软件");
                hashForm.Add("网站");

                sons.Add("project_level", hashLevel);
                sons.Add("project_project_youth", hashYouth);
                sons.Add("project_time", hashTime);
                sons.Add("project_form", hashForm);

                Filtrate.AllFiltrate = sons;

                Massage massage = new Massage();
                massage.MassageText = "";
                foreach (HashSet<string> key in Filtrate.GetChoosed.Values)
                {
                    foreach (string key2 in key)
                    {
                        massage.MassageText += key2;
                    }
                }
                massage.PostMassage();

            }
            catch
            {
                Massage massage = new Massage();
                massage.HeadText = "ERROR";
                massage.HeadColor = "Red";
                massage.MassageText = "出现异常，无法执行筛选操作，请联系工作人员";
                massage.PostMassage();
            }

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
            try
            {
                List<string> list = new List<string>();
                //list.Add("user_phone");
                list.Add("project_name");
                list.Add("project_level");
                list.Add("project_number");
                list.Add("project_category");
                list.Add("project_youth");
                list.Add("project_time");
                list.Add("project_form");

                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("project_id", "ID");
                //map.Add("user_phone", "负责人电话号码");
                map.Add("project_name", "项目名称");
                map.Add("project_level", "项目评级");
                map.Add("project_number", "立项编号");
                map.Add("project_category", "项目类别");
                map.Add("project_youth", "青年项目");
                map.Add("project_time", "项目完成时间");
                map.Add("project_form", "成果形式");

                TableAttribute tableAttribute = new TableAttribute(
                    "project_id",
                    "项目信息",
                    map,
                    list
                    );

                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = tableAttribute;
                NewLine.DataCollection = dataTable;
                NewLine.Height = 480;
                NewLine.TableName = "ProjectApplications";
                NewLine.ShowControl = true;
                NewLine.ControlASCX = "~/ASCX/Table/ForMyTable/DeletButten.ascx";
                NewLine.ShowCheck = true;
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(NewLine);
            }
            catch
            {
                Massage massage = new Massage();
                massage.HeadColor = "Red";
                massage.HeadText = "ERROR";
                massage.MassageText = "无法显示全部信息，请联系工作人员";
                massage.PostMassage();
            }
            



        }

        protected void PlaceHolder1_Load(object sender, EventArgs e)
        {
            InitData();
            Loding();
            LoadTable();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());




        }
    }
}