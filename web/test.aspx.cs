using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    void LoadTable()
    {
        DataSet dataSet = ProjectCompletion.ProjectVision();
        DataTable dataTable;
        try
        {
            dataTable = dataSet.Tables[0];
        }
        catch
        {
            dataTable = null;
        }
        List<string> list = new List<string>();
        list.Add("proposal_number");
        list.Add("project_title");
        list.Add("project_description");
        list.Add("team_id");
        list.Add("achievement_form");
        list.Add("achievement_brief");

        Dictionary<string, string> map = new Dictionary<string, string>();
        map.Add("proposal_number", "立项编号");
        map.Add("project_title", "项目主题");
        map.Add("project_description", "项目描述");
        map.Add("team_id", "小队id");
        map.Add("achievement_form", "成果形式");
        map.Add("achievement_brief", "成果简述");

        TableAttribute tableAttribute = new TableAttribute(
            "project_id",
            "项目信息",
            map,
            list
            );
        ASCX_Table_Table NewLine = (ASCX_Table_Table)LoadControl("~/ASCX/Table/Table.ascx");
        NewLine.TableBase = tableAttribute;
        NewLine.DataCollection = dataTable;
        NewLine.Height = 400;
        PlaceHolder1.Controls.Add(NewLine);
    }

    protected void PlaceHolder1_Load(object sender, EventArgs e)
    {
        LoadTable();
    }
}