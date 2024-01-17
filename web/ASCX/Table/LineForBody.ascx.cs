using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_LineForBody : System.Web.UI.UserControl
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


    DataRow dataRow;
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
            return dataRow[theLineDateForTable.IDLable].ToString();
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
        for (int i = 0; i < ColumnNum; i++)
        {
            ASCX_Table_CellForBody NewCell = (ASCX_Table_CellForBody)LoadControl("~/ASCX/Table/CellForBody.ascx");
            NewCell.ID = ID + String.Format("_{0}", i);
            NewCell.CellData = DataForALine[TheLineDateForTable.LineToShow[i]].ToString();
            CellHolder.Controls.Add(NewCell);
            Count++;
        }
        ASCX_Table_DeletButten newCell = (ASCX_Table_DeletButten)LoadControl("~/ASCX/Table/DeletButten.ascx");
        newCell.DataID = RowID;
        CellHolder.Controls.Add(newCell);
    }
}