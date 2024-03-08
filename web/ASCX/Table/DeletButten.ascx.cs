using DAL;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_DeletButten : System.Web.UI.UserControl
{

    #region 参数成员

    /// <summary>
    /// 绑定数据库对应表单
    /// </summary>
    string tableName = null;
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

    string dataID;
    public string DataID
    {
        get
        {
            return dataID;
        }
        set
        {
            dataID = value;
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DataID == null) throw new Exception("删除按钮(" + ID + ")未指定数据项ID");
    }



    protected void DeletButton_Click(object sender, EventArgs e)
    {
        if (ProjectCompletion.ProjectDeteleVision(DataID))
        {
            Massage message = new Massage("Blue", "Success", "删除成功，请刷新页面");
            message.PostMassage();

        }  
        else
        {

            Massage message = new Massage("Red", "ERROR", "删除失败");
            message.PostMassage();
        }
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        string gotoURL = "?";
        Response.Redirect(gotoURL);
    }
}
