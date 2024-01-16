using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// LineDateForTable 的摘要说明
/// </summary>
public class LineDateForTable
{
    #region 自定义参数

    string idLable = null;
    public string IDLable
    {
        get
        {
            return idLable;
        }
        set
        {
            idLable = value;
        }
    }


    public string RowID
    {
        get
        {
            return dataRow[IDLable].ToString();
        }
    }

    DataRow dataRow;
    public DataRow DataForALine
    {
        get
        {
            if (IDLable == null)
            {
                throw new Exception("未指定列主键标识");
            }
            return dataRow;
        }
        set
        {
            dataRow = value;
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
            if (IDLable == null)
            {
                throw (new Exception("自定义表格对象未指定主键"));
            }

            return lineToShow;
        }
        set
        {
            lineToShow = value;
        }
    }



    #endregion



    #region 私有函数


    List<string> TranslateValueColloctionToList(Dictionary<string, string>.ValueCollection values)
    {
        List<string> Values = new List<string>();
        if (values != null)
        {
            foreach (var item in values)
            {
                Values.Add(item);
            }
            return Values;
        }
        else
        {
            return null;
        }
    }

    void InitLineToMean()
    {
        Dictionary<string, string> line_to_ = new Dictionary<string, string>();
        foreach (DataColumn item in dataRow.Table.Columns)
        {
            line_to_.Add(item.ColumnName, item.ColumnName);
        }
    }

    #endregion

    public LineDateForTable()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

}