using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.ProgremData
{

    /// <summary>
    /// 网站数据集
    /// </summary>
    public class ProgromBaseData
    {

        public ProgromBaseData() 
        {
            ProjectName = "";
            ProjectKinds = "";
            ProjectFinish = "";
            ProjectEnd = "";
            DatasForAdm = new DataForAdm();
            DataForParts = new List<DataForParter>();
            DatasForDoc = new DataForDoc();
            DatasForThinking = new DataForThinking();
        }



        public ProgromBaseData(
            string projectName, 
            string projectKinds, 
            string projectFinish, 
            string projectEnd, 
            DataForAdm dataForAdm, 
            List<DataForParter> dataForParters,
            DataForDoc dataForDoc,
            DataForThinking dataForThinking
            )
        {
            ProjectName = projectName;
            ProjectKinds = projectKinds;
            ProjectFinish = projectFinish;
            ProjectEnd = projectEnd;
            DatasForAdm = dataForAdm;
            DataForParts = dataForParters;
            DatasForDoc = dataForDoc;
            DatasForThinking = dataForThinking;
        }

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
            }
        }


        string projectFinish;
        /// <summary>
        /// 项目完成时间
        /// </summary>
        public string ProjectFinish
        {
            get
            {
                return projectFinish;
            }
            set
            {
                projectFinish = value;
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
            }
        }


        DataForAdm dataForAdm;
        /// <summary>
        /// 负责人信息
        /// </summary>
        public DataForAdm DatasForAdm
        {
            get
            {
                return dataForAdm;
            }
            set
            {
                dataForAdm = value;
            }
        }


        List<DataForParter> dataForParters;
        /// <summary>
        /// 队员信息
        /// </summary>
        public List<DataForParter> DataForParts
        {
            get
            {
                return dataForParters;
            }
            set
            {
                dataForParters = value;
            }
        }


        DataForDoc dataForDoc;
        /// <summary>
        /// 项目论证数据
        /// </summary>
        public DataForDoc DatasForDoc
        {
            get
            {
                return dataForDoc;
            }
            set
            {
                dataForDoc = value;
            }

        }


        DataForThinking dataForThinking;
        /// <summary>
        /// 评审意见数据
        /// </summary>
        public DataForThinking DatasForThinking
        {
            get
            {
                return dataForThinking;
            }
            set
            {
                dataForThinking = value;
            }
        }
    }
}
