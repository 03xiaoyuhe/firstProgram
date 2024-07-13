using Models.DataRowToClass;
using Models.ErroModels;
using Models.PageDataSor;
using Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX.Table;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class EndingProjectLoadPage : System.Web.UI.Page
    {
        Dictionary<string, bool> list1;
        Dictionary<string, string> map1;

        string ErroFilePath
        {
            get
            {
                return Session["ErroProgremFilePath"] as string;
            }
            set
            {
                Session["ErroProgremFilePath"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            //UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            MetarnetRegex.RemoveHash();


            MetarnetRegex.Give();

            list1 = new Dictionary<string, bool>();
            list1.Add("项目负责人", true);
            list1.Add("项目名称", true);
            list1.Add("项目评级", true);
            list1.Add("立项编号", true);
            list1.Add("项目类别", true);
            list1.Add("是否符合青年项目申报条件", true);
            list1.Add("本项目国内外研究现状述评", true);
            list1.Add("本项目研究的主要观点", true);
            list1.Add("前期研究成果", true);
            list1.Add("项目完成时间", true);
            list1.Add("成果形式", true);
            list1.Add("项目单位评审意见", true);
            list1.Add("专家评审", true);
            list1.Add("项目审批意见", true);
            for (int i = 0; i < 13; i++)
            {
                list1.Add($"队员{i}", false);
            }

            map1 = new Dictionary<string, string>();
            map1.Add("项目负责人", "project_leader");
            map1.Add("项目名称", "project_name");
            map1.Add("项目评级", "project_level");
            map1.Add("立项编号", "project_number");
            map1.Add("项目类别", "project_category");
            map1.Add("是否符合青年项目申报条件", "project_youth");
            map1.Add("本项目国内外研究现状述评", "project_research");
            map1.Add("本项目研究的主要观点", "project_view");
            map1.Add("前期研究成果", "project_References");
            map1.Add("项目完成时间", "project_time");
            map1.Add("成果形式", "project_form");
            map1.Add("项目单位评审意见", "project_opinion");
            map1.Add("专家评审", "project_expert_view");
            map1.Add("项目审批意见", "project_approval_view");
            for (int i = 0; i < 13; i++)
            {
                map1.Add($"队员{i}", $"UserId{i}");
            }


        }


        protected void Page_Unload(object sender, EventArgs e)
        {

            if (File.Exists(ErroFilePath))
            {
                File.Delete(ErroFilePath);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            MetarnetRegex.Give();

            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件 choose为文件上传框ID
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(FileUpload1.FileName).ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls")
            {
                Response.Write("<script>alert('只可以选择表格文件')</script>");
                return;//当选择的不是Excel文件时,返回
            }
            string filename = FileUpload1.FileName;              //获取Excel文件名  DateTime日期函数

            string savePath = Server.MapPath($"~\\uploadfiles\\{DateTime.Now.ToFileTime()}" + filename);//Server.MapPath 获得虚拟服务器相对路径 自己也可以写成绝对路径
            FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上  这里保存在本地uploadfiles文件中
            ErroFilePath = Server.MapPath($"~\\uploadfiles\\erro{DateTime.Now.ToFileTime()}" + filename);
            try
            {
                // 读取文件操作
                ExcelRead excelRead = new ExcelRead();
                excelRead.Attribute = list1;
                excelRead.ExcelHeadLineData = map1;
                excelRead.InputExcelPath = savePath;
                excelRead.ErroPutExcelPath = ErroFilePath;


                int ErroRowCount = 0;
                DataTable loadDataTable = excelRead.LoadExcel(out ErroRowCount);
                File.Delete(savePath);

                if (ErroRowCount > 0)
                {
                    Massage massage = new Massage();
                    massage.HeadColor = "blue";
                    massage.HeadText = "tips";
                    massage.MassageText = $"共{ErroRowCount}行数据无法导入，请点击下载错误数据行文件，查看并修改。";
                    massage.PostMassage();
                }


                for (int i = 0; i < loadDataTable.Rows.Count; i++)
                {
                    DataRow dl = loadDataTable.Rows[i];
                    ProgressProject progressProject = new ProgressProject();
                    progressProject.DataRow = dl;


                    //判断是否是使用id插入
                    if (MetarnetRegex.IsNotNagtive(progressProject.ProUser))
                    {
                        //if (
                        //!DAL.ProjectCompletion.KindsInsert(
                        //     progressProject.ProUser,
                        //     progressProject.ProName, //dl["project_name"].ToString(), 
                        //     progressProject.ProLevel, //dl["project_level"].ToString(),
                        //     progressProject.ProNumber, //dl["project_number"].ToString(),
                        //     progressProject.ProCategory, //dl["project_category"].ToString(),
                        //     progressProject.ProYouth,                //dl["project_youth"].ToString(),
                        //     progressProject.ProResearch,                //dl["project_research"].ToString(),
                        //     progressProject.ProView,                //dl["project_view"].ToString(),
                        //     progressProject.ProReferences,                 //dl["project_References"].ToString(),
                        //     progressProject.ProTime,                 //dl["project_time"].ToString(),
                        //     progressProject.ProForm,                 //dl["project_form"].ToString(),
                        //     progressProject.ProOpinion,                 //dl["project_opinion"].ToString(),
                        //     progressProject.ProExpert,                  //dl["project_expert_view"].ToString(),
                        //     progressProject.ProApproval                  //dl["project_approval_view"].ToString()
                        //     ))
                        if (!DAL.ProjectCompletion.KidsInfor(
                            progressProject.ProUser,
                             progressProject.ProName, //dl["project_name"].ToString(), 
                             progressProject.ProLevel, //dl["project_level"].ToString(),
                             progressProject.ProNumber, //dl["project_number"].ToString(),
                             progressProject.ProCategory, //dl["project_category"].ToString(),
                             progressProject.ProYouth,                //dl["project_youth"].ToString(),
                             progressProject.ProResearch,                //dl["project_research"].ToString(),
                             progressProject.ProView,                //dl["project_view"].ToString(),
                             progressProject.ProReferences,                 //dl["project_References"].ToString(),
                             progressProject.ProTime,                 //dl["project_time"].ToString(),
                             progressProject.ProForm,                 //dl["project_form"].ToString(),
                             progressProject.ProOpinion,                 //dl["project_opinion"].ToString(),
                             progressProject.ProExpert,                  //dl["project_expert_view"].ToString(),
                             progressProject.ProApproval,
                             progressProject.PartersInform
                             ))              //dl["project))
                        {
                            Models.Massage massage = new Massage();
                            //massage.NO = "1";
                            massage.HeadColor = "Red";
                            massage.HeadText = "ERROR";
                            massage.MassageText = "第" + i + "插入异常，可能数据依然不符合要求，请仔细检查该行数据并尝试重新插入";
                            massage.PostMassage();
                        }
                        else
                        {
                            // 加载导入预览
                            List<string> list = new List<string>();
                            list.Add("project_name");
                            list.Add("project_level");
                            list.Add("project_number");
                            list.Add("project_category");
                            list.Add("project_youth");
                            list.Add("project_time");
                            list.Add("project_form");

                            Dictionary<string, string> map = new Dictionary<string, string>();
                            map.Add("project_name", "项目名称");
                            map.Add("project_level", "项目评级");
                            map.Add("project_number", "立项编号");
                            map.Add("project_category", "项目类别");
                            map.Add("project_youth", "是否符合青年项目申报条件");
                            map.Add("project_time", "项目完成时间");
                            map.Add("project_form", "成果形式");

                            TableAttribute tableAttribute = new TableAttribute(
                                "project_number",
                                "项目信息",
                                map,
                                list
                                );

                            MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                            NewLine.TableBase = tableAttribute;
                            NewLine.DataCollection = loadDataTable;
                            NewLine.TableName = "ProjectApplications";
                            PlaceHolder2.Controls.Clear();
                            PlaceHolder2.Controls.Add(NewLine);
                        }
                    }

                    //使用姓名插入 progressProject.ProUser值为姓名
                    DataSet dataSet = DAL.DBHelper.Query("select Id,UseName,UserDate,UserSex,UserPosition from UserInfor where UseName = '" + progressProject.ProUser + "';");
                    DataTable dt = dataSet.Tables[0];

                    int rowAfforts = dt.Rows.Count;

                    if (rowAfforts == 0)
                    {
                        Models.Massage massage = new Massage();
                        massage.HeadColor = "Red";
                        massage.HeadText = "ERROR";
                        massage.MassageText = "该负责人未导入信息，请检查填入的负责人姓名是否正确";
                        massage.PostMassage();
                    }

                    //检查出不重名信息，因为只有一行，所以直接添加到项目表中
                    else if (rowAfforts == 1)
                    {
                        DataSet dataId = DAL.DBHelper.Query("select Id from UserInfor where UseName ='" + progressProject.ProUser + "';");
                        DataTable ds = dataId.Tables[0];
                        DataRow dataRow = ds.Rows[0];
                        string leaderId = dataRow[0].ToString();

                        //if (
                        //!DAL.ProjectCompletion.KindsInsert(
                        //     leaderId,
                        //     progressProject.ProName, //dl["project_name"].ToString(), 
                        //     progressProject.ProLevel, //dl["project_level"].ToString(),
                        //     progressProject.ProNumber, //dl["project_number"].ToString(),
                        //     progressProject.ProCategory, //dl["project_category"].ToString(),
                        //     progressProject.ProYouth,                //dl["project_youth"].ToString(),
                        //     progressProject.ProResearch,                //dl["project_research"].ToString(),
                        //     progressProject.ProView,                //dl["project_view"].ToString(),
                        //     progressProject.ProReferences,                 //dl["project_References"].ToString(),
                        //     progressProject.ProTime,                 //dl["project_time"].ToString(),
                        //     progressProject.ProForm,                 //dl["project_form"].ToString(),
                        //     progressProject.ProOpinion,                 //dl["project_opinion"].ToString(),
                        //     progressProject.ProExpert,                  //dl["project_expert_view"].ToString(),
                        //     progressProject.ProApproval                  //dl["project_approval_view"].ToString()
                        //     ))
                        if (!DAL.ProjectCompletion.KidsInfor(
                             leaderId,
                             progressProject.ProName, //dl["project_name"].ToString(), 
                             progressProject.ProLevel, //dl["project_level"].ToString(),
                             progressProject.ProNumber, //dl["project_number"].ToString(),
                             progressProject.ProCategory, //dl["project_category"].ToString(),
                             progressProject.ProYouth,                //dl["project_youth"].ToString(),
                             progressProject.ProResearch,                //dl["project_research"].ToString(),
                             progressProject.ProView,                //dl["project_view"].ToString(),
                             progressProject.ProReferences,                 //dl["project_References"].ToString(),
                             progressProject.ProTime,                 //dl["project_time"].ToString(),
                             progressProject.ProForm,                 //dl["project_form"].ToString(),
                             progressProject.ProOpinion,                 //dl["project_opinion"].ToString(),
                             progressProject.ProExpert,                  //dl["project_expert_view"].ToString(),
                             progressProject.ProApproval,
                             progressProject.PartersInform
                             ))
                        {
                            Models.Massage massage = new Massage();
                            massage.HeadColor = "Red";
                            massage.HeadText = "ERROR";
                            massage.MassageText = "第" + i + "插入异常，可能数据依然不符合要求，请仔细检查该行数据并尝试重新插入";
                            massage.PostMassage();
                        }
                        // 加载导入预览
                        List<string> list = new List<string>();
                        list.Add("project_name");
                        list.Add("project_level");
                        list.Add("project_number");
                        list.Add("project_category");
                        list.Add("project_youth");
                        list.Add("project_time");
                        list.Add("project_form");

                        Dictionary<string, string> map = new Dictionary<string, string>();
                        map.Add("project_name", "项目名称");
                        map.Add("project_level", "项目评级");
                        map.Add("project_number", "立项编号");
                        map.Add("project_category", "项目类别");
                        map.Add("project_youth", "是否符合青年项目申报条件");
                        map.Add("project_time", "项目完成时间");
                        map.Add("project_form", "成果形式");

                        TableAttribute tableAttribute = new TableAttribute(
                            "project_number",
                            "项目信息",
                            map,
                            list
                            );

                        MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                        NewLine.TableBase = tableAttribute;
                        NewLine.DataCollection = loadDataTable;
                        NewLine.TableName = "ProjectApplications";
                        PlaceHolder2.Controls.Clear();
                        PlaceHolder2.Controls.Add(NewLine);

                    }
                    else if (rowAfforts > 1)
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


                        TableAttribute tableAttribute1 = new TableAttribute(
                            "Id",
                            "重名信息",
                            mapInfor,
                            listInfor
                            );

                        MyTable NewLine1 = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                        NewLine1.TableBase = tableAttribute1;
                        NewLine1.DataCollection = dt;
                        NewLine1.Height = 400;
                        NewLine1.TableName = "UserInfor";
                        PlaceHolder1.Controls.Clear();
                        PlaceHolder1.Controls.Add(NewLine1);

                        Massage massage = new Massage();
                        massage.MassageText = "有重名的信息，请您检查核对需要插入的具体是哪位，并使用编号进行再次插入";
                        massage.HeadText = "WANNING";
                        massage.HeadColor = "Orange";
                        massage.PostMassage();
                    }




                }




                //// 加载导入预览
                //List<string> list = new List<string>();
                //list.Add("project_name");
                //list.Add("project_level");
                //list.Add("project_number");
                //list.Add("project_category");
                //list.Add("project_youth");
                //list.Add("project_time");
                //list.Add("project_form");

                //Dictionary<string, string> map = new Dictionary<string, string>();
                //map.Add("project_name", "项目名称");
                //map.Add("project_level", "项目评级");
                //map.Add("project_number", "立项编号");
                //map.Add("project_category", "项目类别");
                //map.Add("project_youth", "是否符合青年项目申报条件");
                //map.Add("project_time", "项目完成时间");
                //map.Add("project_form", "成果形式");

                //TableAttribute tableAttribute = new TableAttribute(
                //    "project_number",
                //    "项目信息",
                //    map,
                //    list
                //    );

                //MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                //NewLine.TableBase = tableAttribute;
                //NewLine.DataCollection = loadDataTable;
                //NewLine.Height = 400;
                //NewLine.TableName = "ProjectApplications";
                //PlaceHolder2.Controls.Clear();
                //PlaceHolder2.Controls.Add(NewLine);







                System.IO.File.Delete(savePath);



            }
            catch (LineAbsentException erro)
            {
                Massage message = new Massage();

                message.MassageText = erro.Message + "，请修改原表并再次导入";
                message.HeadColor = "Red";
                message.HeadText = "ERROR";
                message.PostMassage();
            }
            catch (System.Data.SqlClient.SqlException error)
            {
                Massage message = new Massage();
                message.MassageText = "系统出现严重异常，请携带报错截图寻找工作人员！" + error.Message;
                message.HeadColor = "Red";
                message.HeadText = "ERROR";
                message.PostMassage();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            XSSFWorkbook Modebook = null;
            int rowCount = 0;//行数

            string ModeExcelPath = Server.MapPath($"~\\uploadfiles\\FormExcel.xlsx");
            FileStream ModeExcel = new FileStream(ModeExcelPath, FileMode.Create, FileAccess.ReadWrite);


            Modebook = new XSSFWorkbook();
            ISheet ModeSheet = Modebook.CreateSheet("FormExcel");

            IRow ModeHead = ModeSheet.CreateRow(0);
            int countcell = 0;
            foreach (KeyValuePair<string, bool> keyValuePair in list1)
            {
                ModeHead.CreateCell(countcell++).SetCellValue(keyValuePair.Key);
            }

            using (ModeExcel)
            {
                Modebook.Write(ModeExcel);//向打开的这个xls文件中写入数据  
            }

            if (File.Exists(ModeExcelPath))
            {
                string fileName = $"FormExcel{Path.GetExtension(ModeExcelPath)}";//客户端保存的文件名
                string filePath = ModeExcelPath;//路径
                                                //以字符流的形式下载文件
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开
                Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

            }
            else
            {
                Massage massage = new Massage();
                massage.HeadColor = "Red";
                massage.HeadText = "Erro";
                massage.MassageText = "无格式规定文件";
                massage.PostMassage();
            }
            File.Delete(ModeExcelPath);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(ErroFilePath))
            {
                string fileName = $"ErroExcel{Path.GetExtension(ErroFilePath)}";//客户端保存的文件名
                string filePath = ErroFilePath;//路径
                                               //以字符流的形式下载文件
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.ContentType = "application/octet-stream";
                //通知浏览器下载文件而不是打开
                Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            else
            {
                Massage massage = new Massage();
                massage.HeadColor = "Red";
                massage.HeadText = "Erro";
                massage.MassageText = "无错误数据行文件";
                massage.PostMassage();
            }
        }
    }
}