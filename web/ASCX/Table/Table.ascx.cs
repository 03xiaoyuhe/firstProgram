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


    DataTable dataCollection;
    public DataTable DataCollection
    {
        get
        {
            if (dataCollection == null)
            {
                throw (new Exception("自定义表格对象未绑定数据"));
            }

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
            return DataCollection.Rows.Count;
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

}