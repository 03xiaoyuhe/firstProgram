using DAL;
using DAL.DataControl.TableControl;
using DAL.DataObject.TableObject;
using Models;
using Models.DataRowToClass;
using Models.ErroModels;
using Models.PageDataSor;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.DynamicData;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX.Table;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class ProgremLoad : System.Web.UI.Page
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
            

            //MetarnetRegex.Give();

            list1 = new Dictionary<string, bool>();
            list1.Add("课题名称", true);
            list1.Add("项目类别", true);
            list1.Add("项目状态", true);
            list1.Add("学科分类", true);
            list1.Add("最后成果形式", true);
            list1.Add("项目完成时间", true);
            list1.Add("填表日期", false); 
            list1.Add("项目国内外研究现状述评，选题意义及价值", false);
            list1.Add("项目研究的主要观点、基本思路和方法、重点难点及创新之处", false);
            list1.Add("项目负责人和主要成员前期研究成果及主要参考文献", false);
            list1.Add("所在单位评审意见", false);
            list1.Add("所在单位评审意见时间", false);
            list1.Add("专家组评审意见", false);
            list1.Add("专家组评审意见时间", false);
            list1.Add("审批意见", false);
            list1.Add("审批意见时间", false);


            map1 = new Dictionary<string, string>();
            map1.Add("课题名称", "ProjectName");
            map1.Add("学科分类", "DisciplineClassificaton");
            map1.Add("项目状态", "ProjectState");
            map1.Add("项目类别", "ProjectCategory");
            map1.Add("填表日期", "FillDate");
            map1.Add("最后成果形式", "Ending");
            map1.Add("项目完成时间", "EndingDate");
            map1.Add("项目国内外研究现状述评，选题意义及价值", "ProjectSignificance");
            map1.Add("项目研究的主要观点、基本思路和方法、重点难点及创新之处", "ProjectDocument");
            map1.Add("项目负责人和主要成员前期研究成果及主要参考文献", "ProjectReferences");
            map1.Add("所在单位评审意见", "UnitJudge");
            map1.Add("所在单位评审意见时间", "UnitJudgeDate");
            map1.Add("专家组评审意见", "ExpertJudge");
            map1.Add("专家组评审意见时间", "ExpertJudgeDate");
            map1.Add("审批意见", "ApprovalOpinion");
            map1.Add("审批意见时间", "ApprovalOpinionDate");
        }


        protected void Page_Unload(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //MetarnetRegex.Give();

            if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件 choose为文件上传框ID
            {
                Response.Write("<script>alert('请您选择Excel文件')</script> ");
                return;//当无文件时,返回
            }
            string IsXls = Path.GetExtension(FileUpload1.FileName).ToLower();//System.IO.Path.GetExtension获得文件的扩展名
            if (IsXls != ".xlsx" && IsXls != ".xls" )
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

                ProjectData projectData = new ProjectData();
                projectData.DataTable = loadDataTable;
                projectData.State = DAL.DataObject.DataObjectState.PraiseDateTableToData;
                for(int i = 0; i <  loadDataTable.Rows.Count; i++)
                {
                    projectData.RowIndex = i;
                    (new ProjectControl()).Insert(null, projectData);
                }


                #region 导入结果显示页


                List<string> list = new List<string>();
                list.Add("ProjectName");
                list.Add("ProjectState");
                list.Add("ProjectCategory");
                list.Add("DisciplineClassification");
                list.Add("Ending");
                list.Add("EndingDate");

                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("ProjectName", "项目名称");
                map.Add("ProjectState", "项目状态");
                map.Add("ProjectCategory", "学科分类");
                map.Add("DisciplineClassification", "学科分类");
                map.Add("Ending", "最后成果形式");
                map.Add("EndingDate", "项目完成时间");

                TableAttribute tableAttribute = new TableAttribute(
                    "PB_ID",
                    "项目信息",
                    map,
                    list
                    );


                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = tableAttribute;
                NewLine.DataCollection = loadDataTable;
                NewLine.Height = 480;
                NewLine.TableName = "ProjectApplications";
                NewLine.ShowControl = false;
                NewLine.ControlASCX = "~/ASCX/Table/ForMyTable/DeletButten.ascx";
                NewLine.ShowCheck = false;
                PlaceHolder2.Controls.Clear();
                PlaceHolder2.Controls.Add(NewLine);


                #endregion

                if (ErroRowCount > 0)
                {
                    Massage massage = new Massage();
                    massage.HeadColor = "blue";
                    massage.HeadText = "tips";
                    massage.MassageText = $"共{ErroRowCount}行数据无法导入，请点击下载错误数据行文件，查看并修改。";
                    massage.PostMassage();
                }
                else
                {
                    Massage massage = new Massage();
                    massage.HeadColor = "blue";
                    massage.HeadText = "Success";
                    massage.MassageText = $"导入完成";
                    massage.PostMassage();
                }
                System.IO.File.Delete(savePath);
            }
            catch(LineAbsentException erro)
            {
                Massage message = new Massage();

                message.MassageText = erro.Message+"，请修改原表并再次导入";
                message.HeadColor = "Red";
                message.HeadText = "ERROR";
                message.PostMassage();
            }
            catch (System.Data.SqlClient.SqlException error)
            {
                Massage message = new Massage();
                message.MassageText ="系统出现严重异常，请携带报错截图寻找工作人员！"+ error.Message;
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
            foreach(KeyValuePair<string, bool> keyValuePair in list1)
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