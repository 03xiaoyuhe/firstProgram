using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.DataTableControl.Lisener;
using Models.PageDataSor.DataTableControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{
    public class Lisener : DataTableLineLisener
    {
        List<DataTableControlAttribute<DataTableLineArgs>> customControls = new List<DataTableControlAttribute<DataTableLineArgs>>();
        /// <summary>
        /// 用于存放表格操作集
        /// </summary>
        public List<DataTableControlAttribute<DataTableLineArgs>> CustomControls
        {
            get
            {
                return customControls;
            }
            set
            {
                customControls = value;
            }
        }

        public override void Control(object sender, DataTableLineArgs e)
        {
            foreach (DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute in customControls)
            {
                if (dataTableControlAttribute != null)
                {
                    if (((Button)sender).Text == dataTableControlAttribute.ControlName)
                    {
                        dataTableControlAttribute.DataTableControls(sender, e);
                        break;
                    }
                }
            }
        }
    }
}