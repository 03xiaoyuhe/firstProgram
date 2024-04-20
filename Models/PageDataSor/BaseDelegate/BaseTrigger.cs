using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.DataTableControl.Trigger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Models.PageDataSor.BaseDelegate
{
    /// <summary>
    /// 触发器委托
    /// </summary>
    /// <typeparam name="K">事件所需参数组的类型</typeparam>
    /// <param name="s">触发的对象</param>
    /// <param name="dataTableLineArgs"></param>
    public delegate void BaseTriggerEvent<K>(object s, K dataTableLineArgs);

    /// <summary>
    /// 触发器抽象类泛型
    /// </summary>
    /// <typeparam name="K">触发事件时传递的事件参数组类型</typeparam>
    public abstract class BaseTrigger<K>
    {
        /// <summary>
        /// 用于存放所有订阅的事件，注意！需要订阅！
        /// </summary>
        public event BaseTriggerEvent<K> Controls;

        /// <summary>
        /// 触发该触发器时传递的参数
        /// </summary>
        public K DataTableLineArgs;

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="s">触发事件的对象</param>
        /// <param name="dataTableLineArgs">触发事件后传的参</param>
        public void IsTrigger(object s)
        {
            Controls(s, DataTableLineArgs);
        }
    }
}
