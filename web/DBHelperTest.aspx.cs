using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DBHelperTest : System.Web.UI.Page
{
    public DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //创建一个临时数据库
            DataSet ds = new DataSet();
            //创建一个临时表
            dt = new DataTable();
            //datatable被new出来时是什么都没有的，需要添加行列

            //第一种添加方式 添加一列id号
            //添加自增主键
            DataColumn dcId = new DataColumn("id");
            dcId.AutoIncrement = true;//自增
            dcId.AutoIncrementSeed = 1;//种子
            dcId.AutoIncrementStep = 1;//步长
            dt.Columns.Add(dcId);//添加到dt中
            //第二种添加列的方式， 添加一列名字
            DataColumn cdName = new DataColumn("name", typeof(string));

            dt.Columns.Add(cdName);

            //第三种添加方式
            dt.Columns.Add("password", typeof(string));

            //添加行数据
            // DataRow row = new DataRow();这个种是不对的,new出来是没有格式的
            //原因是datarow的构造函数是protected的所以不能再外部new DataRow的对象
            DataRow row = dt.NewRow();
            row["name"] = "tian";
            row["password"] = "123456";
            dt.Rows.Add(row);

            //添加多行数据
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "LS" + i.ToString();
                dr["password"] = "456" + i.ToString();
                dt.Rows.Add(dr);
            }
            //把表添加到DataSet中
            ds.Tables.Add(dt);
        }

    }
}