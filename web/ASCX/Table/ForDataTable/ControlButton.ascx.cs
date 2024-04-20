using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.DataTableControl.Trigger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{

    public partial class ControlButton : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AAA.Text = name;
        }

        string name = "";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        Trigger trigger = new Trigger();
        /// <summary>
        /// 按钮触发器，注意触发器事件需要订阅
        /// </summary>
        public Trigger CusTrigger
        {
            get
            {
                return trigger;
            }
            set
            {
                trigger = value;
            }
        }

        public DataTableLineArgs DataTableLineArgs
        {
            get { return trigger.DataTableLineArgs; }
            set { trigger.DataTableLineArgs = value; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CusTrigger.IsTrigger(sender);
        }
    }


}