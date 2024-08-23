using DAL.DataObject.TableObject.PeopleApart;
using System.Data;

namespace DAL.DataObject.TableObject
{

    /// <summary>
    /// 人员信息
    /// </summary>
    public class PeopleData : DataObjectBase
    {
        public override bool IsEmpty()
        {
            if (Base.IsEmpty()) return true;
            return false;
        }

        #region 属性及字段


        public new DataObjectState State
        {
            get { return base.State; }
            set
            {
                base.State = value;
                Base.State = value;
                PrincipalExpand.State = value;
            }
        }

        public new DataTable DataTable
        {
            get { return base.DataTable; }
            set
            {
                base.DataTable = value;
                Base.DataTable = value;
                PrincipalExpand.DataTable = value;
            }
        }
        PeopleBase _Base;
        /// <summary>
        /// 人员基础信息
        /// </summary>
        public PeopleBase Base
        {
            get
            {
                if (_Base == null) _Base = new PeopleBase();
                return _Base;
            }
            set
            {
                _Base = value;
            }
        }

        PeoplePrincipalExpand _PrincipalExpand;
        /// <summary>
        /// 项目负责人拓展信息
        /// </summary>
        public PeoplePrincipalExpand PrincipalExpand
        {
            get
            {
                if (_PrincipalExpand == null) _PrincipalExpand = new PeoplePrincipalExpand();
                return _PrincipalExpand;
            }
            set
            {
                _PrincipalExpand = value;
            }
        }

        #endregion
    }
}
