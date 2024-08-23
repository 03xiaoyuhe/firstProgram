using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class LineDateBase : TableAttribute
    {


        DataRow dataRow;
        /// <summary>
        /// 行数据集
        /// </summary>
        public DataRow DataForALine
        {
            get
            {
                return dataRow;
            }
            set
            {
                dataRow = value;
            }
        }

        public LineDateBase(
            string iDlable,
            DataRow dataRow,
            string data_base = null,
            Dictionary<string, string> line_to_mean = null,
            List<string> line_to_show = null
            ) : base(iDlable, data_base, line_to_mean, line_to_show)
        {
            this.dataRow = dataRow;
        }

        public LineDateBase(TableAttribute tableAttribute, DataRow dataRow)
            : base(tableAttribute.IDLable, tableAttribute.DataBase, tableAttribute.LineToMean, tableAttribute.LineToShow)
        {
            this.dataRow = dataRow;
        }
    }
}
