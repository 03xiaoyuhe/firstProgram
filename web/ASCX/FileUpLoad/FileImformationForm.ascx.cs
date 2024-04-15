using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace WebForm.ASCX.FileUpLoad
{
    public partial class FileImformationForm : System.Web.UI.UserControl
    {

        string fileId_;
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileId
        {
            get
            {
                return fileId_;
            }
            set
            {
                fileId_ = value;
            }
        }


        /// <summary>
        /// 移除文件ID列表
        /// </summary>
        public List<string> FileRemoveList
        {
            get
            {
                return (List<string>)ViewState["FileRemoveList"];
            }
            set
            {
                ViewState["FileRemoveList"] = value;
            }
        }

        string filename;
        /// <summary>
        /// 文件内容
        /// </summary>
        [Description("文件内容"), Category("自定义属性")]
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
                FileNameLable.Text = value;
            }
        }

        string fileloadingpanelid_;
        /// <summary>
        /// 文件显示控件ID
        /// </summary>
        public string Fileloadingpanelid
        {
            get
            {
                return fileloadingpanelid_;
            }
            set
            {
                fileloadingpanelid_ = value;
            }
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        public string FileSize
        {
            get
            {
                return FileSizeLable.Text;
            }
            set
            {
                FileSizeLable.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void RemoveFile()
        {
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (fileId_ != null)
            {
                FileRemoveList.Add(fileId_);
                ((UpdatePanel)Page.Form.FindControl(Fileloadingpanelid)).Update();
            }
        }
    }
}