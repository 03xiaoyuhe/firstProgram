namespace DAL.DataObject
{
    /// <summary>
    /// 数据对象基类，用于规定基础功能
    /// </summary>
    public abstract class DataObjectBase
    {
        /// <summary>
        /// 用于描述当前对象是否为空对象
        /// </summary>
        /// <returns>true 为空对象</returns>
        public abstract bool IsEmpty();

    }
}
