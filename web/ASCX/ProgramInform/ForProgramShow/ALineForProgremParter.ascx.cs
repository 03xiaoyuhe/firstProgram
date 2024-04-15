using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform.ForProgramShow
{
    public partial class ALineForProgremParter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        #region 网页数据

        DataForParter lineDataForParter;
        public DataForParter LineDataForParter
        {
            get
            {
                return lineDataForParter;
            }
            set
            {
                lineDataForParter = value;
                Name = value.Name;
                Sex = value.Sex;
                Broth = value.Broth;
                Job = value.Job;
                JobWhere = value.JobWhere;
            }
        }

        string name;
        /// <summary>
        /// 成员名称
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NameLable.Text = name;
            }
        }

        string sex;
        /// <summary>
        /// 成员性别
        /// </summary>
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
                SexLable.Text = sex;
            }
        }

        DateTime broth;
        /// <summary>
        /// 成员出生年月
        /// </summary>
        DateTime Broth
        {
            get
            {
                return broth;
            }
            set
            {
                broth = value;
                BrothLable.Text = value.Year.ToString()+"--"+ value.Month.ToString() +"--"+ value.Day.ToString();
            }
        }

        string job;
        /// <summary>
        /// 成员职务、职称
        /// </summary>
        public string Job
        {
            get
            {
                return job;
            }
            set 
            { 
                job = value;
                JobLable.Text = job;
            }
        }

        string jobWhere;
        public string JobWhere
        {
            get
            {
                return jobWhere;
            }
            set
            { jobWhere = value; }
        }

        #endregion
    }
}