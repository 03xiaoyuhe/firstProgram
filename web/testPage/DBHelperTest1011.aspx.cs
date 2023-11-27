using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using System.Collections;

public partial class DBHelperTest : System.Web.UI.Page
{
    public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //创建一个临时数据库
            DataSet ds;
            ds = DBHelper.Query("select *from ProjectApplications;");

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
            this.HyperLink2.Text = strColumns.Length.ToString();
            this.HyperLink1.Text = dt.Rows.Count.ToString();
        }
    }
}

