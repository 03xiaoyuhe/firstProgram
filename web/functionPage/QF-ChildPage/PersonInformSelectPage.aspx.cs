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
    public partial class PersonInformSelectPage : System.Web.UI.Page
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
                if (Request.QueryString["index"] != null)
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


        }

        void InitData()
        {

            DataSet dataSet = DAL.DBHelper.Query("select Id,UseName,UserDate,UserSex,UserPosition from UserInfor;");

            Data = dataSet;
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
                //将重名信息加载到PlaceHolder1
                List<string> listInfor = new List<string>();
                listInfor.Add("Id");
                listInfor.Add("UseName");
                listInfor.Add("UserDate");
                listInfor.Add("UserSex");
                listInfor.Add("UserPosition");


                Dictionary<string, string> mapInfor = new Dictionary<string, string>();
                mapInfor.Add("Id", "用户编号");
                mapInfor.Add("UseName", "姓名");
                mapInfor.Add("UserDate", "生日");
                mapInfor.Add("UserSex", "性别");
                mapInfor.Add("UserPosition", "职务");


                TableAttribute tableAttribute = new TableAttribute(
                    "Id",
                    "重名信息",
                    mapInfor,
                    listInfor
                    );

                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = tableAttribute;
                NewLine.DataCollection = dataTable;
                NewLine.Height = 500;
                NewLine.TableName = "ProjectApplications";
                NewLine.ShowControl = true;
                NewLine.ControlASCX = "~/ASCX/Table/ForMyTable/DeletButten.ascx";
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

        }
    }
}