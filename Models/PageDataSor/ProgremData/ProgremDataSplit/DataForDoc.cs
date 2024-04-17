using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ProgremData
{
    /// <summary>
    /// 项目说明文档数据
    /// </summary>
    public class DataForDoc
    {

        public DataForDoc() 
        {
            ProjectIntroduce = "未赋值";
            ProjectMainIdea = "未赋值";
            ProjectAhead = "未赋值";
        }

        public DataForDoc(string projectIntroduce, string projectMainIdea,  string projectAhead)
        {
            ProjectIntroduce = projectIntroduce;
            ProjectMainIdea = projectMainIdea;
            ProjectAhead = projectAhead;
        }


        #region 项目论证



        string projectIntroduce;
        /// <summary>
        /// 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内
        /// </summary>
        public string ProjectIntroduce
        {
            get { return projectIntroduce; }
            set
            {
                projectIntroduce = value;
            }
        }

        string projectMainIdea;
        /// <summary>
        /// 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内
        /// </summary>
        public string ProjectMainIdea
        {
            set
            {
                projectMainIdea = value;
            }
            get
            {
                return projectMainIdea;
            }
        }

        string projectAhead;
        /// <summary>
        /// 项目负责人和主要成员前期研究成果及参考文献。限填20项
        /// </summary>
        public string ProjectAhead
        {
            get { return projectAhead; }
            set
            {
                projectAhead = value;
            }
        }

        #endregion


    }
}
