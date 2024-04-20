using Models.PageDataSor.DataTableControl.ForControlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.DataTableControl
{
    /// <summary>
    /// 支持传参的委托
    /// </summary>
    /// <param name="s">触发事件的变量</param>
    /// <param name="args">触发后的传参</param>
    public delegate void DataTableControl<K>(object s, K args);

    /// <summary>
    /// 表格控制对象
    /// </summary>
    /// <typeparam name="K">事件所需参数类型</typeparam>
    public class DataTableControlAttribute<K>
    {
        public DataTableControlAttribute()
        {
            ControlName = typeof(DataTableControlAttribute<K>).Name;
        }

        /// <summary>
        /// 使用事件的构造函数，名字默认为对象名
        /// </summary>
        /// <param name="control">需要传入的委托</param>
        public DataTableControlAttribute(DataTableControl<K> control)
        {
            DataTableControls = control;
            ControlName = typeof(DataTableControlAttribute<K>).Name;
        }

        /// <summary>
        /// 使用操作名与委托构造
        /// </summary>
        /// <param name="dataTableControls">委托</param>
        /// <param name="controlName">操作名</param>
        public DataTableControlAttribute(DataTableControl<K> dataTableControls, string controlName) : this(dataTableControls)
        {
            ControlName = controlName;
        }

        public DataTableControlAttribute(DataTableControlAttribute<K> dataTableControlAttribute)
        {
            DataTableControls = dataTableControlAttribute.DataTableControls;
        }


        /// <summary>
        /// 数据表列操作集
        /// </summary>
        public DataTableControl<K> DataTableControls;


        /// <summary>
        /// 数据表操作集名称
        /// </summary>
        public string ControlName;
    }
}
