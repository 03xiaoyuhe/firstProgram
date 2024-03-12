using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Models;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class functionPage_QF_ChildPage_ResetPage : System.Web.UI.Page
{

    #region 自定义变量

    string tableName;
    public string TableName
    {
        get { return tableName; }
        set { tableName = value; }
    }

    string idLable;
    public string IdLable
    {
        get { return idLable; }
        set
        {
            idLable = value;
        }
    }

    string id;
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
        TableName = Request.QueryString["tablename"];
        IdLable = Request.QueryString["idlable"];
        ID = Request.QueryString["id"];
        DataSet dataSet = new DataSet();
        dataSet = TableSelect.Select(TableName, IdLable, ID);
        DataTable ds = dataSet.Tables[0];
        DataRow dl = ds.Rows[0];
        this.ProgramIDInput.Text = dl["proposal_number"].ToString();//立项编号
        this.floatingInput.Text = dl["project_title"].ToString();//项目名称
        this.floatingTextarea.Text = dl["project_description"].ToString();//项目描述
        this.PhoneNum.Text = dl["team_id"].ToString();//小队id
        this.DoForm.Text = dl["achievement_form"].ToString();//成果形式
        this.DoTextarea.Text = dl["achievement_brief"].ToString();//成果描述
    }

    protected void submit_Click(object sender, EventArgs e)
    {

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