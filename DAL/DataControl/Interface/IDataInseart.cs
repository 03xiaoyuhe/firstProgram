using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataControl.Interface
{
    public interface IDataInseart
    {
        /// <summary>
        /// 插入指定内容
        /// </summary>
        /// <param name="DataPairs">
        /// 需要插入的所有数据<br/>
        /// - 格式要求<br/>
        /// ----- pair.first :  指定的字段<br/>
        /// ----- pair.second : 插入行的指定字段的值
        /// </param>
        /// <returns>影响的行数</returns>
        int Inseart(params KeyValuePair<String, String>[] DataPairs);


        /// <summary>
        /// 插入指定内容
        /// </summary>
        /// <param name="Item">插入的指定表的数据对象</param>
        /// <returns>影响的行数</returns>
        int Inseart(Object Item);
    }
}
