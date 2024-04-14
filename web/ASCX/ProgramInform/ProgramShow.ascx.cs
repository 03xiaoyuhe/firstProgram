using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform
{
    public partial class ProgramShow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 网站数据

            ProgromBaseData progromBaseData;
            /// <summary>
            /// 网站数据集
            /// </summary>
            public ProgromBaseData progromBaseDatas
            {
                get
                {
                    return progromBaseDatas;
                }
                set
                {
                    progromBaseData = value;
                    ProjectName = value.ProjectName;
                    ProjectKinds = value.ProjectKinds;
                    ProjectFinish = value.ProjectFinish;
                    ProjectEnd = value.ProjectEnd;
                    DatasForAdm = value.DatasForAdm;
                    DataForParts = value.DataForParts;
                    DatasForDoc = value.DatasForDoc;
                    DatasForThinking = value.DatasForThinking;
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
                                    ProgromNameLable.Text = value;
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
                                    ProgremAdmWhereLable.Text = value;
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

                #region 队员信息

                    List<DataForParter> dataForParters;
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

                #endregion
                
                #region 项目论证

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
                            ProjectIntroduce = value.ProjectIntroduce;
                            ProjectMainIdea = value.ProjectMainIdea;
                            ProjectAhead = value.ProjectAhead;
                        }

                    }

                    #region 项目论证数据项

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
                                ProjectIntroduceLable.Text= value;
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
                                ProjectAheadLable.Text = value;
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
                            get { return  ProjectAhead; }
                            set 
                            {  
                                ProjectAhead = value; 
                                ProjectAheadLable.Text = value;
                            }
                        }

                    #endregion

                #endregion

                #region 评审意见

                    DataForThinking dataForThinking;
                    /// <summary>
                    /// 评审意见数据集
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
                            WhereThink = value.WhereThink;
                            WhereThinkTime = value.WhereThinkTime;
                            MajorThink = value.MajorThink;
                            MajorThinkTime = value.MajorThinkTime;
                            EndThink = value.EndThink;
                            EndThinkTime = value.EndThinkTime;
                        }
                    }

                    #region 评审意见数据项

                    string whereThink;
                    /// <summary>
                    /// 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章
                    /// </summary>
                    public string WhereThink
                    {
                        get { return  whereThink; }
                        set
                        {
                            whereThink = value;
                        }
                    }


                    DateTime whereThinkTime;
                    /// <summary>
                    /// 项目负责人所在单位审核意见时间
                    /// </summary>
                    public DateTime WhereThinkTime
                    {
                        get
                        {
                            return whereThinkTime;
                        }
                        set
                        {
                            whereThinkTime = value;
                            WhereThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                        }
                    }


                    string majorThink;
                    /// <summary>
                    /// 专家组评审意见
                    /// </summary>
                    public string MajorThink
                    {
                        get { return majorThink; }
                        set
                        {
                            majorThink = value;
                        }
                    }


                    DateTime majorThinkTime;
                    /// <summary>
                    /// 专家组评审意见时间
                    /// </summary>
                    public DateTime MajorThinkTime
                    {
                        get
                        {
                            return majorThinkTime;
                        }
                        set
                        {
                            majorThinkTime = value;
                            MajorThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                        }
                    }


                    string endThink;
                    /// <summary>
                    /// 审批意见
                    /// </summary>
                    public string EndThink
                    {
                        get { return endThink; }
                        set
                        {
                            endThink = value;
                        }
                    }


                    DateTime endThinkTime;
                    /// <summary>
                    /// 审批意见时间
                    /// </summary>
                    public DateTime EndThinkTime
                    {
                        get
                        {
                            return majorThinkTime;
                        }
                        set
                        {
                            endThinkTime = value;
                            EndThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                        }
                    }

            #endregion


            #endregion

            #endregion

        #endregion
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      