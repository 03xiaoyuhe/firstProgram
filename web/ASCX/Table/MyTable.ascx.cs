using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table
{
    public partial class MyTable : System.Web.UI.UserControl
    {

        #region 自定义参数


        #region 表格样式参数

        int height;
        public int Height
        {
            get
            {
                if (height > 100) return height;
                else return 100;
            }
            set
            {
                height = value;
            }
        }

        #endregion


        #region 表格数据绑定属性

        DataTable dataCollection;
        /// <summary>
        /// 表单数据集
        /// </summary>
        public DataTable DataCollection
        {
            get
            {
                return dataCollection;
            }

            set
            {
                dataCollection = value;
            }
        }

        TableAttribute tableBase = null;
        /// <summary>
        /// 绑定数据说明属性
        /// </summary>
        public TableAttribute TableBase
        {
            get
            {
                return tableBase;
            }
            set
            {
                tableBase = value;
            }
        }

        #region 解释绑定数据属性

        /// <summary>
        /// 解释主键字段名
        /// </summary>
        public string IDLable
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
        /// 解释绑定数据库对应表单
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


        /// <summary>
        /// 解释数据总行数
        /// </summary>
        public int RowsCount
        {
            get
            {
                if (dataCollection != null)
                {
                    return DataCollection.Rows.Count;
                }
                return 0;
            }
        }

        #endregion

        #endregion

        #region 其他 如控制性属性

        bool showControl;
        /// <summary>
        /// 是否要显示控制行
        /// </summary>
        public bool ShowControl
        {
            get
            {
                return showControl;
            }
            set
            {
                showControl = value;
            }
        }

        string controlASCX;
        /// <summary>
        /// 绑定功能列的组件
        /// </summary>
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

        int Count
        {
            get
            {
                if (ViewState["TableLineControlCount"] == null)
                    ViewState["TableLineControlCount"] = 0;
                return (int)ViewState["TableLineControlCount"];
            }
            set
            {
                ViewState["TableLineControlCount"] = value;
            }
        }

        #endregion

        #endregion

        #region 自定义事件

        public event EventHandler DataChanged;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> NewLineToShow = new List<string>();
            foreach(string item in TableBase.LineToShow)
            {
                if (DataCollection.Columns.Contains(item)) NewLineToShow.Add(item);
            }
            TableBase.LineToShow = NewLineToShow;
            HeadHolder.Controls.Clear();
            Panel1.Height = (System.Web.UI.WebControls.Unit)Height;
            stickytable.Style["height"] = Height + "px";
            LineForHead NewHead = (LineForHead)LoadControl("~/ASCX/Table/ForMyTable/LineForHead.ascx");
            NewHead.LineToShow = TableBase.LineToShow;
            NewHead.LineToMean = TableBase.LineToMean;
            NewHead.ShowControl = ShowControl;
            HeadHolder.Controls.Add(NewHead);
            if (DataCollection != null)
            {
                if (RowsCount == 0)
                {
                    NullMassage.Visible = true;
                }
                for (int i = 0; i < RowsCount; i++)
                {
                    LineForBody NewLine = (LineForBody)LoadControl("~/ASCX/Table/ForMyTable/LineForBody.ascx");
                    NewLine.ID = ID + String.Format("_{0}", i);
                    NewLine.DataForALine = DataCollection.Rows[i];
                    NewLine.TheLineDateForTable = TableBase;
                    NewLine.ShowControl = ShowControl;
                    NewLine.ControlASCX = ControlASCX;
                    BodyHolder.Controls.Add(NewLine);
                    Count++;
                }
            }
            else
            {
                Massage massage = new Massage("#ff0000", "ERRO", "未将数据绑定到表格");
                massage.PostMassage();
            }
        }

    }
}