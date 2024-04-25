using Models.PageDataSor.BaseDelegate;
using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.DataTableControl.Trigger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForm.ASCX.Table.ForDataTable
{
    public class Trigger
    {

        /// <summary>
        /// 用于存放所有订阅的事件，注意！需要订阅！
        /// </summary>
        public event DataTableControl Controls;

        /// <summary>
        /// 触发该触发器时传递的参数
        /// </summary>
        public DataTableLineArgs DataTableLineArgs;

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