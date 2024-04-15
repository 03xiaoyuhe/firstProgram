using DAL;
using System;
using System.Data;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class ResetPage : System.Web.UI.Page
    {
        #region 自定义变量

        static string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        static string idLable;
        public string IdLable
        {
            get { return idLable; }
            set
            {
                idLable = value;
            }
        }

        static string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TableName = Request.QueryString["tablename"];
                IdLable = Request.QueryString["idlable"];
                Id = Request.QueryString["id"];

                DataSet dataSet = new DataSet();
                dataSet = TableSelect.Select(TableName, IdLable, Id);
                DataTable ds = dataSet.Tables[0];
                DataRow dl = ds.Rows[0];

                this.ProgramIDInput.Text = dl["proposal_number"].ToString();//立项编号
                this.floatingInput.Text = dl["project_title"].ToString();//项目名称
                this.floatingTextarea.Text = dl["project_description"].ToString();//项目描述
                this.PhoneNum.Text = dl["team_id"].ToString();//小队id
                this.DoForm.Text = dl["achievement_form"].ToString();//成果形式
                this.DoTextarea.Text = dl["achievement_brief"].ToString();//成果描述

            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            //    try
            //    {

            //        if (ProjectCompletion.UpdatePrroject(
            //            Id,
            //            this.ProgramIDInput.Text.ToString(),
            //            this.floatingInput.Text.ToString(),
            //            this.floatingTextarea.Text.ToString(),
            //            this.PhoneNum.Text.ToString(),
            //            this.DoForm.Text.ToString(),
            //            this.DoTextarea.Text.ToString()
            //            ))
            //        {
            //            clearAll();
            //            Massage massage = new Massage("Blue", "Success", "修改");
            //            massage.PostMassage();
            //        }
            //    }
            //    catch (Exception E)
            //    {
            //        if (E.Message == "NotLoad")
            //        {
            //            clearAll();
            //            Massage massage = new Massage("#ff0000", "ERRO", "发生错误，未修改成功");
            //            massage.PostMassage();
            //        }
            //        else
            //        {
            //            clearAll();
            //            Massage massage = new Massage("#ff0000", "ERRO", E.Message);
            //            massage.PostMassage();
            //        }
            //    }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        protected void clearAll()
        {
            this.ProgramIDInput.Text = string.Empty;
            this.floatingInput.Text = string.Empty;
            this.floatingTextarea.Text = string.Empty;
            this.PhoneNum.Text = string.Empty;
            this.DoForm.Text = string.Empty;
            this.DoTextarea.Text = string.Empty;
        }
    }
}