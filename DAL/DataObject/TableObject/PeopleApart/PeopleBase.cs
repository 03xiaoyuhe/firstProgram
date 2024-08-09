namespace DAL.DataObject.TableObject.PeopleApart
{
    public class PeopleBase : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (
                //PB_ID == 0 &&
                PEB_Name == string.Empty &&
                PEB_Sex == string.Empty &&
                PEB_Birthday == string.Empty &&
                PEB_Job == string.Empty &&
                PEB_Title == string.Empty &&
                PEB_Employer == string.Empty
                )
            {
                return true;
            }
            return false;
        }

        #region 属性及字段

        // 信息 ID 是未知的

        // 在查询信息时  PB_ID 
        int _PB_ID;
        /// <summary>
        /// 信息ID
        /// </summary>
        public int PEB_ID
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
        string _PB_Name;
        /// <summary>
        /// 姓名
        /// </summary>
        public string PEB_Name
        {
            get
            {
                if (_PB_Name == null) _PB_Name = string.Empty;
                return _PB_Name;
            }
            set
            {
                _PB_Name = value;
            }
        }

        string _PB_Sex;
        /// <summary>
        /// 性别
        /// </summary>
        public string PEB_Sex
        {
            get
            {
                if (_PB_Sex == null) _PB_Sex = string.Empty;
                return _PB_Sex;
            }
            set
            {
                _PB_Sex = value;
            }
        }

        string _PB_Birthday;
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime PEB_Birthday
        {
            get
            {
                if (_PB_Birthday == null) _PB_Birthday = string.Empty;
                return _PB_Birthday;
            }
            set
            {
                _PB_Birthday = value;
            }
        }

        string _PB_Job;
        /// <summary>
        /// 职务
        /// </summary>
        public string PEB_Job
        {
            get
            {
                if (_PB_Job == null) _PB_Job = string.Empty;
                return _PB_Job;
            }
            set
            {
                _PB_Job = value;
            }
        }

        string _PB_Title;
        /// <summary>
        /// 职称
        /// </summary>
        public string PEB_Title
        {
            get
            {
                if (_PB_Title == null) _PB_Title = string.Empty;
                return _PB_Title;
            }
            set
            {
                _PB_Title = value;
            }
        }

        string _PB_Employer;
        /// <summary>
        /// 工作单位
        /// </summary>
        public string PEB_Employer
        {
            get
            {
                if (_PB_Employer == null) _PB_Employer = string.Empty;
                return _PB_Employer;
            }
            set
            {
                _PB_Employer = value;
            }
        }



        #endregion
    }
}
