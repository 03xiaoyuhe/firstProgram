using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.DataTableControl.ForControlAttribute
{
    /// <summary>
    /// 表格自定义事件自定义传参<br/>
    /// 属性：TableAttribute ---> 存放本表格描述对象<br/>
    /// 属性：LineNo  ---> 用于存放触发事件的行的主键
    /// </summary>
    public class DataTableLineArgs : EventArgs
    {
        public DataTableLineArgs() { }

        /// <summary>
        /// 通过表格描述对象以及行号构造参数表
        /// </summary>
        /// <param name="tableAttribute"></param>
        /// <param name="lineNo"></param>
        public DataTableLineArgs(TableAttribute tableAttribute, int lineNo)
        {
            TableAttribute = tableAttribute;
            LineNo = lineNo;
        }

        TableAttribute tableAttribute = new TableAttribute();
        /// <summary>
        /// 数据表解释基本信息
        /// </summary>
        public TableAttribute TableAttribute
        {
            get { return tableAttribute; }
            set { tableAttribute = value; }
        }

        int lineNo = -1;
        /// <summary>
        /// 本行的ID
        /// </summary>
        public int LineNo
        {
            get
            {
                return lineNo;
            }
            set
            {
                lineNo = value;
            }
        }
    }
}
