using DAL;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class ProgramDataShow : System.Web.UI.Page
    {
        public string TableName
        {
            get
            {
                //return tableName; 
                return Request.QueryString["tablename"];
            }
            //set { tableName = value; }
        }

        //static string idLable;
        public string IdLable
        {
            get { return Request.QueryString["idlable"]; }
            //set
            //{
            //    idLable = value;
            //}
        }

        //static string id;
        public string Id
        {
            get
            {
                return Request.QueryString["id"];
            }
            //set
            //{
            //    id = value;
            //}
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            //List<DataForParter> aaa = new List<DataForParter>();
            //aaa.Add(new DataForParter());
            //aaa.Add(new DataForParter());
            //aaa.Add(new DataForParter());
            //aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            ////aaa.Add(new DataForParter());
            //ProgremInf.DataForParts= aaa;

            //将项目表显示在ds中。
            DataSet dataSet = new DataSet();
            dataSet = TableSelect.Select(TableName, IdLable, Id);
            DataTable ds = dataSet.Tables[0];
            DataRow dl = ds.Rows[0];

            //将用户信息表显示在dt中。
            DataSet dataSetUser = new DataSet();
            dataSetUser = TableSelect.UserSelect(Id);
            DataTable dt = dataSetUser.Tables[0];
            DataRow dp = dt.Rows[0];



            //项目论证信息的三个字段
            DataForDoc dataForDoc = new DataForDoc();
            dataForDoc.ProjectIntroduce = dl["project_research"].ToString();
            dataForDoc.ProjectMainIdea = dl["project_view"].ToString();
            dataForDoc.ProjectAhead = dl["project_References"].ToString();

            List<DataForParter> dataForParters = new List<DataForParter>();
            dataForParters.Add(new DataForParter());

            DataForThinking dataForThinking = new DataForThinking();

            DataForAdm dataForAdm = new DataForAdm();
            dataForAdm.AdmName = dp["user_name"].ToString();
            dataForAdm.AdmBorn = dp["user_date"].ToString();
            dataForAdm.AdmSex = dp["user_sex"].ToString();
            dataForAdm.AdmEmail = dp["user_email"].ToString();
            dataForAdm.AdmAdmPhone = dp["user_office_number"].ToString();
            dataForAdm.AdmMar = dp["user_speciality"].ToString();
            dataForAdm.AdmOrd = dp["user_position"].ToString();
            dataForAdm.AdmJobWhere = dp["user_workplace"].ToString();
            dataForAdm.AdmMajBest = dp["user_research"].ToString();
            dataForAdm.AdmNowDo = dp["user_research_now"].ToString();
            dataForAdm.AdmOrdName = dp["user_title"].ToString();
            dataForAdm.AdmPhone = dp["user_number"].ToString();
            dataForAdm.AdmPhontWhere = dp["user_address"].ToString();
            dataForAdm.IsYoungProjrem = dl["project_youth"].Equals(true);

            ProgromBaseData progromBaseData = new ProgromBaseData(
                dl["project_name"].ToString(),
                dl["project_category"].ToString(),
                dl["project_time"].ToString(),
                dl["project_form"].ToString(),
                dataForAdm,
                dataForParters,
                dataForDoc,
                dataForThinking
                );

            ProgremInf.ProgromBaseDatas = progromBaseData;

        }
    }
}