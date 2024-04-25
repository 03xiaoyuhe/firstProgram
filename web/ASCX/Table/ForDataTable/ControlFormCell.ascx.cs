using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.DataTableControl.Lisener;
using Models.PageDataSor.DataTableControl.Trigger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{
    public partial class ControlFormCell : CellForBodyBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            PutControlButton();
        }


        List<DataTableControlAttribute> customControls = new List<DataTableControlAttribute>();
        /// <summary>
        /// 用于存放表格操作集
        /// </summary>
        public List<DataTableControlAttribute> CustomControls
        {
            get
            {
                return customControls;
            }
            set
            {
                customControls = value;
                PutControlButton();
            }
        }


        /// <summary>
        /// 用于刷新按钮绑定的 DataTableLineArgs
        /// </summary>
        protected override void UpdateDataTableLineArgs()
        {
            foreach (object a in PutControlPlaceHolder.Controls)
            {
                ((MyButton)a).CusTrigger.DataTableLineArgs = dataTableLineArgs;
            }
        }


        void PutControlButton()
        {
            PutControlPlaceHolder.Controls.Clear();
            foreach (DataTableControlAttribute dataTableControlAttribute in CustomControls)
            {
                MyButton controlButton = new MyButton();

                controlButton.CusTrigger.Controls += dataTableControlAttribute.DataTableControls;
                controlButton.CusTrigger.DataTableLineArgs = DataTableLineArgs;

                controlButton.Text = dataTableControlAttribute.ControlName;

                PutControlPlaceHolder.Controls.Add(controlButton);
            }
        }
    }
}