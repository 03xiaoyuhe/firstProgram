using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataControl.Interface
{
    public interface IDataUpdate
    {
        /// <summary>
        /// 提供一个将指定数据ID的记录的指定字段替换为指定内容的功能
        /// </summary>
        /// <param name="ID">指定的数据ID</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="UpdateData">更新为</param>
        /// <returns>影响的条数</returns>
        int Update(int ID, String FieldName, String UpdateData);

        /// <summary>
        /// 将指定数据ID的记录的指定字段替换为UpdatePairs指定的内容
        /// </summary>
        /// <param name="ID">指定的数据ID</param>
        /// <param name="UpdatePairs">
        /// 要替换的内容<br/>
        /// - 格式：<br/>
        /// ----- pair.first:字段名<br/>
        /// ----- pair.second:将该字段名对应的值替换为
        /// </param>
        /// <returns>影响的条数</returns>
        int Update(int ID, List<KeyValuePair<string, string>> UpdatePairs);

        /// <summary>
        /// 将指定数据ID的记录的指定字段替换为Item对象里存放的数据
        /// </summary>
        /// <param name="ID">指定的数据ID</param>
        /// <param name="Item">要替换的内容</param>
        /// <returns>影响的条数</returns>
        int Update(int ID, Object Item);

        /// <summary>
        /// 提供一个将所有符合Where语句的记录的指定字段替换为指定内容的功能
        /// </summary>
        /// <param name="FieldName">字段名</param>
        /// <param name="UpdateData">更新为</param>
        /// <param name="Where">限制条件</param>
        /// <returns>影响的条数</returns>
        int Update(String FieldName, String UpdateData, String Where);

        /// <summary>
        /// 提供一个将所有符合Where语句的记录的指定字段替换为UpdatePairs指定的内容
        /// </summary>
        /// <param name="UpdatePairs">
        /// 要替换的内容<br/>
        /// - 格式：<br/>
        /// ----- pair.first :  字段名<br/>
        /// ----- pair.second :  将该字段名对应的值替换为
        /// </param>
        /// <param name="Where">限制条件</param>
        /// <returns>影响的条数</returns>
        int Update(List<KeyValuePair<string, string>> UpdatePairs, String Where);

        /// <summary>
        /// 提供一个将所有符合Where语句的记录的指定字段替换为Item对象里存放的数据
        /// </summary>
        /// <param name="Item">要替换的内容</param>
        /// <param name="Where">限制条件</param>
        /// <returns>影响的条数</returns>
        int Update(Object Item, String Where);

    }
}
