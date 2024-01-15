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

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        for(int i = 0; i < RowsCount; i++)
        {

        }
    }

}