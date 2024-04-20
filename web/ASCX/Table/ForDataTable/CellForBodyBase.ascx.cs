using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{
    /// <summary>
    /// 表格单元格基类<br/>
    /// 属性: DataTableLineArgs ---> 表格自定义事件自定义传参
    /// </summary>
    public partial class CellForBodyBase : System.Web.UI.UserControl
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {

        }


        protected DataTableLineArgs dataTableLineArgs = new DataTableLineArgs();

        /// <summary>
        /// 表格自定义事件自定义传参
        /// </summary>
        public DataTableLineArgs DataTableLineArgs
        {
            get
            {
                return dataTableLineArgs;
            }
            set
            {
                dataTableLineArgs = value;
                UpdateDataTableLineArgs();
            }
        }

        /// <summary>
        /// 用于刷新按钮绑定的 DataTableLineArgs
        /// </summary>
        protected virtual void UpdateDataTableLineArgs()
        {

        }

    }
}