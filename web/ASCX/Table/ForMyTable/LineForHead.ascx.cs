using Models.PageDataSor;
using System;
using System.Collections.Generic;
using WebForm.ASCX.Table.ForMyTable;

namespace WebForm.ASCX.Table
{
    public partial class LineForHead : System.Web.UI.UserControl
    {

        Dictionary<string, string> lineToMean = null;
        /// <summary>
        /// 表格列信息 以及对应中文
        /// </summary>
        public Dictionary<string, string> LineToMean
        {
            get
            {
                return lineToMean;
            }
            set
            {
                lineToMean = value;
            }
        }

        List<string> lineToShow = null;
        /// <summary>
        /// 设置需要显示的列以及显示顺序<br/>
        /// 注:使用表的字段名
        /// </summary>
        public List<string> LineToShow
        {
            get
            {
                return lineToShow;
            }
            set
            {
                lineToShow = value;
            }
        }


        bool showControl = false;
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

        public int ColumnNum
        {
            get { return lineToShow.Count; }
        }


        string choosedDataID;
        /// <summary>
        /// 复选框缓存
        /// </summary>
        public string ChoosedDataID
        {
            get
            {
                return choosedDataID;
            }
            set
            {
                choosedDataID = value;
            }
        }

        int Count
        {
            get
            {
                if (ViewState["HeadControlCount"] == null)
                    ViewState["HeadControlCount"] = 0;
                return (int)ViewState["HeadControlCount"];
            }
            set
            {
                ViewState["HeadControlCount"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            CheckBoxTree checkBox = (CheckBoxTree)LoadControl("~/ASCX/Table/ForMyTable/CheckBoxTree.ascx");

            CellHolder.Controls.Add(checkBox);

            for (int i = 0; i < ColumnNum; i++)
            {
                CellForHead NewCell = (CellForHead)LoadControl("~/ASCX/Table/ForMyTable/CellForHead.ascx");
                NewCell.ID = ID + String.Format("_{0}", i);
                NewCell.CellData = LineToMean[lineToShow[i]];
                CellHolder.Controls.Add(NewCell);
                Count++;
            }
            if (ShowControl)
            {
                CellForHead newCell = (CellForHead)LoadControl("~/ASCX/Table/ForMyTable/CellForHead.ascx");
                newCell.CellData = "操作";
                CellHolder.Controls.Add(newCell);
            }
        }

    }
}