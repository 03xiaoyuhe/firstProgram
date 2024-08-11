using DAL;
using DAL.DataControl.TableControl;
using DAL.DataControl.ViewControl;
using Models;
using Models.PageDataSor;
using Models.PageDataSor.ForMyTable;
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
    public partial class PersonInformSelectPage : System.Web.UI.Page
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
                if (Session["SortFieldForPeople"] == null) Session["SortFieldForPeople"] = "PEB_ID";
                return Session["SortFieldForPeople"].ToString();
            }
            set
            {
                Session["SortFieldForPeople"] = value;
            }
        }

        /// <summary>
        /// 是否按升序排序
        /// </summary>
        public bool TypeSort
        {
            get
            {
                if (Session["TypeSortForPeople"] == null) Session["TypeSortForPeople"] = "0";
                return Session["TypeSortForPeople"].ToString() == "1" ? true : false;
            }
            set
            {
                Session["TypeSortForPeople"] = (value ? "1" : "0");
            }
        }

        #endregion

        #region 表格基础数据


        string choosedDataID;
        /// <summary>
        /// 复选框缓存
        /// </summary>
        public string ChoosedDataID
        {
            get
            {
                return choosedDataID;
            }
            set
            {
                choosedDataID = value;
            }
        }

        /// <summary>
        /// 表格显示描述缓存
        /// </summary>
        public TableAttribute DataBash
        {

            get
            {
                if (Session["DataBashForPeople"] == null) Session["DataBashForPeople"] = new TableAttribute();
                return Session["DataBashForPeople"] as TableAttribute;
            }
            set
            {
                Session["DataBashForPeople"] = value;
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

        #endregion

        #region 搜索信息数据

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
                if (Session["SearchTargetForPeople"] == null) Session["SearchTargetForPeople"] = "项目名称";
                return Session["SearchTargetForPeople"].ToString();
            }
            set
            {
                Session["SearchTargetForPeople"] = value;
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


        /// <summary>
        /// 查询Where子句缓存
        /// </summary>
        public string WhereString
        {
            get
            {
                if (Session["WhereStringForPeople"] == null) Session["WhereStringForPeople"] = "1 = 1";
                return Session["WhereStringForPeople"].ToString();
            }
            set
            {
                Session["WhereStringForPeople"] = value;
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
            list.Add("PEB_ID");
            list.Add("PEB_Name");
            list.Add("PEB_Sex");
            list.Add("PEB_Birthday");
            list.Add("PEB_Job");
            list.Add("PEB_Title");
            list.Add("PEB_Employer");

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("PEB_ID", "信息ID");
            map.Add("PEB_Name", "姓名");
            map.Add("PEB_Sex", "性别");
            map.Add("PEB_Birthday", "生日");
            map.Add("PEB_Job", "职务");
            map.Add("PEB_Title", "职称");
            map.Add("PEB_Employer", "工作单位");

            TableAttribute tableAttribute = new TableAttribute(
                "PEB_ID",
                "人员信息",
                map,
                list
                );

            DataBash = tableAttribute;
        }

        /// <summary>
        /// 构建筛选查询后的Where子句
        /// </summary>
        /// <param name="dict">传入的筛选数据集</param>
        public void BulidWhereString(Dictionary<string, HashSet<string>> dict)
        {
            WhereString = ProjectViewContron.BuildWhereClause(dict);

            InitData();
            LoadTable();

        }


        /// <summary>
        /// 加载筛选项
        /// </summary>
        void LoadFiltrate()
        {
            Dictionary<string, string> translation = new Dictionary<string, string>();
            translation.Add("year(PEB_Birthday)", "生日");
            translation.Add("PEB_Employer", "工作单位");

            Filtrate.AllFiltrateKeyToMean = translation;
            Filtrate.UpdateFiltrate += BulidWhereString;

            // 加载筛选项内容
            Dictionary<string, HashSet<string>> sons = new Dictionary<string, HashSet<string>>();


            // 立项日期筛选项
            // 查询项目所有结项时间
            DataSet time = (new PeopleControl()).Select(new List<string>() { "year(PEB_Birthday) as EndingDate" }, null, "year(PEB_Birthday)", null, true, null, null);
            DataTable dt = time.Tables[0];
            HashSet<string> hashTime = new HashSet<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string timme = dr["EndingDate"].ToString();
                hashTime.Add(timme);
            }
            sons.Add("year(PEB_Birthday)", hashTime);


            // 成果形式筛选项
            HashSet<string> hashForm = new HashSet<string>();
            DataSet form = (new PeopleControl()).Select(new List<string>() { "PEB_Employer" }, null, "PEB_Employer", null, true, null, null);
            foreach (DataRow dr in form.Tables[0].Rows)
            {
                hashForm.Add(dr["PEB_Employer"].ToString());
            }
            sons.Add("PEB_Employer", hashForm);

            Filtrate.AllFiltrate = sons;

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            InitData();
            LoadTable();

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
            Data = (new PeopleControl()).Select(WhereString, null, SortField, TypeSort, 20, PageNum);
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
                return;
            }
            try
            {
                InitDataAttribute();

                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = DataBash;
                NewLine.DataCollection = dataTable;
                NewLine.Height = 480;
                NewLine.TableName = "ProjectApplications";
                NewLine.ShowControl = true;
                NewLine.ControlASCX = "~/ASCX/Table/ForMyTable/ForPeople/DeletButten.ascx";
                NewLine.DeletButtonClick = DeletButtonClick;
                NewLine.ShowCheck = true;
                DataLoadPlaceHoler.Controls.Clear();
                DataLoadPlaceHoler.Controls.Add(NewLine);
                ChoosedDataID = NewLine.ChoosedDataID;
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

        /// <summary>
        /// 数据显示容器刷新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataLoadPlaceHoler_Load(object sender, EventArgs e)
        {
            InitData();
            LoadTable();
        }


        protected void BtnForSearch_Click(object sender, EventArgs e)
        {

        }


        //排序按钮后端：
        public Dictionary<string, string> TargetTextToField = new Dictionary<string, string>()
        {
            {"姓名", "PEB_Name" },
            { "生日", "PEB_Birthday"},
        };
        protected void btnForSortTarget_Click(object sender, EventArgs e)
        {
            SortField = TargetTextToField[((Button)sender).Text];
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TypeSort = !TypeSort;
            InitData();
            LoadTable();
        }

        /// <summary>
        /// 变更搜索目标项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button7_Click(object sender, EventArgs e)
        {

            SearchTarget = ((Button)sender).Text;
        }


        /// <summary>
        /// 删除按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeletButtonClick(object sender, EventArgs e)
        {
            ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
            choosedDataIDContain.ID = ChoosedDataID;

            int ans = choosedDataIDContain.ChoosedIDs.Count;

            if (ans != 0)
            {
                foreach (string item in choosedDataIDContain.ChoosedIDs)
                {
                    if (
                        !(
                        (new PeopleControl()).Delete(null, PeopleControl.BuildWhereClause(new Dictionary<string, string>() { { "PEB_ID", item } })) >= 1
                        )
                       )
                    {
                        Massage massage1 = new Massage();
                        massage1.MassageText = "人员信息ID为：" + item + "的人员信息删除失败！";
                        massage1.HeadColor = "Red";
                        massage1.HeadText = "ERROR";
                        massage1.PostMassage();
                        ans--;
                    }
                }

                Massage massage12 = new Massage();
                if (ans == choosedDataIDContain.ChoosedIDs.Count)
                {
                    massage12.MassageText = "选择的所有人员信息均删除成功";
                    massage12.HeadText = "Success";
                    massage12.HeadColor = "Blue";
                }
                massage12.PostMassage();

                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Massage massage = new Massage();
                massage.MassageText = "未选择数据删除";
                massage.HeadText = "WANNING";
                massage.HeadColor = "Orange";
                massage.PostMassage();
            }
        }


        #endregion
    }
}