using Models;
using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForDataTable
{
    public partial class BodyLine : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCell();
        }


        DataRow dataRow;
        /// <summary>
        /// 行数据集
        /// </summary>
        public DataRow DataForALine
        {
            get
            {
                return dataRow;
            }
            set
            {
                dataRow = value;
                LoadCell();
                UpdateDataTableLineArgs();
            }
        }


        TableAttribute tableAttribute = new TableAttribute();
        /// <summary>
        /// 表格描述属性
        /// </summary>
        public TableAttribute TableAttribute
        {
            get
            {
                return tableAttribute;
            }
            set
            {
                tableAttribute = value;
                LoadCell();
                UpdateDataTableLineArgs();
            }
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
                LoadCell();
            }
        }

        /// <summary>
        /// 解释表格自定义事件自定义传参
        /// </summary>
        public DataTableLineArgs DataTableLineArgs
        {
            get
            {
                return new DataTableLineArgs(TableAttribute, LineNo);
            }
        }



        /// <summary>
        /// 解释本行ID
        /// </summary>
        public int LineNo
        {
            get
            {
                if(TableAttribute.IDLable != null)
                {
                    return DataForALine.Field<int>(TableAttribute.IDLable);
                }
                return -1;
            }
        }


        /// <summary>
        /// 用于刷新按钮绑定的 DataTableLineArgs
        /// </summary>
        void UpdateDataTableLineArgs()
        {
            foreach (object a in CellHolder.Controls)
            {
                ((CellForBodyBase)a).DataTableLineArgs = DataTableLineArgs;
            }
        }

        /// <summary>
        /// 用于加载该行包含的所有单元格
        /// </summary>
        public void LoadCell()
        {
            CellHolder.Controls.Clear();
            for (int i = 0; i < TableAttribute.ColumnNum; i++)
            {
                BodyCell bodyCell = (BodyCell)LoadControl("BodyCell.ascx");
                bodyCell.DataTableLineArgs = DataTableLineArgs;
                bodyCell.Data = DataForALine[TableAttribute.LineToShow[i]].ToString();
                CellHolder.Controls.Add(bodyCell);
            }
            ControlFormCell controlFormCell = (ControlFormCell)LoadControl("ControlFormCell.ascx");
            controlFormCell.DataTableLineArgs = DataTableLineArgs;
            controlFormCell.CustomControls = CustomControls;
            CellHolder.Controls.Add(controlFormCell);
        }
    }
}