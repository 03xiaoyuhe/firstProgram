using System;
using System.Web;
using DAL;

public partial class functionPage_QF_ChildPage_addProgramData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
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
            Massage massage = new Massage("Blue", "Success", "添加成功");
            massage.PostMassage();
        }
        catch
        {
            clearAll();
            Massage massage = new Massage("Red", "ERRO", "未知错误");
            massage.PostMassage();
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