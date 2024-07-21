using DAL.DataObject.TableObject;
using DAL.DataObject.TableObject.ProjectApart;
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

        public ProjectData ProjectData
        {
            get
            {
                return new ProjectData()
                {
                    Base = new ProjectBase()
                    {
                        ProjectName = InputForProjectName.InputData,
                        ProjectState = ProjectBase.ProjectStateMeanToInt[InputForProjectState.InputData],
                        ProjectCategory = InputForProjectCategory.InputData,
                        DisciplineClassification = InputForDisciplineClassification.InputData,
                        Ending = InputForEnding.InputData,
                        EndingDate = InputForEndingDate.InputData,
                        FillDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    },
                    DemonstrationExpand = new ProjectDemonstrationExpand()
                    {
                        ProjectSignificance = InputForProjectSignificance.InputData,
                        ProjectDocument = InputForProjectDocument.InputData,
                        ProjectReferences = InputForProjectReferences.InputData,
                    },

                    JudgeExpand = new ProjectJudgeExpand()
                    {
                        UnitJudge = InputForUnitJudge.InputData,
                        UnitJudgeDate = InputForUnitJudgeDate.InputData,
                        ExpertJudge = InputForExpertJudge.InputData,
                        ExpertJudgeDate = InputForExpertJudgeDate.InputData,
                        ApprovalOpinion = InputForApprovalOpinion.InputData,
                        ApprovalOpinionDate = InputForApprovalOpinionDate.InputData,
                    }


                };
            }
        }

        #endregion

    }
}