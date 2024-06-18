namespace DAL.DataObject.TableObject
{
    /// <summary>
    /// 账号数据
    /// </summary>
    public class AccountData : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                AccountBase.IsEmpty()
                )
                return true;

            return false;
        }

        #region 属性及字段

        AccountApart.AccountBase _AccountBase;
        /// <summary>
        /// 账号基础信息
        /// </summary>
        public AccountApart.AccountBase AccountBase
        {
            get
            {
                if (_AccountBase == null) _AccountBase = new AccountApart.AccountBase();
                return _AccountBase;
            }
            set
            {
                _AccountBase = value;
            }
        }

        #endregion
    }
}
