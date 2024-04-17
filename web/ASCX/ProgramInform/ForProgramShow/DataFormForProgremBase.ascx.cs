using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform.ForProgramShow
{
    public partial class DataFormForProgremBase : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region 网站数据

        ProgromBaseData progromBaseData;
        /// <summary>
        /// 网站数据集
        /// </summary>
        public ProgromBaseData ProgromBaseDatas
        {
            get
            {
                return progromBaseData;
            }
            set
            {
                progromBaseData = value;
                ProjectName = value.ProjectName;
                ProjectKinds = value.ProjectKinds;
                ProjectFinish = value.ProjectFinish;
                ProjectEnd = value.ProjectEnd;
                DatasForAdm = value.DatasForAdm;
            }
        }




        #region 网站数据集    

        string projectName;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                ProgromNameLable.Text = value;
            }
        }

        string projectKinds;
        /// <summary>
        /// 项目类别
        /// </summary>
        public string ProjectKinds
        {
            get { return projectKinds; }
            set
            {
                projectKinds = value;
                ProgromKindsLable.Text = value;
            }
        }

        DateTime projectFinish;
        /// <summary>
        /// 项目完成时间
        /// </summary>
        public DateTime ProjectFinish
        {
            get
            {
                return projectFinish;
            }
            set
            {
                projectFinish = value;
                ProjectFinishLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
            }

        }

        string projectEnd;
        /// <summary>
        /// 项目成果形式
        /// </summary>
        public string ProjectEnd
        {
            get
            {
                return projectEnd;
            }
            set
            {
                projectEnd = value;
                ProjectEndLable.Text = value;
            }
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
                AdmJobWhere = value.AdmJobWhere;
            }
        }

        #region 负责人信息数据项


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
                ProgremAdmWhereLable.Text = value;
            }
        }



        #endregion

        #endregion




        #endregion

        #endregion
    }
}