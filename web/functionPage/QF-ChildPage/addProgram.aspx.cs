using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class functionPage_QF_ChildPage_addProgramData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submit_Click(object sender, EventArgs e)
    {

    }

    protected void clear_Click(object sender, EventArgs e)
    {
        this.ProgramIDInput.Text = string.Empty;
        this.floatingInput.Text = string.Empty;
        this.floatingTextarea.Text = string.Empty;
        this.PhoneNum.Text  = string.Empty;
        this.DoForm.Text = string.Empty;
        this.DoTextarea.Text = string.Empty;
    }
}