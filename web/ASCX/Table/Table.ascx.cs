using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_Table : System.Web.UI.UserControl
{
    #region 自定义参数
    int height;
    public int Height
    {
        get
        {
            if(height > 100) return height;
            else return 100;
        }
        set
        {
            height = value;
        }
    }
    DataTable dataCollection;
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
            if(dataCollection != null)
            {
                return DataCollection.Rows.Count;
            }
            return 0;
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
        Panel1.Height = (System.Web.UI.WebControls.Unit)Height;
        ASCX_Table_LineForHead NewHead = (ASCX_Table_LineForHead)LoadControl("~/ASCX/Table/LineForHead.ascx");
        NewHead.LineToShow = TableBase.LineToShow;
        NewHead.LineToMean = TableBase.LineToMean;
        HeadHolder.Controls.Add(NewHead);
        if(DataCollection != null)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                ASCX_Table_LineForBody NewLine = (ASCX_Table_LineForBody)LoadControl("~/ASCX/Table/LineForBody.ascx");
                NewLine.ID = ID + String.Format("_{0}", i);
                LineDateForTable lineDateForTable = new LineDateForTable();
                lineDateForTable.IDLable = TableBase.IDLable;
                lineDateForTable.LineToShow = TableBase.LineToShow;
                NewLine.DataForALine = DataCollection.Rows[i];
                NewLine.TheLineDateForTable = lineDateForTable;
                BodyHolder.Controls.Add(NewLine);
                Count++;
            }
        }
        else
        {
            NullMassage.Visible = true;
        }
    }

}