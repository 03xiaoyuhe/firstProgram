using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ASCX_Table_LineForHead : System.Web.UI.UserControl
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

    public int ColumnNum
    {
        get { return lineToShow.Count; }
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
        for(int i = 0; i < ColumnNum; i++)
        {
            ASCX_Table_CellForTable NewCell = (ASCX_Table_CellForTable)LoadControl("~/ASCX/Table/CellForTable.ascx");
            NewCell.ID = ID + String.Format("_{0}", i);
            NewCell.CellData = LineToMean[lineToShow[i]];
            CellHolder.Controls.Add(NewCell);
            Count++;
        }
        ASCX_Table_CellForTable newCell = (ASCX_Table_CellForTable)LoadControl("~/ASCX/Table/CellForTable.ascx");
        newCell.CellData = "操作";
        CellHolder.Controls.Add(newCell);
    }
}