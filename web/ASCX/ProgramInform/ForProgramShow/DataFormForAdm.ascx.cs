using System;
using Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.PageDataSor.ProgremData;

namespace WebForm.ASCX.ProgramInform.ForProgramShow
{
    public partial class DataFormForAdm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 负责人信息

        DataForAdm dataForAdm;
        public DataForAdm DatasForAdm
        {
            get
            {
                return dataForAdm;
            }
            set
            {
                dataForAdm = value;

                AdmName = value.AdmName;
                AdmBorn = value.AdmBorn;
                AdmSex = value.AdmSex;
                AdmOrd = value.AdmOrd;
                AdmOrdName = value.AdmName;
                AdmMar = value.AdmMar;
                AdmMajBest = value.AdmMajBest;
                AdmNowDo = value.AdmNowDo;
                AdmJobWhere = value.AdmJobWhere;
                AdmPhone = value.AdmPhone;
                AdmPhontWhere = value.AdmPhontWhere;
                IsYoungProjrem = value.IsYoungProjrem;
                AdmAdmPhone = value.AdmPhone;
                AdmEmail = value.AdmEmail;
            }
        }

        #region 负责人信息数据项

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
                AdmNameLable.Text = value;
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
                AdmBornLable.Text = value;
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
                AdmBornLable.Text = value;
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
                AdmOrdLable.Text = value;
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
                AdmOrdLable.Text = value;
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
                AdmMarLable.Text = value;
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
                AdmMajBestLable.Text = value;
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
                AdmNowDoLable.Text = value;
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
                AdmJobWhereLable.Text = value;
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
                AdmPhoneWhereLable.Text = value;
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
                if (isYoungProjrem)
                {
                    IsYoungProjremLable.Text = "是";
                }
                else
                {
                    IsYoungProjremLable.Text = "否";
                }
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
                AdmAdmPhoneLable.Text = value;
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
                AdmPhoneLable.Text = value;
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
                AdmEmailLable.Text = value;
            }
        }

        #endregion

        #endregion

    }
}