using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{
    public partial class BodyCell : CellForBodyBase
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

        protected override void Page_Load(object sender, EventArgs e)
        {

        }
    }
}