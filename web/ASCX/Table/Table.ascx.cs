using System;
using System.Collections.Generic;
using System.Data;
using MyWeb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_Table : System.Web.UI.UserControl
{
    #region 自定义参数

    /// <summary>
    /// 主键字段名，查询/修改TableBase.IDLable
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
    /// 绑定数据库对应表单
    /// </summary>
    string tableName=null;
    public string TableName
    {
        get
        {
            if (tableName == null) throw new Exception("表格未绑定表单");
            return tableName;
        }
        set
        {
            tableName = value;
        }
    }

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
            if(RowsCount == 0 )
            {
                NullMassage.Visible = true;
            }
            for (int i = 0; i < RowsCount; i++)
            {
                ASCX_Table_LineForBody NewLine = (ASCX_Table_LineForBody)LoadControl("~/ASCX/Table/LineForBody.ascx");
                NewLine.ID = ID + String.Format("_{0}", i);
                LineDateForTable lineDateForTable = new LineDateForTable();
                lineDateForTable.IDLable = TableBase.IDLable;
                lineDateForTable.LineToShow = TableBase.LineToShow;
                NewLine.DataForALine = DataCollection.Rows[i];
                NewLine.TheLineDateForTable = lineDateForTable;
                NewLine.TableName = TableName;
                NewLine.IdLable = IDLable;
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