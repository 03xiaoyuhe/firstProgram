using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

public partial class account_exceltodbfnew : System.Web.UI.Page
{
    string dr1,dr2;
    Datacon dataconn = new Datacon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role1"].ToString() != "管理员")
        {
            string notice1 = "你不是管理员,没有使用该功能得权限！！";
            Page.Response.Redirect("../intronotice.aspx?notice=" + notice1);
            return;
        }
        if (!IsPostBack)
        {
            this.RadioButtonList1.Items[0].Selected = true;
            dr1 = Server.MapPath("..") + "\\源excel文件";
            FindFile(dr1);
            dr2 = Server.MapPath("..") + "\\App_Data";
            FindFile2(dr2);
            this.ListBox2.Items[0].Selected = true;


            //DataSet dd = new DataSet();
            //SqlConnection conn2 = dataconn.getcon();
            //conn2.Open();
            //dd.Clear();
            //SqlDataAdapter myadapterzaixian = new SqlDataAdapter("select * from examstu_infosource", conn2);
            ////SqlDataAdapter myadapterzaixian = new SqlDataAdapter("select * from " + ListBox3.SelectedValue.ToString().Trim(), conn2);

            //myadapterzaixian.Fill(dd);
            //grid1.Visible = true;
            //GridView1.DataSource = dd;
            //GridView1.DataBind();
            //conn2.Close();
        }

    }
    public void FindFile(string dir)
    {
        ListBox1.Items.Clear();
        DirectoryInfo Dir = new DirectoryInfo(dir);
        try
        {
            foreach (FileInfo f in Dir.GetFiles("*.xls"))
            {
                ListBox1.Items.Add(f.ToString());
            }
            foreach (FileInfo f in Dir.GetFiles("*.xlsx"))
            {
                ListBox1.Items.Add(f.ToString());
            }
        }
        catch
        {
            return;
        }
    }
    public void FindFile2(string dir)
    {
        ListBox2.Items.Clear();
        DirectoryInfo Dir = new DirectoryInfo(dir);
        try
        {
            foreach (FileInfo f in Dir.GetFiles("*.mdf"))
            {
                ListBox2.Items.Add(f.ToString());
            }
        }
        catch
        {
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)   //导入
    {
        bool liststate = false;
        foreach (ListItem item in this.ListBox3.Items)
        {
            if(item.Selected)
            {
                liststate = true;
            }
        }
        if (!liststate)
        {
            ClientScript.RegisterStartupScript(this.GetType(), null, "<script>alert(\"没有选中数据表名！\");</script>");
            return;
        }
        if (RadioButtonList1.SelectedValue == "覆盖")
        {
            Datacon dataconn = new Datacon();
            SqlConnection conn1 = dataconn.getcon();
            conn1.Open();
            string strSql2 = "delete from " + ListBox3.SelectedValue.ToString().Trim();
            SqlCommand com1 = new SqlCommand(strSql2, conn1);
            com1.ExecuteNonQuery();
            conn1.Close();
        }

        try
        {
            //if (this.fulImport.HasFile)
            //{
                DataTable dt = new DataTable();
            //int len = this.fulImport.FileName.ToString().Trim().Length;
            //string path = "~/" + this.fulImport.FileName.ToString().Trim();
              string path = Server.MapPath("..") + "\\源excel文件\\" + ListBox1.SelectedValue.ToString().Trim();


              //path = Server.MapPath(path);

               //this.fulImport.SaveAs(path); //上传文件

                dt = InputExcel(path, this.ListBox3.SelectedValue.ToString().Trim());

                string[] chMsg = HiddenField2.Value.ToString().Trim().Split(new char[] { 'ζ' });//分离程序填空答案
                int k = int.Parse(HiddenField3.Value.ToString());

                for (int i = 0; i < dt.Rows.Count; i++)//循环读取xls文件中的数据
                {
                    string value1 = "'";
                    for (int j = 1; j <= k; j++)
                    {
                        value1 = value1 + dt.Rows[i][chMsg[j]].ToString() + "','";
                        // TextBox8.Text = chMsg[j];
                    }
                    value1 = value1.Substring(0, value1.Length - 1);
                    value1 = value1.Substring(0, value1.Length - 1);

                    string strSql = "INSERT INTO " + ListBox3.SelectedValue.ToString().Trim() + "(" + HiddenField1.Value.ToString() + ") VALUES( " + value1.ToString().Trim() + " )";

                    SqlConnection conn = dataconn.getcon();
                    conn.Open();
                    SqlCommand com = new SqlCommand(strSql, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                }
               // flag1 = "1";
            // ClientScript.RegisterStartupScript(this.GetType(), null, "<script>alert(\"数据导入成功！\");</script>");


            //}
            //else
            //    throw new Exception("请选择导入表的路径");
        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript'>alert('" + ex.Message + "');</script>");
        }
        Response.Write("<script language='javascript'>alert('" + "数据导入成功！" + "');</script>");

        DataSet dd = new DataSet();
        SqlConnection conn2 = dataconn.getcon();
        conn2.Open();
        dd.Clear();
        //SqlDataAdapter myadapterzaixian = new SqlDataAdapter("select * from examstu_infosource", conn2);
        SqlDataAdapter myadapterzaixian = new SqlDataAdapter("select * from " + ListBox3.SelectedValue.ToString().Trim(), conn2);

        myadapterzaixian.Fill(dd);
        grid1.Visible = true;
        GridView1.DataSource = dd;
        GridView1.DataBind();
        conn2.Close();
       
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string path = Server.MapPath("..") + "\\源excel文件\\" + ListBox1.SelectedValue.ToString().Trim();
        string strFilename = ListBox1.SelectedValue.ToString().Trim().ToLower();
        string strConn = "";
        if (strFilename.Substring(strFilename.LastIndexOf('.') + 1) == "xls")
        {
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties=Excel 8.0;";
        }
        else
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;"+"Data Source=" + path + ";" + "Extended Properties=Excel 12.0;";


        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        System.Data.DataTable dt = null;
        dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        String[] excelSheets = new String[dt.Rows.Count];
        int i = 0;
        ListBox3.Items.Clear();
        foreach (DataRow row in dt.Rows)
        {
            ListBox3.Items.Add(row["TABLE_NAME"].ToString().ToString().TrimEnd('$'));
            // Response.Write(row["TABLE_NAME"].ToString());
            i++;
        }
        if (conn != null)
        {
            conn.Close();
            conn.Dispose();
        }
        if (dt != null)
        {
            dt.Dispose();
        }
        conn.Close();
    }
    public DataTable InputExcel(string Path, string TableName)
    {
        try
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            //string tablename2 = TextBox1.Text.ToString().Trim();
            OleDbDataAdapter myCommand = null;
            //if (tablename2.Length > 0 && !tablename2.Equals(string.Empty))
            //    TableName = tablename2;
            strExcel = "select * from [" + TableName + "$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            DataTable dt = new DataTable();
            myCommand.Fill(dt);
            conn.Close();

            string strfiledname = "";
            string strfiledvalue = "ζ";
            int m = 0;
            foreach (DataColumn str1 in dt.Columns)
            {
                strfiledname = strfiledname + str1.Caption + ",";
                strfiledvalue = strfiledvalue + str1.Caption + "ζ";
                m = m + 1;
            }
            strfiledname = strfiledname.Substring(0, strfiledname.Length - 1);
            HiddenField1.Value = strfiledname;  //字段名列表
            HiddenField2.Value = strfiledvalue; //字段值列表
            HiddenField3.Value = (m).ToString(); //字段个数

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)  //上传文件到服务器
    {
       
            UpLoadFile_teacher();
       
    }
    protected void FolderCreate(string Path)
    {
        // 判断目标目录是否存在如果不存在则新建之   
        if (!Directory.Exists(Path))
            Directory.CreateDirectory(Path);
    }
    private void UpLoadFile_teacher()// 管理员和教师上传文件到公共区
    {


        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile != null)
            {
                string str = Server.MapPath("..") + "\\源excel文件\\";
                this.FolderCreate(str);
                HttpPostedFile hpf = this.FileUpload1.PostedFile;
                string FileSize = Convert.ToString(Convert.ToInt32(hpf.ContentLength.ToString()) / 1024);// +"KB";
                //取得文件名（不含路径）

                char[] de = { '\\' };
                string[] AFilename = hpf.FileName.Split(de);
                string strFilename = AFilename[AFilename.Length - 1];
                string flag = strFilename.Substring(strFilename.LastIndexOf('.') + 1);
                ViewState["FileFlag"] = flag;//文件的后缀名
                ViewState["FileSize"] = FileSize; //文件的大小
                string strFilename1 = strFilename.Substring(0, strFilename.LastIndexOf('.'));
                hpf.SaveAs(str.Trim() + "\\" + strFilename);//上传至服务器
                string dateStr = string.Format(DateTime.Now.ToString("yyyy") + @"\" + DateTime.Now.ToString("MM") + @"\" + DateTime.Now.ToString("dd") + @"\");
                Session["FileName"] = strFilename; //资料名（原名）
                ClientScript.RegisterStartupScript(this.GetType(), null, "<script>alert(\"资料上传成功！\");</script>");

                int count = ListBox1.Items.Count;
                int index = 0;
                for (int i = 0; i < count; i++)
                {
                    ListItem item = ListBox1.Items[index];
                    //移除列表框中的列表项
                    ListBox1.Items.Remove(item);

                }


                dr1 = Server.MapPath("..") + "\\源excel文件";
                FindFile(dr1);


                return;


            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), null, "<script>alert(\"请选择要上传的文件！！！\");</script>");
        }

    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
            dr1 = Server.MapPath("..") + "\\源excel文件\\";
            if (ListBox1.SelectedValue.ToString().Trim() != "")
            {
                System.IO.File.Delete(dr1 + "\\" + ListBox1.SelectedValue.ToString().Trim());

                int count = ListBox1.Items.Count;
                int index = 0;
                for (int i = 0; i < count; i++)
                {
                    ListItem item = ListBox1.Items[index];
                    //移除列表框中的列表项
                    ListBox1.Items.Remove(item);

                }
                FindFile(dr1);
            }
       
    }
}