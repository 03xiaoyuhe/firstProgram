using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ProgremData
{
    /// <summary>
    /// 项目负责人数据对象
    /// </summary>
    public class DataForAdm
    {

        //[Description("标题颜色"), Category("自定义属性")]
        string admName;
        [Description("负责人姓名"), Category("自定义属性")]
        public string AdmName
        {
            get
            {
                return admName;
            }
            set
            {
                admName = value;
            }
        }

        string admBorn;
        [Description("负责人出生年月"), Category("自定义属性")]
        public string AdmBorn
        {
            get
            {
                return admBorn;
            }
            set
            {
                admBorn = value;
            }
        }

        string admSex;
        [Description("负责人性别"), Category("自定义属性")]
        public string AdmSex
        {
            get
            {
                return admSex;
            }
            set
            {
                admSex = value;
            }
        }

        string admOrd;
        [Description("负责人职务"), Category("自定义属性")]
        public string AdmOrd
        {
            get { return admOrd; }
            set
            {
                admOrd = value;
            }
        }

        string admOrdName;
        [Description("负责人职称"), Category("自定义属性")]
        public string AdmOrdName
        {
            get
            {
                return admOrdName;
            }
            set
            {
                admOrdName = value;
            }
        }

        string admMar;
        [Description("负责人专业"), Category("自定义属性")]
        public string AdmMar
        {
            get
            {
                return admMar;
            }
            set
            {
                admMar = value;
            }
        }

        string admMajBest;
        [Description("负责人研究专长"), Category("自定义属性")]
        public string AdmMajBest
        {
            get
            { return admMajBest; }
            set
            {
                admMajBest = value;
            }
        }

        string admNowDo;
        [Description("负责人现从事专业"), Category("自定义属性")]
        public string AdmNowDo
        {
            get
            {
                return admNowDo;
            }
            set
            {
                admNowDo = value;
            }
        }

        string admJobWhere;
        [Description("负责人工作单位"), Category("自定义属性")]
        public string AdmJobWhere
        {
            get
            {
                return admJobWhere;
            }
            set
            {
                admJobWhere = value;
            }
        }

        string admPhontWhere;
        [Description("通信地址"), Category("自定义属性")]
        public string AdmPhontWhere
        {
            get
            {
                return admPhontWhere;
            }
            set
            {
                admPhontWhere = value;
            }
        }

        bool isYoungProjrem;
        [Description("是否符合青年项目申报条件"), Category("自定义属性")]
        public bool IsYoungProjrem
        {
            get
            {
                return isYoungProjrem;
            }
            set
            {
                isYoungProjrem = value;
            }
        }

        string admAdmPhone;
        [Description("办公个电话"), Category("自定义属性")]
        public string AdmAdmPhone
        {
            get
            {
                return admAdmPhone;
            }
            set
            {
                admAdmPhone = value;
            }
        }

        string admPhone;
        [Description("手机"), Category("自定义属性")]
        public string AdmPhone
        {
            get
            {
                return admPhone;
            }
            set
            {
                admPhone = value;
            }
        }

        string admEmail;
        [Description("电子邮箱"), Category("自定义属性")]
        public string AdmEmail
        {
            get
            {
                return admEmail;
            }
            set
            {
                admEmail = value;
            }
        }
    }
}
