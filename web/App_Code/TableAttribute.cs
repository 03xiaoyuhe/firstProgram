using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// TableAttribute <br/>
/// 表格信息属性
/// </summary>
public class TableAttribute
{

    #region 参数成员

    /// <summary>
    /// 数据表 表名
    /// </summary>
    public string DataBase { get; set; }


    string idLable = null;
    string IDLable
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

    DataTable dataCollection = null;
    public DataTable DataCollection
    {
        get
        {
            if(dataCollection == null)
            {
                throw (new Exception("自定义表格对象未绑定数据"));
            }

            if(IDLable == null)
            {
                throw (new Exception("自定义表格对象未指定主键"));
            }
            return dataCollection;
        }

        set
        {
            dataCollection = value;
            if (lineToMean == null)
            {
                InitLineToMean();
            }
        }
    }

    Dictionary<string, string> lineToMean = null;
    /// <summary>
    /// 表格列信息 以及对应中文
    /// </summary>
    public Dictionary<string, string> LineToMean
    {
        get
        {
            if (dataCollection == null)
            {
                throw (new Exception("表格对象未绑定数据"));
            }

            if (IDLable == null)
            {
                throw (new Exception("自定义表格对象未指定主键"));
            }

            if (lineToMean == null)
            {
                InitLineToMean();
            }

            return lineToMean;
        }
        set
        {
            lineToMean = value;
            if(LineToShow == null)
            {
                LineToShow = TranslateValueColloctionToList(value.Values);
            }
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
            if (dataCollection == null)
            {
                throw (new Exception("表格对象未绑定数据"));
            }

            if (IDLable == null)
            {
                throw (new Exception("自定义表格对象未指定主键"));
            }

            if (lineToShow == null)
            {
                lineToShow = TranslateValueColloctionToList(LineToMean.Values);
            }

            return lineToShow;
        }
        set
        {
            lineToShow = value;
        }
    }

    public int ColumnNum
    {
        get { return lineToShow.Count(); }
    }

    #endregion


    #region 函数成员

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="data_collection">表格数据表</param>
    /// <param name="data_base">表名</param>
    /// <param name="line_to_mean">字段名对应的列名</param>
    /// <param name="line_to_show">需要展示的列以及顺序 (以字段名标识)</param>
    public TableAttribute(
        DataTable data_collection,
        string data_base = null,
        Dictionary<string, string> line_to_mean = null,
        List<string> line_to_show = null
        )
    {
        DataCollection = data_collection;
        if (data_base != null) { DataBase = data_base; }
        if (data_collection != null) { DataCollection = data_collection; }
        if (line_to_mean != null) { LineToMean = line_to_mean; }
        if (line_to_show != null) { LineToShow = line_to_show; }
    }


    List<string> TranslateValueColloctionToList(Dictionary<string,string>.ValueCollection values)
    {
        List<string> Values = new List<string>();
        if(values != null)
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
        foreach (DataColumn item in DataCollection.Columns)
        {
            line_to_.Add(item.ColumnName, item.ColumnName);
        }

        LineToMean.Clear();
        LineToMean = line_to_;
    }
    #endregion
}