using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Models.PageDataSor.ProgremData
{
    /// <summary>
    /// 项目成员数据结构
    /// </summary>
    public class DataForParter
    {

        public DataForParter() 
        {
            Name = "未赋值";
            Sex = "未赋值";
            Broth = DateTime.MaxValue;
            Job = "未赋值";
            JobWhere = "未赋值";
        }

        public DataForParter(string name, string sex, DateTime broth, string job, string jobWhere )
        {
            Name = name;
            Sex = sex;
            Broth = broth;
            Job = job;
            JobWhere = jobWhere;
        }

        string name;
        /// <summary>
        /// 成员名
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
            }
        }

        string sex;
        /// <summary>
        /// 性别
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
            }
        }

        DateTime broth;
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Broth
        {
            get
            {
                return broth;
            }
            set
            {
                broth = value;
            }
        }

        string job;
        /// <summary>
        /// 职务、职称
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
            }
        }

        string jobWhere;
        /// <summary>
        /// 工作单位
        /// </summary>
        public string JobWhere
        {
            get
            {
                return jobWhere;
            }
            set
            {
                jobWhere = value;
            }
        }

    }


}
