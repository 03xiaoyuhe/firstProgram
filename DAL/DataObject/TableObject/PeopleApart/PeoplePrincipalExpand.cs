namespace DAL.DataObject.TableObject.PeopleApart
{
    public class PeoplePrincipalExpand : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                //PE_ID == 0 &&
                PB_ID == 0 &&
                PE_Major == string.Empty &&
                PE_Speciality == string.Empty &&
                PE_Engage == string.Empty &&
                PE_Address == string.Empty &&
                PE_Employer == string.Empty &&
                PE_IsYouth == string.Empty &&
                PE_OfficePhone == string.Empty &&
                PE_MobilePhone == string.Empty &&
                PE_Email == string.Empty
                )
                return true;
            return false;
        }

        #region 属性及字段

        // 信息 ID 是未知的
        //int _PE_ID;
        ///// <summary>
        ///// 信息ID
        ///// </summary>
        //public int PE_ID
        //{
        //    get
        //    {
        //        return _PE_ID;
        //    }
        //    set
        //    {
        //        _PE_ID = value;
        //    }
        //}

        int _PB_ID;
        /// <summary>
        /// 人员信息表ID
        /// </summary>
        public int PB_ID
        {
            get
            {
                return _PB_ID;
            }
            set
            {
                _PB_ID = value;
            }
        }

        string _PE_Major;
        /// <summary>
        /// 专业
        /// </summary>
        public string PE_Major
        {
            get
            {
                if (_PE_Major == null) _PE_Major = string.Empty;
                return _PE_Major;
            }
            set
            {
                _PE_Major = value;
            }
        }

        string _PE_Speciality;
        /// <summary>
        /// 研究专长
        /// </summary>
        public string PE_Speciality
        {
            get
            {
                if (_PE_Speciality == null) _PE_Speciality = string.Empty;
                return _PE_Speciality;
            }
            set
            {
                _PE_Speciality = value;
            }
        }

        string _PE_Engage;
        /// <summary>
        /// 现从事专业
        /// </summary>
        public string PE_Engage
        {
            get
            {
                if (_PE_Engage == null) _PE_Engage = string.Empty;
                return _PE_Engage;
            }
            set
            {
                _PE_Engage = value;
            }
        }

        string _PE_Address;
        /// <summary>
        /// 职称
        /// </summary>
        public string PE_Address
        {
            get
            {
                if (_PE_Address == null) _PE_Address = string.Empty;
                return _PE_Address;
            }
            set
            {
                _PE_Address = value;
            }
        }

        string _PE_Employer;
        /// <summary>
        /// 通信地址
        /// </summary>
        public string PE_Employer
        {
            get
            {
                if (_PE_Employer == null) _PE_Employer = string.Empty;
                return _PE_Employer;
            }
            set
            {
                _PE_Employer = value;
            }
        }

        string _PE_IsYouth;
        /// <summary>
        /// 是否符合青年项目申报条件
        /// </summary>
        public string PE_IsYouth
        {
            get
            {
                if (_PE_IsYouth == null) _PE_IsYouth = string.Empty;
                return _PE_IsYouth;
            }
            set
            {
                _PE_IsYouth = value;
            }
        }

        string _PE_OfficePhone;
        /// <summary>
        /// 办公电话
        /// </summary>
        public string PE_OfficePhone
        {
            get
            {
                if (_PE_OfficePhone == null) _PE_OfficePhone = string.Empty;
                return _PE_OfficePhone;
            }
            set
            {
                _PE_OfficePhone = value;
            }
        }

        string _PE_MobilePhone;
        /// <summary>
        /// 手机
        /// </summary>
        public string PE_MobilePhone
        {
            get
            {
                if (_PE_MobilePhone == null) _PE_MobilePhone = string.Empty;
                return _PE_MobilePhone;
            }
            set
            {
                _PE_MobilePhone = value;
            }
        }

        string _PE_Email;
        /// <summary>
        /// 邮箱
        /// </summary>
        public string PE_Email
        {
            get
            {
                if (_PE_Email == null) _PE_Email = string.Empty;
                return _PE_Email;
            }
            set
            {
                _PE_Email = value;
            }
        }

        #endregion
    }
}
