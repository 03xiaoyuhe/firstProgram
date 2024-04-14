using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.functionPage
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //fileup.PostedFiles;
            //【1】判断文件是否存在
            if (fileup.HasFile)
            {
                //【2】获取文件的大小，判断是否符合设置要求
                //1mb=1024kb
                //1kb=1024byte
                double fileLength = fileup.FileContent.Length / (1024.0 * 1024.0);
                //获取配置文件中上传文件大小的限制
                double limitLength = 2;
                if (fileLength > limitLength)
                {
                    lblMsg.Text = "上传文件不能超过" + limitLength + "MB";
                    return;
                }
                //【3】获取文件名，判断文件扩展名是否符合要求
                string fileName = fileup.FileName;
                //判断文件是否是exe文件，则不能上传
                if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() == ".exe")
                {
                    lblMsg.Text = "不能上传应用程序";
                    return;
                }
                //【4】修改文件名称
                //一般情况下，上传的文件服务器中保存时不会采取原文件名，因为客户端用户是非常庞大的，所以要保证每个客户端上传的文件不能被覆盖
                fileName = DateTime.Now.ToString("yyyyMMddhhmmssms") + "_" + fileName;
                //【5】获取服务器中存储文件的路径
                //"~"代表应用程序的根目录，从服务器的根目录寻找
                string path = Server.MapPath("~/UPFile");
                //【6】上传文件
                try
                {
                    fileup.SaveAs(path + "/" + fileName);
                    lblMsg.Text = "文件上传成功！";
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "文件上传失败：" + ex.Message;
                }

            }
        }

        protected void fileup_DataBinding(object sender, EventArgs e)
        {
            Label1.Text = sender.ToString();
        }
    }
}