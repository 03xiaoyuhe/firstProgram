namespace DAL.DataObject.TableObject.AccountApart
{
    public class AccountBase : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                //AB_ID == 0 &&
                AccountName == string.Empty &&
                Password == string.Empty
                )
                return true;

            return false;
        }

        #region 属性及字段

        // 数据 ID 是未知的
        //int _AB_ID;
        ///// <summary>
        ///// 数据ID
        ///// </summary>
        //public int AB_ID
        //{
        //    get
        //    {
        //        return _AB_ID;
        //    }
        //    set
        //    {
        //        _AB_ID = value;
        //    }
        //}

        string _AccountName;
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountName
        {
            get
            {
                if (_AccountName == null) _AccountName = string.Empty;
                return _AccountName;
            }
            set
            {
                _AccountName = value;
            }
        }

        string _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get
            {
                if (_Password == null) _Password = string.Empty;
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        #endregion
    }
}
