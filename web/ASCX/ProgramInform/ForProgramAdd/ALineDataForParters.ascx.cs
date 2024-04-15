using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform.ForProgramAdd
{
    public partial class ALineDataForParters : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 网页数据

        public DataForParter LineDataForParter
        {
            get
            {
                return new DataForParter(Name, Sex, Broth, Job, JobWhere);
            }
            set
            {
                Name = value.Name;
                Sex = value.Sex;
                Broth = value.Broth;
                Job = value.Job;
                JobWhere = value.JobWhere;
            }
        }

        /// <summary>
        /// 成员名称
        /// </summary>
        public string Name
        {
            get
            {
                return NameTextBox.Text;
            }
            set
            {
                NameTextBox.Text = value;
            }
        }

        /// <summary>
        /// 成员性别
        /// </summary>
        public string Sex
        {
            get
            {
                return SexTextBox.Text;
            }
            set
            {
                SexTextBox.Text = value;
            }
        }

        /// <summary>
        /// 成员出生年月
        /// </summary>
        DateTime Broth
        {
            get
            {
                return DateTime.Parse(BrothTextBox.Text);
            }
            set
            {
                BrothTextBox.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
            }
        }

        /// <summary>
        /// 成员职务、职称
        /// </summary>
        public string Job
        {
            get
            {
                return JobTextBox.Text;
            }
            set
            {
                JobTextBox.Text = value;
            }
        }

        public string JobWhere
        {
            get
            {
                return JobWhereTextBox.Text;
            }
            set
            {
                JobWhereTextBox.Text = value;
            }
        }

        #endregion

    }
}