using DAL;
using System;
using System.Data;

public partial class ASCX_RoughImformation : System.Web.UI.UserControl
{
    static public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //创建一个临时数据库
        DataSet ds;
        ds = DBHelper.Query("select *from UserLogin;");

        //创建一个临时表
        dt = ds.Tables[0];
        string[] strColumns = null;
        if (dt.Columns.Count > 0)
        {
            int columnNum = 0;
            columnNum = dt.Columns.Count;
            strColumns = new string[columnNum];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                strColumns[i] = dt.Columns[i].ColumnName;
            }
        }
    }
}