using Models.PageDataSor.ProgremData;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.ProgramInform
{
    public partial class ProgramAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 网站数据

            /// <summary>
            /// 网站数据集
            /// </summary>
            public ProgromBaseData ProgromBaseDatas
            {
                get
                {
                    return new ProgromBaseData(ProjectName, ProjectKinds, ProjectFinish, ProjectEnd, DatasForAdm, DataForParts, DatasForDoc, DatasForThinking);
                }
                set
                {
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

                /// <summary>
                /// 项目名称
                /// </summary>
                public string ProjectName
                {
                    get { return ProgromNameTextBox.Text; }
                    set
                    {
                        ProgromNameTextBox.Text = value;
                    }
                }

                /// <summary>
                /// 项目类别
                /// </summary>
                public string ProjectKinds
                {
                    get 
                    { 
                        return ProgromKindsTextBox.Text; 
                    }
                    set
                    {
                        ProgromKindsTextBox.Text = value;
                    }
                }

                /// <summary>
                /// 项目完成时间
                /// </summary>
                public DateTime ProjectFinish
                {
                    get
                    {
                        return DateTime.Parse( ProjectFinishTextBox.Text);
                    }
                    set
                    {
                        ProjectFinishTextBox.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                    }

                }

                /// <summary>
                /// 项目成果形式
                /// </summary>
                public string ProjectEnd
                {
                    get
                    {
                        return ProjectEndTextBox.Text;
                    }
                    set
                    {
                        ProjectEndTextBox.Text = value;
                    }
                }



                #region 负责人信息

                    public DataForAdm DatasForAdm
                    {
                        get
                        {
                            return new DataForAdm(
                            AdmName,
                            AdmBorn,
                            AdmSex,
                            AdmOrd,
                            AdmOrdName,
                            AdmMar,
                            AdmMajBest,
                            AdmNowDo,
                            AdmJobWhere,
                            AdmPhontWhere,
                            IsYoungProjrem,
                            AdmPhone,
                            AdmAdmPhone,
                            AdmEmail
                            );
                        }
                        set
                        {
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
                        [Description("负责人姓名"), Category("自定义属性")]
                        public string AdmName
                        {
                            get
                            {
                                return AdmNameTextBox.Text;
                            }
                            set
                            {
                                AdmNameTextBox.Text = value;
                            }
                        }

                        [Description("负责人出生年月"), Category("自定义属性")]
                        public string AdmBorn
                        {
                            get
                            {
                                return AdmBornTextBox.Text;
                            }
                            set
                            {
                                AdmBornTextBox.Text = value;
                            }
                        }

                        [Description("负责人性别"), Category("自定义属性")]
                        public string AdmSex
                        {
                            get
                            {
                                return AdmBornTextBox.Text;
                            }
                            set
                            {
                                AdmBornTextBox.Text = value;
                            }
                        }

                        [Description("负责人职务"), Category("自定义属性")]
                        public string AdmOrd
                        {
                            get 
                            { 
                                return AdmOrdTextBox.Text; 
                            }
                            set
                            {
                                AdmOrdTextBox.Text = value;
                            }
                        }

                        [Description("负责人职称"), Category("自定义属性")]
                        public string AdmOrdName
                        {
                            get
                            {
                                return AdmOrdTextBox.Text;
                            }
                            set
                            {
                                AdmOrdTextBox.Text = value;
                            }
                        }

                        [Description("负责人专业"), Category("自定义属性")]
                        public string AdmMar
                        {
                            get
                            {
                                return AdmMarTextBox.Text;
                            }
                            set
                            {
                                AdmMarTextBox.Text = value;
                            }
                        }

                        [Description("负责人研究专长"), Category("自定义属性")]
                        public string AdmMajBest
                        {
                            get
                            { return AdmMajBestTextBox.Text; }
                            set
                            {
                                AdmMajBestTextBox.Text = value;
                            }
                        }

                        [Description("负责人现从事专业"), Category("自定义属性")]
                        public string AdmNowDo
                        {
                            get
                            {
                                return AdmNowDoTextBox.Text;
                            }
                            set
                            {
                                AdmNowDoTextBox.Text = value;
                            }
                        }

                        [Description("负责人工作单位"), Category("自定义属性")]
                        public string AdmJobWhere
                        {
                            get
                            {
                                return AdmJobWhereTextBox.Text;
                            }
                            set
                            {
                                AdmJobWhereTextBox.Text = value;
                                ProgremAdmWhereTextBox.Text = value;
                            }
                        }

                        [Description("通信地址"), Category("自定义属性")]
                        public string AdmPhontWhere
                        {
                            get
                            {
                                return AdmPhoneWhereTextBox.Text;
                            }
                            set
                            {
                                AdmPhoneWhereTextBox.Text = value;
                            }
                        }

                        [Description("是否符合青年项目申报条件"), Category("自定义属性")]
                        public bool IsYoungProjrem
                        {
                            get
                            {
                                if(IsYoungProjremTextBox.Text == "是")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            set
                            {
                                if (value)
                                {
                                    IsYoungProjremTextBox.Text = "是";
                                }
                                else
                                {
                                    IsYoungProjremTextBox.Text = "否";
                                }
                            }
                        }

                        [Description("办公个电话"), Category("自定义属性")]
                        public string AdmAdmPhone
                        {
                            get
                            {
                                return AdmAdmPhoneTextBox.Text;
                            }
                            set
                            {
                                AdmAdmPhoneTextBox.Text = value;
                            }
                        }

                        [Description("手机"), Category("自定义属性")]
                        public string AdmPhone
                        {
                            get
                            {
                                return AdmPhoneTextBox.Text;
                            }
                            set
                            {
                                AdmPhoneTextBox.Text = value;
                            }
                        }

                        [Description("电子邮箱"), Category("自定义属性")]
                        public string AdmEmail
                        {
                            get
                            {
                                return AdmEmailTextBox.Text;
                            }
                            set
                            {
                                AdmEmailTextBox.Text = value;
                            }
                        }

                    #endregion

                #endregion

                #region 队员信息

                    public List<DataForParter> DataForParts
                    {
                        get
                        {
                            return new List<DataForParter>(1);
                        }
                        set
                        {
                            LineForProgremParter.LineDataForParter = value[0];
                        }
                    }

                #endregion

                #region 项目论证

                    /// <summary>
                    /// 项目论证数据
                    /// </summary>
                    public DataForDoc DatasForDoc
                    {
                        get
                        {
                            return new DataForDoc(
                                ProjectIntroduce,
                                ProjectMainIdea,
                                ProjectAhead
                                );
                        }
                        set
                        {
                            ProjectIntroduce = value.ProjectIntroduce;
                            ProjectMainIdea = value.ProjectMainIdea;
                            ProjectAhead = value.ProjectAhead;
                        }

                    }

                    #region 项目论证数据项

                    /// <summary>
                    /// 本项目国内外研究现状述评、选题意义和价值。限 1200 字以内
                    /// </summary>
                    public string ProjectIntroduce
                    {
                        get { return ProjectIntroduceTextBox.Text; }
                        set
                        {
                            ProjectIntroduceTextBox.Text = value;
                        }
                    }

                    /// <summary>
                    /// 本项目研究的主要观点，基本思路和方法、重点、难点及创新之处。限 2000 字以内
                    /// </summary>
                    public string ProjectMainIdea
                    {
                        set
                        {
                            ProjectAheadTextBox.Text = value;
                        }
                        get
                        {
                            return ProjectAheadTextBox.Text;
                        }
                    }

                    /// <summary>
                    /// 项目负责人和主要成员前期研究成果及参考文献。限填20项
                    /// </summary>
                    public string ProjectAhead
                    {
                        get 
                        { 
                            return ProjectAheadTextBox.Text;
                        }
                        set
                        {
                            ProjectAheadTextBox.Text = value;
                        }
                    }

                #endregion

                #endregion

                #region 评审意见

                    /// <summary>
                    /// 评审意见数据集
                    /// </summary>
                    public DataForThinking DatasForThinking
                    {
                        get
                        {
                            return new DataForThinking(
                                WhereThink,
                                WhereThinkTime,
                                MajorThink,
                                MajorThinkTime,
                                EndThink,
                                EndThinkTime
                                );
                        }
                        set
                        {
                            WhereThink = value.WhereThink;
                            WhereThinkTime = value.WhereThinkTime;
                            MajorThink = value.MajorThink;
                            MajorThinkTime = value.MajorThinkTime;
                            EndThink = value.EndThink;
                            EndThinkTime = value.EndThinkTime;
                        }
                    }

                    #region 评审意见数据项

                        /// <summary>
                        /// 项目负责人所在单位审核意见(本栏由申请人所在单位根据申报要求，认真审核后进行填写，电子版申请书可不盖公章
                        /// </summary>
                        public string WhereThink
                        {
                            get 
                            { 
                                return WhereThinkTextBox.Text; 
                            }
                            set
                            {
                                WhereThinkTextBox.Text = value;
                            }
                        }


                        /// <summary>
                        /// 项目负责人所在单位审核意见时间
                        /// </summary>
                        public DateTime WhereThinkTime
                        {
                            get
                            {
                                return DateTime.Parse(WhereThinkTimeLable.Text);
                            }
                            set 
                            {
                                WhereThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                            }
                        }


                        /// <summary>
                        /// 专家组评审意见
                        /// </summary>
                        public string MajorThink
                        {
                            get 
                            { 
                                return MajorThinkTextBox.Text; 
                            }
                            set
                            {
                                MajorThinkTextBox.Text = value;
                            }
                        }


                        /// <summary>
                        /// 专家组评审意见时间
                        /// </summary>
                        public DateTime MajorThinkTime
                        {
                            get
                            {
                                return DateTime.Parse(MajorThinkTimeLable.Text);
                            }
                            set
                            {
                                MajorThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                            }
                        }


                        /// <summary>
                        /// 审批意见
                        /// </summary>
                        public string EndThink
                        {
                            get 
                            { 
                                return EndThinkTextBox.Text;
                            }
                            set
                            {
                                EndThinkTextBox.Text = value;
                            }
                        }


                        /// <summary>
                        /// 审批意见时间
                        /// </summary>
                        public DateTime EndThinkTime
                        {
                            get
                            {
                                return DateTime.Parse( EndThinkTimeLable.Text);
                            }
                            set
                            {
                                EndThinkTimeLable.Text = value.Year.ToString() + "--" + value.Month.ToString() + "--" + value.Day.ToString();
                            }
                        }

                    #endregion


                #endregion

            #endregion

        #endregion

    }
}