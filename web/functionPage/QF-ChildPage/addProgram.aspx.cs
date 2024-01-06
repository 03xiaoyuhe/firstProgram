using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class functionPage_QF_ChildPage_addProgramData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {
        if (ProjectCompletion.CheckTeam_id(this.PhoneNum.Text.ToString()))
        {

        
        try
        {
            ProjectCompletion.ProjectInfor(
                this.ProgramIDInput.Text.ToString(),
                this.floatingInput.Text.ToString(),
                this.floatingTextarea.Text.ToString(),
                this.PhoneNum.Text.ToString(),
                this.DoForm.Text.ToString(),
                this.DoTextarea.Text.ToString()
                );
            clearAll();
            ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/popMassage.ascx");
            ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml("Blue");
            ErroMassage.HeadLine = "Success";
            ErroMassage.Massage = "添加成功";
            this.errroMassage.Controls.Add(ErroMassage);
        }
        catch
        {
            clearAll();
            ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/popMassage.ascx");
            ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml("Red");
            ErroMassage.HeadLine = "ERRO";
            ErroMassage.Massage = "未知错误";
            this.errroMassage.Controls.Add(ErroMassage);
        }
    }
        else 
        {
                         
                clearAll();
                ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/popMassage.ascx");
                ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml("Red");
                ErroMassage.HeadLine = "ERRO";
                ErroMassage.Massage = "对应的负责人没有进行组队";
                this.errroMassage.Controls.Add(ErroMassage);
            
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