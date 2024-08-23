using Models.PageDataSor.DataTableControl.ForControlAttribute;

namespace Models.PageDataSor.DataTableControl.Trigger
{
    public delegate void DataTableLineControlDo(object s, DataTableLineArgs dataTableLineArgs);

    /// <summary>
    /// 表格行事件触发器抽象类
    /// </summary>
    public abstract class DataTableLineTrigger
    {
        /// <summary>
        /// 用于存放所有订阅的事件，注意！需要订阅！
        /// </summary>
        public event DataTableLineControlDo Controls;


        /// <summary>
        /// 事件所需参数
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
