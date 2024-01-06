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
            HttpCookie aCookie = new HttpCookie("Massage");
            aCookie.Values["Type"] = "Massage";
            aCookie.Values["HeadColor"] = "Blue";
            aCookie.Values["HeadLine"] = "Success";
            aCookie.Values["DataTime"] = DateTime.Now.ToString();
            aCookie.Values["Massage"] = "添加成功";
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
        }
        catch
        {
            clearAll();

            HttpCookie aCookie = new HttpCookie("Massage" + DateTime.Now.ToString());
            aCookie.Values["Type"] = "Massage";
            aCookie.Values["HeadColor"] = "Red";
            aCookie.Values["HeadLine"] = "ERRO";
            aCookie.Values["DataTime"] = DateTime.Now.ToString();
            aCookie.Values["Massage"] = "未知错误";
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
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