using Models;
using System;
using System.Data;
using WebForm.ASCX.Table.ForMyTable;

namespace WebForm.ASCX.Table
{
    public partial class LineForBody : System.Web.UI.UserControl
    {
        #region 数据绑定属性

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
            }
        }

        TableAttribute tableBase;
        /// <summary>
        /// 解释数据集
        /// </summary>
        public TableAttribute TableBase
        {
            get { return tableBase; }
            set { tableBase = value; }
        }

        /// <summary>
        /// 行数据绑定解释<br/>
        /// 保留接口减小改动
        /// </summary>
        public TableAttribute TheLineDateForTable
        {
            get
            {
                return TableBase;
            }
            set
            {
                TableBase = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string IdLable
        {
            get
            {
                return TableBase.IDLable;
            }
            set
            {
                TableBase.IDLable = value;
            }
        }


        /// <summary>
        /// 绑定数据库对应表单
        /// </summary>
        public string TableName
        {
            get
            {
                if (TableBase.DataBase == null) throw new Exception("表格未绑定表单");
                return TableBase.DataBase;
            }
            set
            {
                TableBase.DataBase = value;
            }
        }

        #endregion

        int Count
        {
            get
            {
                if (ViewState["BodyCellControlCount"] == null)
                    ViewState["BodyCellControlCount"] = 0;
                return (int)ViewState["BodyCellControlCount"];
            }
            set
            {
                ViewState["BodyCellControlCount"] = value;
            }
        }


        public string RowID
        {
            get
            {
                return DataForALine[TheLineDateForTable.IDLable].ToString();
            }
        }
        public int ColumnNum
        {
            get
            {
                return TheLineDateForTable.LineToShow.Count;
            }
        }


        /// <summary>
        /// 绑定功能列的组件
        /// </summary>
        string controlASCX;
        public string ControlASCX
        {
            get
            {
                return controlASCX;
            }
            set
            {
                controlASCX = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            CellHolder.Controls.Clear();
            for (int i = 0; i < ColumnNum; i++)
            {
                CellForBody NewCell = (CellForBody)LoadControl("~/ASCX/Table/ForMyTable/CellForBody.ascx");
                NewCell.ID = ID + String.Format("_{0}", i);
                NewCell.CellData = DataForALine[TheLineDateForTable.LineToShow[i]].ToString();
                CellHolder.Controls.Add(NewCell);
                Count++;
            }
            ControlBase newCell = (ControlBase)LoadControl("~/ASCX/Table/ForMyTable/DeletButten.ascx");
            newCell.ID = ID + String.Format("_{0}", ColumnNum);
            newCell.DataID = RowID;
            newCell.TableName = TableName;
            newCell.IDLable = IdLable;
            CellHolder.Controls.Add(newCell);
        }
    }
}