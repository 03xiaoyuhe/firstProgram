using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_Table : System.Web.UI.UserControl
{
    #region 自定义参数

    TableAttribute tableBase = null;
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


    public int RowsCount
    { 
        get
        {
            return TableBase.DataCollection.Rows.Count;
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
    protected void Page_Load(object sender, EventArgs e)
    {

        ASCX_Table_LineForHead NewHead = (ASCX_Table_LineForHead)LoadControl("~/ASCX/Table/LineForHead.ascx");
        NewHead.LineToShow = TableBase.LineToShow;
        NewHead.LineToMean = TableBase.LineToMean;
        HeadHolder.Controls.Add(NewHead);
        for (int i = 0; i < Count; i++)
        {
            BodyHolder.Controls.Add(this.Page.FindControl(ID + String.Format("_{0}", i)));
        }
        for (int i = Count; i < RowsCount; i++)
        {
            ASCX_Table_LineForBody NewLine = (ASCX_Table_LineForBody)LoadControl("~/ASCX/Table/LineForBody.ascx");
            NewLine.ID = ID + String.Format("_{0}", i);
            LineDateForTable lineDateForTable = new LineDateForTable();
            lineDateForTable.IDLable = TableBase.IDLable;
            lineDateForTable.DataForALine = TableBase.DataCollection.Rows[i];
            NewLine.TheLineDateForTable = lineDateForTable;
            BodyHolder.Controls.Add(NewLine);
            Count++;
        }
    }

}