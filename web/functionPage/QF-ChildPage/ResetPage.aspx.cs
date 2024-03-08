using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        //Request.QueryString["name"];
        //Request.QueryString["email"];
        TableName = Request.QueryString["tablename"];
        IdLable = Request.QueryString["idlable"];
        ID = Request.QueryString["id"];


        this.ProgramIDInput.Text.ToString();
        this.floatingInput.Text.ToString();
        this.floatingTextarea.Text.ToString();
        this.PhoneNum.Text.ToString();
        this.DoForm.Text.ToString();
        this.DoTextarea.Text.ToString();


    }

    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ProjectCompletion.CheckTeam_id(this.PhoneNum.Text.ToString()))
            {
                throw new Exception("NotLoad");
            }
            if (ProjectCompletion.ProjectInfor(
                this.ProgramIDInput.Text.ToString(),
                this.floatingInput.Text.ToString(),
                this.floatingTextarea.Text.ToString(),
                this.PhoneNum.Text.ToString(),
                this.DoForm.Text.ToString(),
                this.DoTextarea.Text.ToString()
                ))
            {
                clearAll();
                Massage massage = new Massage("Blue", "Success", "修改");
                massage.PostMassage();
            }
        }
        catch (Exception E)
        {
            if (E.Message == "NotLoad")
            {
                clearAll();
                Massage massage = new Massage("#ff0000", "ERRO", "对应负责人未组队");
                massage.PostMassage();
            }
            else
            {
                clearAll();
                Massage massage = new Massage("#ff0000", "ERRO", E.Message);
                massage.PostMassage();
            }
        }
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