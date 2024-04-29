using Antlr.Runtime.Misc;
using Models;
using Models.PageDataSor;
using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.ProgremData;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX.Table;

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
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            DataTableControlAttribute dataTableControlAttribute = new DataTableControlAttribute();

            dataTableControlAttribute.ControlName = "测试完成";
            dataTableControlAttribute.DataTableControls += func;
            List<DataTableControlAttribute> customControls = new List<DataTableControlAttribute>();
            customControls.Add(dataTableControlAttribute);


            DataTableControlAttribute dataTableControlAttribute1 = new DataTableControlAttribute();
            dataTableControlAttribute1.ControlName = "拓展性测试";
            dataTableControlAttribute1.DataTableControls += func1;

            dataTableControlAttribute1.DataTableControls += func2;
            customControls.Add(dataTableControlAttribute1);

            Test.CustomControls = customControls;
            BodyLine1.CustomControls = customControls;

            #region


                //将项目表显示在ds中。Id
                DataSet dataSet = new DataSet();
                //dataSet = TableSelect.Select("ProjectApplications", "project_id", Id);
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



            //D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\Table\ForMyTable\DeletButten.ascx
            //D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\Table\ForDataTable\MyButton.ascx
            Control control = LoadControl("~\\ASCX\\ProgramInform\\ProgramAdd.ascx");
            control.ID = "aaa";
            //PlaceHolder1.Controls.Add(control);
            //D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\ProgramInform\ProgramShow.ascx
        }



        void func(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage();
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
       


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件 choose为文件上传框ID
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(FileUpload1.FileName).ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls" && IsXls != ".csv")
            {
                Response.Write("<script>alert('只可以选择表格文件')</script>");
                return;//当选择的不是Excel文件时,返回
            }
            string filename = FileUpload1.FileName;              //获取Excel文件名  DateTime日期函数

            string savePath = Server.MapPath($"~\\uploadfiles\\{DateTime.Now.ToFileTime()}" + filename);//Server.MapPath 获得虚拟服务器相对路径 自己也可以写成绝对路径
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上  这里保存在本地uploadfiles文件中
            string saveErroPath = Server.MapPath($"~\\uploadfiles\\erro{DateTime.Now.ToFileTime()}" + filename);
            Dictionary<string,bool> list1 = new Dictionary<string, bool>();
            list1.Add("ID", true);
            list1.Add("负责人电话号码", true);
            list1.Add("项目名称", true);
            list1.Add("项目评级", true);
            list1.Add("立项编号", true);
            list1.Add("项目类别", true);
            list1.Add("是否符合青年项目申报条件", true);
            list1.Add("项目完成时间", true);
            list1.Add("成果形式", true);

            Dictionary<string, string> map1 = new Dictionary<string, string>();
            map1.Add( "ID","project_id");
            map1.Add("负责人电话号码", "user_phone");
            map1.Add( "项目名称", "project_name");
            map1.Add( "项目评级", "project_level");
            map1.Add( "立项编号", "project_number");
            map1.Add( "项目类别", "project_category");
            map1.Add( "是否符合青年项目申报条件", "project_youth");
            map1.Add("项目完成时间", "project_time");
            map1.Add("成果形式", "project_form");

            ExcelRead excelRead = new ExcelRead();
            excelRead.Attribute = list1;
            excelRead.ExcelHeadLineData = map1;
            excelRead.InputExcelPath = savePath;
            excelRead.ErroPutExcelPath = saveErroPath;


            int a = 0;
            /// 放置读取代码
            DataTable dataTable = excelRead.LoadExcel(out a);



            List<string> list = new List<string>();
            list.Add("project_id");
            list.Add("user_phone");
            list.Add("project_name");
            list.Add("project_level");
            list.Add("project_number");
            list.Add("project_category");
            list.Add("project_youth");
            list.Add("project_time");
            list.Add("project_form");

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("project_id", "ID");
            map.Add("user_phone", "负责人电话号码");
            map.Add("project_name", "项目名称");
            map.Add("project_level", "项目评级");
            map.Add("project_number", "立项编号");
            map.Add("project_category", "项目类别");
            map.Add("project_youth", "是否符合青年项目申报条件");
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
            NewLine.Height = 400;
            NewLine.TableName = "ProjectApplications";
            PlaceHolder2.Controls.Clear();
            PlaceHolder2.Controls.Add(NewLine);

            System.IO.File.Delete(savePath);


        }
    }
}