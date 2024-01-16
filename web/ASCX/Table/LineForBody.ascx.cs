using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_LineForBody : ASCX_Table_LineForTable
{
    LineDateForTable theLineDateForTable;
    public LineDateForTable TheLineDateForTable
    {
        get
        {
            return theLineDateForTable;
        }
        set
        {
            theLineDateForTable = value;
        }
    }


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

    public int ColumnNum
    {
        get
        {
            return TheLineDateForTable.LineToShow.Count;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < Count; i++)
        {
            CellHolder.Controls.Add(this.Page.FindControl(ID + String.Format("_{0}", i)));
        }
        for (int i = Count; i < ColumnNum; i++)
        {
            ASCX_Table_CellForTable NewCell = (ASCX_Table_CellForTable)LoadControl("~/ASCX/Table/CellForTable.ascx");
            NewCell.ID = ID + String.Format("_{0}", i);
            NewCell.CellData = TheLineDateForTable.DataForALine[TheLineDateForTable.LineToShow[i]].ToString();
            CellHolder.Controls.Add(NewCell);
            Count++;
        }
        ASCX_Table_DeletButten newCell = (ASCX_Table_DeletButten)LoadControl("~/ASCX/Table/DeletButten.ascx");
        newCell.DataID = TheLineDateForTable.RowID;
        CellHolder.Controls.Add(newCell);
    }
}