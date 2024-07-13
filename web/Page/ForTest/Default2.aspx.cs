using System;
using System.Web.UI;

namespace WebForm
{
    public partial class Default2 : System.Web.UI.Page
    {
        int Count
        {
            get
            {
                if (ViewState["ControlCount"] == null)
                    ViewState["ControlCount"] = 1;
                return (int)ViewState["ControlCount"];
            }
            set
            {
                ViewState["ControlCount"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= Count; i++)
            {
                LoadUserControl(i);
            }
            btnAddUC.Click += new EventHandler(btnAddUC_Click);
        }

        void btnAddUC_Click(object sender, EventArgs e)
        {
            Count++;
            LoadUserControl(Count);
        }

        void LoadUserControl(int index)
        {
            Control ctl = this.LoadControl("~/WebUserControl.ascx");
            ctl.ID = string.Format("userControl_{0}", index);
            this.ucHolder.Controls.Add(ctl);
        }
    }
}