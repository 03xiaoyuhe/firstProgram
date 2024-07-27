using Microsoft.Identity.Client;
using System.Data;

namespace DAL.DataObject
{
    /// <summary>
    /// 标识数据类当前工作状态
    /// </summary>
    public enum DataObjectState
    {
        /// <summary>
        /// 保存数据状态，即返回字段里的值
        /// </summary>
        SaveData,
        /// <summary>
        /// 转换状态，将DataTable里的数据转换为Data
        /// </summary>
        PraiseDateTableToData,
    }
    /// <summary>
    /// 数据对象基类，用于规定基础功能
    /// </summary>
    public abstract class DataObjectBase
    {

        public DataObjectState state = DataObjectState.SaveData;

        public int RowIndex = 0;
        /// <summary>
        /// 数据访问类当前的工作状态
        /// </summary>
        public DataObjectState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        /// <summary>
        /// 为处于转换状态的数据类绑定数据集
        /// </summary>
        public DataTable DataTable { get; set; }

        /// <summary>
        /// 用于描述当前对象是否为空对象
        /// </summary>
        /// <returns>true 为空对象</returns>
        public abstract bool IsEmpty();

    }
}
