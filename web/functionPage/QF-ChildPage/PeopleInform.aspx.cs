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
using Models.DataRowToClass;

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
            list1.Add("姓名", true);
            list1.Add("生日", true);
            list1.Add("性别", true);
            list1.Add("职务", true);
            list1.Add("职称", true);
            list1.Add("专业", false);
            list1.Add("研究专长", false);
            list1.Add("现从事职业", false);
            list1.Add("工作单位", false);
            list1.Add("通信地址", false);
            list1.Add("办公电话", false);
            list1.Add("电话号码", false);
            list1.Add("邮箱", false);



            map1 = new Dictionary<string, string>();
            map1.Add("姓名", "UseName");
            map1.Add("生日", "UserDate");
            map1.Add("性别", "UserSex");
            map1.Add("职务", "UserPosition");
            map1.Add("职称", "UserTitle");
            map1.Add("专业", "UserSpeciality");
            map1.Add("研究专长", "UserResearch");
            map1.Add("现从事职业", "UserResearch_now");
            map1.Add("工作单位", "UserWorkplace");
            map1.Add("通信地址", "UserAddress");
            map1.Add("办公电话", "UserOffice_number");
            map1.Add("电话号码", "UserNumber");
            map1.Add("邮箱", "UserEmail");
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            MetarnetRegex.Name();
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
                    ParticipantInform participantInform = new ParticipantInform();
                    participantInform.DataTable = dl;
                    if (MetarnetRegex.IsChineseCh(participantInform.PeoName))
                    {
                        if (
                    !DAL.User.KindsInsert(
                        participantInform.PeoName,
                        participantInform.PeoDate,
                        participantInform.PeoSex,
                        participantInform.PeoPosition,
                        participantInform.PeoTitle,
                        participantInform.PeoSpeciality,
                        participantInform.PeoResearch,
                        participantInform.PeoReNow,
                        participantInform.PeoWork,
                        participantInform.ProAddress,
                        participantInform.PeoOffNum,
                        participantInform.PeoNumber,
                        participantInform.ProEmail
                         //dl["UseName"].ToString(),
                         //dl["UserDate"].ToString(),
                         //dl["UserSex"].ToString(),
                         //dl["UserPosition"].ToString(),
                         //dl["UserTitle"].ToString(),
                         //dl["UserSpeciality"].ToString(),
                         //dl["UserResearch"].ToString(),
                         //dl["UserResearch_now"].ToString(),
                         //dl["UserWorkplace"].ToString(),
                         //dl["UserAddress"].ToString(),
                         //dl["UserOffice_number"].ToString(),
                         //dl["UserNumber"].ToString(),
                         //dl["UserEmail"].ToString()
                         ))
                        {
                            Models.Massage massage = new Massage();
                            massage.HeadColor = "Red";
                            massage.MassageText = "第" + i + "插入异常，可能数据依然不符合要求，请仔细检查该行数据并尝试重新插入";
                            massage.HeadText = "ERROR";
                            massage.PostMassage();
                        }
                    }
                    else
                    {
                        string name = MetarnetRegex.RetainChineseString(participantInform.PeoName);
                        if (
                    !DAL.User.KindsInsert(
                        name,
                        participantInform.PeoDate,
                        participantInform.PeoSex,
                        participantInform.PeoPosition,
                        participantInform.PeoTitle,
                        participantInform.PeoSpeciality,
                        participantInform.PeoResearch,
                        participantInform.PeoReNow,
                        participantInform.PeoWork,
                        participantInform.ProAddress,
                        participantInform.PeoOffNum,
                        participantInform.PeoNumber,
                        participantInform.ProEmail
                         //dl["UseName"].ToString(),
                         //dl["UserDate"].ToString(),
                         //dl["UserSex"].ToString(),
                         //dl["UserPosition"].ToString(),
                         //dl["UserTitle"].ToString(),
                         //dl["UserSpeciality"].ToString(),
                         //dl["UserResearch"].ToString(),
                         //dl["UserResearch_now"].ToString(),
                         //dl["UserWorkplace"].ToString(),
                         //dl["UserAddress"].ToString(),
                         //dl["UserOffice_number"].ToString(),
                         //dl["UserNumber"].ToString(),
                         //dl["UserEmail"].ToString()
                         ))
                        {
                            Models.Massage massage = new Massage();
                            massage.HeadColor = "Red";
                            massage.MassageText = "第" + i + "插入异常，可能数据依然不符合要求，请仔细检查该行数据并尝试重新插入";
                            massage.HeadText = "ERROR";
                            massage.PostMassage();
                        }
                    }
                    


                }



                // 加载导入预览
                List<string> list = new List<string>();
                list.Add("UseName");
                list.Add("UserSex");
                list.Add("UserDate");
                list.Add("UserPosition");
                list.Add("UserTitle");


                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("UseName", "姓名");
                map.Add("UserSex", "性别");
                map.Add("UserDate", "生日");
                map.Add("UserPosition", "职务");
                map.Add("UserTitle", "职称");
               
                TableAttribute tableAttribute = new TableAttribute(
                    "UseName",
                    "人员信息",
                    map,
                    list
                    );

                MyTable NewLine = (MyTable)LoadControl("~/ASCX/Table/MyTable.ascx");
                NewLine.TableBase = tableAttribute;
                NewLine.DataCollection = dataTable;
                NewLine.Height = 350;
                NewLine.TableName = "UserInfor";
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
                message.PostMassage();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                XSSFWorkbook Modebook = null;
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
            catch(System.IO.IOException error)
            {
                Massage massage = new Massage();
                massage.HeadColor = "orange";
                massage.HeadText = "WORN";
                massage.MassageText = "文件使用中";
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