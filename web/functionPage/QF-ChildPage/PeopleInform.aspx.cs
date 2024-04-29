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
    public partial class PeopleInform : System.Web.UI.Page
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
            //MetarnetRegex.Give();

            list1 = new Dictionary<string, bool>();
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


            map1 = new Dictionary<string, string>();
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
                DataTable dataTable = excelRead.LoadExcel(out ErroRowCount);

                if (ErroRowCount > 0)
                {
                    Massage massage = new Massage();
                    massage.HeadColor = "blue";
                    massage.HeadText = "tips";
                    massage.MassageText = $"存在无法导入的数据行，共{ErroRowCount}行数据无法导入，请点击下载错误数据行文件，进行查看并修改。";
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow dl = dataTable.Rows[i];
                    //string Time = dl["project_time"].ToString();
                    //char[] lis = new char[Time.Length - 2];
                    //int count = 0;
                    //for(int j =1; j < Time.Length-1; j++)
                    //{
                    //    lis[count] = Time[j];
                    //}

                    string values = dl["project_time"].ToString();

                    //string[] vals = values.Split('-');
                    //string one = vals[1];
                    //string two = vals[1].Remove(vals[1].Length-1);
                    //string three = vals[2];
                    //string ans = one +'-' +two +'-'+ three;

                    if (
                    !DAL.ProjectCompletion.KindsInsert(
                         dl["project_name"].ToString(),
                         dl["project_level"].ToString(),
                         dl["project_number"].ToString(),
                         dl["project_category"].ToString(),
                         dl["project_youth"].ToString(),
                         dl["project_research"].ToString(),
                         dl["project_view"].ToString(),
                         dl["project_References"].ToString(),
                         dl["project_time"].ToString(),
                         //new string(lis),
                         dl["project_form"].ToString(),
                         dl["project_opinion"].ToString(),
                         dl["project_expert_view"].ToString(),
                         dl["project_approval_view"].ToString()
                         ))
                    {
                        Models.Massage massage = new Massage();
                        massage.HeadColor = "Red";
                        massage.HeadText = "第" + i + "插入异常，可能数据依然不符合要求，请仔细检查该行数据并尝试重新插入";
                    }


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
                NewLine.DataCollection = dataTable;
                NewLine.Height = 350;
                NewLine.TableName = "ProjectApplications";
                PlaceHolder2.Controls.Clear();
                PlaceHolder2.Controls.Add(NewLine);

                System.IO.File.Delete(savePath);
            }
            catch (System.Data.SqlClient.SqlException error)
            {
                Massage message = new Massage();

                message.MassageText = "系统出现严重异常，请携带报错截图寻找工作人员！" + error.Message;
                message.HeadColor = "Red";
                message.HeadText = "ERROR";
            }







        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            IWorkbook Modebook = null;
            int rowCount = 0;//行数
            //判断文件是否存在
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

        #region 物理路径和相对路径的转换
        //本地路径转换成URL相对路径 
        private string urlconvertor(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
            imagesurl2 = imagesurl2.Replace(@"\", @"/");
            //imagesurl2 = imagesurl2.Replace(@"Aspx_Uc/", @"");
            return imagesurl2;
        }
        //相对路径转换成服务器本地物理路径 
        private string urlconvertorlocal(string imagesurl1)
        {
            string tmpRootDir = Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
            string imagesurl2 = tmpRootDir + imagesurl1.Replace(@"/", @"\"); //转换成绝对路径
            return imagesurl2;
        }
        #endregion
    }
}