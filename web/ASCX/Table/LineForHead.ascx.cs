using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ASCX_Table_LineForHead : ASCX_Table_LineForTable
{

    Dictionary<string, string> lineToMean = null;
    /// <summary>
    /// 表格列信息 以及对应中文
    /// </summary>
    public Dictionary<string, string> LineToMean
    {
        get
        {
            return lineToMean;
        }
        set
        {
            lineToMean = value;
        }
    }

    List<string> lineToShow = null;
    /// <summary>
    /// 设置需要显示的列以及显示顺序<br/>
    /// 注:使用表的字段名
    /// </summary>
    public List<string> LineToShow
    {
        get
        {
            return lineToShow;
        }
        set
        {
            lineToShow = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}