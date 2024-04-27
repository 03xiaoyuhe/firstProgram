using Antlr.Runtime.Misc;
using DAL;
using Models;
using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.ProgremData;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class ForTest : System.Web.UI.Page
    {


        public string Id
        {
            get
            {
                if (Session["ID"] == null)
                {
                    return "22010105";
                }
                return Session["ID"].ToString();
            }

            set
            {
                Session["ID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute = new DataTableControlAttribute<DataTableLineArgs>();

            dataTableControlAttribute.ControlName = "测试完成";
            dataTableControlAttribute.DataTableControls += func;
            dataTableControlAttribute.DataTableControls += func2;
           
            List<DataTableControlAttribute<DataTableLineArgs>> customControls = new List<DataTableControlAttribute<DataTableLineArgs>>();
            customControls.Add(dataTableControlAttribute);


            DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute1 = new DataTableControlAttribute<DataTableLineArgs>();
            dataTableControlAttribute1.ControlName = "拓展性测试";
            dataTableControlAttribute1.DataTableControls += func1;
            customControls.Add(dataTableControlAttribute1);

            Test.CustomControls = customControls;
            BodyLine1.CustomControls = customControls;

            #region


                //将项目表显示在ds中。Id
                DataSet dataSet = new DataSet();
                dataSet = TableSelect.Select("ProjectApplications", "project_id", Id);
                DataTable ds = dataSet.Tables[0];
                DataRow dl = ds.Rows[0];

                ////将用户信息表显示在dt中。
                //DataSet dataSetUser = new DataSet();
                ////dataSetUser = TableSelect.UserSelect(Id);
                //DataTable dt = dataSetUser.Tables[0];
                //DataRow dp = dt.Rows[0];



                //项目论证信息的三个字段
                DataForDoc dataForDoc = new DataForDoc();
                dataForDoc.ProjectIntroduce = dl["project_research"].ToString();
                dataForDoc.ProjectMainIdea = dl["project_view"].ToString();
                dataForDoc.ProjectAhead = dl["project_References"].ToString();

                List<DataForParter> dataForParters = new List<DataForParter>();
                dataForParters.Add(new DataForParter());

                DataForThinking dataForThinking = new DataForThinking();

                DataForAdm dataForAdm = new DataForAdm();
                //dataForAdm.AdmName = dp["user_name"].ToString();
                //dataForAdm.AdmBorn = dp["user_date"].ToString();
                //dataForAdm.AdmSex = dp["user_sex"].ToString();
                //dataForAdm.AdmEmail = dp["user_email"].ToString();
                //dataForAdm.AdmAdmPhone = dp["user_office_number"].ToString();
                //dataForAdm.AdmMar = dp["user_speciality"].ToString();
                //dataForAdm.AdmOrd = dp["user_position"].ToString();
                //dataForAdm.AdmJobWhere = dp["user_workplace"].ToString();
                //dataForAdm.AdmMajBest = dp["user_research"].ToString();
                //dataForAdm.AdmNowDo = dp["user_research_now"].ToString();
                //dataForAdm.AdmOrdName = dp["user_title"].ToString();
                //dataForAdm.AdmPhone = dp["user_number"].ToString();
                //dataForAdm.AdmPhontWhere = dp["user_address"].ToString();
                //dataForAdm.IsYoungProjrem = dl["project_youth"].Equals(true);

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

                TableAttribute tableAttribute = new TableAttribute();
                tableAttribute.IDLable = "project_id";
                tableAttribute.LineToShow.Add("project_id");
                //ProgremInf.ProgromBaseDatas = progromBaseData;

                BodyLine1.DataForALine = dl;
                BodyLine1.TableAttribute = tableAttribute;
            


            #endregion



        }



        void func(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage(); ; ;
            massage.MassageText = "asdfsadfasdfasdf\n";
            massage.MassageText += ((Button)sender).Text + "\n";
            massage.PostMassage();

            //DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute = new DataTableControlAttribute<DataTableLineArgs>();

            //dataTableControlAttribute.ControlName = "测试完成";
            //dataTableControlAttribute.DataTableControls += func;
            //List<DataTableControlAttribute<DataTableLineArgs>> customControls = new List<DataTableControlAttribute<DataTableLineArgs>>();
            //customControls.Add(dataTableControlAttribute);


            //DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute1 = new DataTableControlAttribute<DataTableLineArgs>();
            //dataTableControlAttribute1.ControlName = "拓展性测试";
            //dataTableControlAttribute1.DataTableControls += func1;
            //customControls.Add(dataTableControlAttribute1);

            //Test.CustomControls = customControls;
            //BodyLine1.CustomControls = customControls;

            Session["ID"] = "22010106";
        }


        void func2(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage(); ; ;
            massage.MassageText = "酷酷酷酷酷酷\n";
            massage.MassageText += ((Button)sender).Text + "\n";
            massage.PostMassage();

            //DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute = new DataTableControlAttribute<DataTableLineArgs>();

            //dataTableControlAttribute.ControlName = "测试完成";
            //dataTableControlAttribute.DataTableControls += func;
            //List<DataTableControlAttribute<DataTableLineArgs>> customControls = new List<DataTableControlAttribute<DataTableLineArgs>>();
            //customControls.Add(dataTableControlAttribute);


            //DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute1 = new DataTableControlAttribute<DataTableLineArgs>();
            //dataTableControlAttribute1.ControlName = "拓展性测试";
            //dataTableControlAttribute1.DataTableControls += func1;
            //customControls.Add(dataTableControlAttribute1);

            //Test.CustomControls = customControls;
            //BodyLine1.CustomControls = customControls;

            Session["ID"] = "22010106";
        }


        void func1(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage();
            massage.HeadText = "Test";
            massage.HeadColor = "red";
            massage.MassageText = e.LineNo.ToString() + "\n";
            massage.MassageText += ((Button)sender).Text + "\n";
            massage.PostMassage();
        }
    }
}