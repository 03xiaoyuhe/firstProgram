using DAL;
using Models.PageDataSor;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX.Table;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class OutForDeclareProgremPage : System.Web.UI.Page
    {
        #region 自定义属性

        int Index;

        int chooseYear;
        public int ChooseYear
        {
            get
            {
                if (chooseYear == 0) return chooseYear = DateTime.Now.Year;
                return chooseYear;
            }
            set
            {
                chooseYear = value;
            }
        }

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
                if (Request.QueryString["index"] != null)
                {
                    return int.Parse(Request.QueryString["index"]);
                }
                return 1;
            }
        }
        /// <summary>
        /// 筛选后的信息绑定，如果为null表示未筛选.
        /// </summary>
        string query
        {
            get
            {
                if (Session["query"] == null) return null;
                return Session["query"].ToString();
            }
            set { Session["query"] = value; }
        }

        string SortField
        {
            get
            {
                if (Session["SortField"] == null) Session["SortField"] = "project_id";
                return Session["SortField"].ToString();
            }
            set
            {
                Session["SortField"] = value;
            }
        }


        string TypeSort
        {
            get
            {
                if (Session["TypeSort"] == null) Session["TypeSort"] = "asc";
                return Session["TypeSort"].ToString();
            }
            set
            {
                Session["TypeSort"] = value;
            }
        }
        public int CountSort
        {
            get
            {
                if (CacheGenericity<List<int>>.Data["CountSort"].Count == 0) CacheGenericity<List<int>>.Data["CountSort"].Add(0);
                return CacheGenericity<List<int>>.Data["CountSort"][0];
            }
            set
            {
                //if (CacheGenericity<List<int>>.Data["CountSort"].Count == 0)
                //{
                //    CacheGenericity<List<int>>.Data["CountSort"].Add(value);
                //    return;
                //}
                CacheGenericity<List<int>>.Data["CountSort"][0] = value;
            }
        }

        #endregion

        /// <summary>
        /// 加载筛选的数据库语句，加载到query变量中
        /// 作为分页函数的查询表进行分页功能的使用
        /// </summary>
        /// <param name="dict">传入的筛选数据集</param>
        public void Select(Dictionary<string, HashSet<string>> dict)
        {
            query = "select *from ProjectApplications where ";
            int ans = 0;
            int number = 0;

            foreach (KeyValuePair<string, HashSet<string>> item in dict)
            {
                int count = 0;

                string num = item.Key;
                if (item.Value.Count != 0)
                {
                    if (number != 0)
                    {
                        query += " and ";
                    }
                    query += " (";

                    foreach (string key in item.Value)
                    {
                        if (count != 0)
                        {
                            query += " or ";
                        }
                        query += num + " = " + "'" + key + "'";
                        count++;
                    }

                    number++;
                    query += ") ";

                    ans++;
                }
                else continue;
            }

            if (ans != 0)
            {
                InitSelect(query);
            }
            else if (ans == 0)
            {
                query = null;
            }
        }

        /// <summary>
        /// 加载筛选项
        /// </summary>
        void LoadFiltrate()
        {

            Dictionary<string, string> translation = new Dictionary<string, string>();
            translation.Add("project_level", "项目评级");
            translation.Add("project_youth", "青年项目");
            translation.Add("year(project_time)", "年份");
            translation.Add("project_form", "成果形式");

            Filtrate.AllFiltrateKeyToMean = translation;
            Filtrate.UpdateFiltrate += Select;
            Dictionary<string, HashSet<string>> sons = new Dictionary<string, HashSet<string>>();

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
            foreach (DataRow dr in dt.Rows)
            {
                string timme = DateTime.Parse(dr["project_time"].ToString()).ToString("yyyy");
                hashTime.Add(timme);
            }


            HashSet<string> hashForm = new HashSet<string>();
            DataSet form = DBHelper.Query("select project_form from ProjectApplications group by project_form");
            foreach (DataRow dr in form.Tables[0].Rows)
            {
                hashForm.Add(dr["project_form"].ToString());
            }

            sons.Add("project_level", hashLevel);
            sons.Add("project_youth", hashYouth);
            sons.Add("year(project_time)", hashTime);
            sons.Add("project_form", hashForm);

            Filtrate.AllFiltrate = sons;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //加载表格
            InitSelect(query);
            //LoadeSelect();

            try
            {
                LoadFiltrate();
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

        #region 加载表格数据项
        /// <summary>
        /// 加载未筛选的信息
        /// </summary>
        void InitData()
        {
            Data = PageApart.Apart("ProjectApplications", SortField, PageNum - 1, TypeSort);

        }

        /// <summary>
        /// 通过query加载筛选信息或未筛选信息
        /// </summary>
        /// <param name="query"></param>
        void InitSelect(string query)
        {
            if (query == null)
            {
                Data = PageApart.Apart("ProjectApplications", SortField, PageNum - 1, TypeSort);
                LoadTable();
            }
            else
            {
                Data = PageApart.ApartSelect(query, SortField, PageNum - 1, TypeSort);
                LoadeSelect();
            }

            //Data = PageApart.ApartSelect(query, "project_id", PageNum - 1);

        }

        /// <summary>
        /// 加载筛选后的表格数据
        /// </summary>
        void LoadeSelect()
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
                list.Add("project_name");
                list.Add("project_level");
                list.Add("project_number");
                list.Add("project_category");
                list.Add("project_youth");
                list.Add("project_time");
                list.Add("project_form");

                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("project_id", "ID");
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
                InitData();
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
                massage.HeadText = "WANNING";
                massage.MassageText = "未选择筛选项";
                massage.HeadColor = "Orange";
                massage.PostMassage();
            }
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

                //dataTable = SortTable(dataTable, "project_level", 1);

                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = tableAttribute;
                NewLine.DataCollection = dataTable;
                NewLine.Height = 480;
                NewLine.TableName = "ProjectApplications";
                //NewLine.ShowControl = true;
                //NewLine.ControlASCX = "~/ASCX/Table/ForMyTable/DeletButten.ascx";
                //NewLine.ShowCheck = true;
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
        #endregion

        protected void PlaceHolder1_Load(object sender, EventArgs e)
        {
            InitSelect(query);
            //    InitData();
            //    Loding();
            //    LoadTable();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());




        }
        //排序按钮后端：
        protected void Button4_Click(object sender, EventArgs e)
        {
            SortField = "project_number";
            Page_Load(sender, e);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SortField = "project_level";
            Page_Load(sender, e);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SortField = "project_name";
            Page_Load(sender, e);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SortField = "project_time";
            Page_Load(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CountSort++;
            if (CountSort % 2 == 0)
            {
                TypeSort = "asc";
            }
            else
            {
                TypeSort = "desc";
            }
            Page_Load(sender, e);
        }

    }
}