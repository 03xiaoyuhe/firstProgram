using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{
    public partial class HeadCell : System.Web.UI.UserControl
    {
        public string Data
        {
            get
            {
                return DataLable.Text;
            }
            set
            {
                DataLable.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}