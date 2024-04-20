using Models.PageDataSor.DataTableControl.ForControlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.BaseDelegate
{
    public abstract class BaseListener<K>
    {


        /// <summary>
        /// 表格行事件触发器抽象类
        /// </summary>
        /// <summary>
        /// 侦听到事件后的处理
        /// </summary>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="e">事件所需参数</param>
        public abstract void Control(object sender, K e);
    }
}
