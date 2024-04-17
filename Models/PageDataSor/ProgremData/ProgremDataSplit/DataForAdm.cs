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
        public DataForAdm()
        {
            AdmName = "未赋值";
            AdmBorn = "未赋值";
            AdmSex = "未赋值";
            AdmOrd = "未赋值";
            AdmOrdName = "未赋值";
            AdmMajBest = "未赋值";
            AdmNowDo = "未赋值";
            AdmJobWhere = "未赋值";
            AdmPhontWhere = "未赋值";
            IsYoungProjrem = false;
            AdmAdmPhone = "未赋值";
            AdmEmail = "未赋值";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="admName"></param>
        /// <param name="admBorn"></param>
        /// <param name="admSex"></param>
        /// <param name="admOrd"></param>
        /// <param name="admOrdName"></param>
        /// <param name="admMar"></param>
        /// <param name="admMajBest"></param>
        /// <param name="admNowDo"></param>
        /// <param name="admJobWhere"></param>
        /// <param name="admPhontWhere"></param>
        /// <param name="isYoungProjrem"></param>
        /// <param name="admAdmPhone"></param>
        /// <param name="admPhone"></param>
        /// <param name="admEmail"></param>
        public DataForAdm(
            string admName, 
            string admBorn,  
            string admSex,  
            string admOrd,  
            string admOrdName, 
            string admMar,  
            string admMajBest,  
            string admNowDo,  
            string admJobWhere,  
            string admPhontWhere,  
            bool isYoungProjrem,  
            string admAdmPhone,  
            string admPhone,  
            string admEmail
            )
        {
            AdmName = admName;
            AdmBorn = admBorn;
            AdmSex = admSex;
            AdmOrd = admOrd;
            AdmOrdName = admOrdName;
            AdmMar = admMar;
            AdmMajBest = admMajBest;
            AdmNowDo = admNowDo;
            AdmJobWhere = admJobWhere;
            AdmPhontWhere = admPhontWhere;
            IsYoungProjrem = isYoungProjrem;
            AdmAdmPhone = admAdmPhone;
            AdmPhone = admPhone;
            AdmEmail = admEmail;
        }



        //[Description("标题颜色"), Category("自定义属性")]
        string admName;
        /// <summary>
        /// 负责人姓名
        /// </summary>
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
        /// <summary>
        /// 负责人出生年月
        /// </summary>
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
        /// <summary>
        /// 负责人性别
        /// </summary>
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
        /// <summary>
        /// 负责人职务
        /// </summary>
        public string AdmOrd
        {
            get { return admOrd; }
            set
            {
                admOrd = value;
            }
        }

        string admOrdName;
        /// <summary>
        /// 负责人职称
        /// </summary>
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
        /// <summary>
        /// 负责人专业
        /// </summary>
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
        /// <summary>
        /// 负责人研究专长
        /// </summary>
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
        /// <summary>
        /// 负责人现从事专业
        /// </summary>
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
        //[Description("负责人工作单位"), Category("自定义属性")]
        /// <summary>
        /// 负责人工作单位
        /// </summary>
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
        //[Description("通信地址"), Category("自定义属性")]
        /// <summary>
        /// 通信地址
        /// </summary>
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
        //[Description("是否符合青年项目申报条件"), Category("自定义属性")]
        /// <summary>
        /// 是否符合青年项目申报条件
        /// </summary>
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
        /// <summary>
        /// 办公个电话
        /// </summary>
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
        /// <summary>
        /// 手机
        /// </summary>
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
        /// <summary>
        /// 电子邮箱
        /// </summary>
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
