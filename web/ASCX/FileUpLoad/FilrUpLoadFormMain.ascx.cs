using System;
using System.Collections.Generic;
using System.Web;

namespace WebForm.ASCX.FileUpLoad
{
    public partial class FilrUpLoadFormMain : System.Web.UI.UserControl
    {

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

        Dictionary<string, HttpPostedFile> files = new Dictionary<string, HttpPostedFile>();
        public Dictionary<string, HttpPostedFile> Files
        {
            get
            {
                return files;
            }
            set
            {
                files = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadingButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (HttpPostedFile file in fileLoadFunc.PostedFiles)
            {
                string ID = DateTime.Now.ToString("yyyyMMddhhmmssms") + "_" + count.ToString();
                Files.Add(ID, file);
                count++;
            }
            FileLoadingPanel.Update();
            FileLoadingPanel_Load();
        }

        protected void FileLoadingPanel_Load(object sender, EventArgs e)
        {
            FileLoadingPanel.ContentTemplateContainer.Controls.Clear();
            if (FileRemoveList != null)
            {
                foreach (string file in FileRemoveList)
                {
                    Files.Remove(file);
                }
            }
            if (Files != null)
            {
                foreach (HttpPostedFile file in Files.Values)
                {
                    FileImformationForm form = (FileImformationForm)LoadControl("FileImformationForm.ascx");
                    form.FileName = file.FileName;
                    form.FileId = ID;
                    string size;
                    if (file.ContentLength / (1024.0 * 1024.0) > 1)
                    {
                        size = $"{file.ContentLength / (1024.0 * 1024.0)}MB";
                    }
                    else if (file.ContentLength / (1024.0) > 1)
                    {
                        size = $"{file.ContentLength / (1024.0)}KB";
                    }
                    else
                    {
                        size = $"{file.ContentLength}B";
                    }
                    form.FileSize = size;
                    FileLoadingPanel.ContentTemplateContainer.Controls.Add(form);
                }
            }
        }
        protected void FileLoadingPanel_Load()
        {
            FileLoadingPanel.ContentTemplateContainer.Controls.Clear();
            if (FileRemoveList != null)
            {
                foreach (string file in FileRemoveList)
                {
                    Files.Remove(file);
                }
            }
            if (Files != null)
            {
                foreach (HttpPostedFile file in Files.Values)
                {
                    FileImformationForm form = (FileImformationForm)LoadControl("FileImformationForm.ascx");
                    form.FileName = file.FileName;
                    form.FileId = ID;
                    string size;
                    if (file.ContentLength / (1024.0 * 1024.0) > 1)
                    {
                        size = $"{file.ContentLength / (1024.0 * 1024.0)}MB";
                    }
                    else if (file.ContentLength / (1024.0) > 1)
                    {
                        size = $"{file.ContentLength / (1024.0)}KB";
                    }
                    else
                    {
                        size = $"{file.ContentLength}B";
                    }
                    form.FileSize = size;
                    FileLoadingPanel.ContentTemplateContainer.Controls.Add(form);
                }
            }
        }
    }
}