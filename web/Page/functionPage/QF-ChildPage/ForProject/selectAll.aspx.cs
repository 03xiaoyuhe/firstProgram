using DAL;
using DAL.DataControl.TableControl;
using Models;
using Models.PageDataSor;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Caching;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using WebForm.ASCX;
using WebForm.ASCX.Table;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class selectAll1 : System.Web.UI.Page
    {
        #region 自定义属性

        // 排序内容

        #region 排序相关属性

        /// <summary>
        /// 排序的字段
        /// </summary>
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

        /// <summary>
        /// 是否按升序排序
        /// </summary>
        bool TypeSort
        {
            get
            {
                if (Session["TypeSort"] == null) Session["TypeSort"] = "1";
                return Session["TypeSort"].ToString() == "1" ? true : false;
            }
            set
            {
                Session["TypeSort"] = value ? "1" : "0";
            }
        }

        #endregion

        #region 表格基础数据

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

        #endregion


        int Index;

        /// <summary>
        /// 表格显示描述缓存
        /// </summary>
        public TableAttribute DataBash
        {

            get
            {
                if (Session["DataBash"] == null) Session["DataBash"] = new TableAttribute();
                return Session["DataBash"] as TableAttribute;
            }
            set
            {
                Session["DataBash"] = value;
            }
        }

        public Dictionary<string, string> SearchTargetToDataLable = new Dictionary<string, string>()
        {
            {"项目名称", "project_name" },
            {"电话号码", "project_name" },
        };

        /// <summary>
        /// 搜索框所选内容缓存
        /// </summary>
        public string SearchTarget
        {

            get
            {
                if (Session["SearchTarget"] == null) Session["SearchTarget"] = "项目名称";
                return Session["SearchTarget"].ToString();
            }
            set
            {
                Session["SearchTarget"] = value;
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

        #endregion


        #region 页面加载

        /// <summary>
        /// 初始化表格显示信息
        /// </summary>
        public void InitDataAttribute()
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

            DataBash = tableAttribute;
        }

        /// <summary>
        /// 加载筛选的数据库语句，加载到query变量中
        /// 作为分页函数的查询表进行分页功能的使用
        /// </summary>
        /// <param name="dict">传入的筛选数据集</param>
        public void Select(Dictionary<string, HashSet<string>> dict)
        {

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
            Data = ProjectControl.Select(null, SortField, TypeSort, 20, PageNum);
        }

        /// <summary>
        /// 通过query加载筛选信息或未筛选信息
        /// </summary>
        /// <param name="query"></param>
        void InitSelect(string query)
        {
            if (query == null)
            {
                Data = ProjectControl.Select(null, SortField, TypeSort, 20, PageNum);
                LoadTable();
            }
            else
            {
                Data = ProjectControl.Select(null, SortField, TypeSort, 20, PageNum);
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
                InitDataAttribute();
                InitData();
                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = DataBash;
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
                InitDataAttribute();

                //dataTable = SortTable(dataTable, "project_level", 1);

                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = DataBash;
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
        #endregion

        #endregion



        #region 事件定义
        protected void PlaceHolder1_Load(object sender, EventArgs e)
        {
            InitSelect(query);
            //    InitData();
            //    Loding();
            //    LoadTable();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string Lable = "";
            foreach (KeyValuePair<string, string> keyValuePair in DataBash.LineToMean)
            {
                if(keyValuePair.Value == SearchTarget)
                {
                    Lable = keyValuePair.Key;
                    break;
                }
            }
            

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
            try
            {
                NewLine.DataCollection = DAL.ForSelect.Select(DataBash.DataBaseName, Lable, TextBox1.Text).Tables[0];
            }
            catch
            {
                NewLine.DataCollection = new DataTable();
            }
            NewLine.Height = 480;
            NewLine.TableName = "ProjectApplications";
            NewLine.ShowControl = true;
            NewLine.ControlASCX = "~/ASCX/Table/ForMyTable/DeletButten.ascx";
            NewLine.ShowCheck = true;
            PlaceHolder1.Controls.Clear();
            PlaceHolder1.Controls.Add(NewLine);

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
            if (CountSort  %2 == 0)
            {               
                TypeSort = "asc";
            }
            else
            {
                TypeSort = "desc";
            }
            Page_Load(sender, e);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            SearchTarget = ((Button)sender).Text;
        }

        #endregion
    }
}

        ///// <summary>
        ///// 对DataTable排序的函数
        ///// </summary>
        ///// <param name="dt">表</param>
        ///// <param name="values">需要排序的字段</param>
        ///// <param name="ans">正序0，倒序非0</param>
        ///// <returns></returns>
        //static public DataTable SortTable(DataTable dt,string values,int ans)
        //{
        //    DataTable dtCopy = dt.Copy();
           
        //    DataView dv = dt.DefaultView;
        //    if(ans == 0)
        //    {
        //        dv.Sort = values;
        //    }
        //    else
        //    {
        //        dv.Sort = values + " DESC";
        //    }
            
        //    dtCopy = dv.ToTable();

        //    return dtCopy;
        //}
        
