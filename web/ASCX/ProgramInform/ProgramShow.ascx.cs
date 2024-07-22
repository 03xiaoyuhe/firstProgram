using DAL.DataObject.TableObject;
using DAL.DataObject.TableObject.ProjectApart;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX.ProgramInform.ForProgramShow;

namespace WebForm.ASCX.ProgramInform
{
    public partial class ProgramShow : System.Web.UI.UserControl
    {

        public ProjectData ProjectData { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PB_ID.Data = ProjectData.Base.PB_ID.ToString();
            ProjectName.Data = ProjectData.Base.ProjectName;
            ProjectCategory.Data = ProjectData.Base.ProjectCategory;
            ProjectState.Data = ProjectBase.ProjectStateIntToMean[ProjectData.Base.ProjectState];
            DisciplineClassification.Data = ProjectData.Base.DisciplineClassification;
            Ending.Data = ProjectData.Base.Ending;
            EndingDate.Data = ProjectData.Base.EndingDate;

            ProjectSignificance.Data = ProjectData.DemonstrationExpand.ProjectSignificance;
            ProjectDocument.Data = ProjectData.DemonstrationExpand.ProjectDocument;
            ProjectReferences.Data = ProjectData.DemonstrationExpand.ProjectReferences;

            UnitJudge.Data = ProjectData.JudgeExpand.UnitJudge;
            UnitJudgeDate.Data = ProjectData.JudgeExpand.UnitJudgeDate;
            ExpertJudge.Data = ProjectData.JudgeExpand.ExpertJudge;
            ExpertJudgeDate.Data = ProjectData.JudgeExpand.ExpertJudgeDate;
            ApprovalOpinion.Data = ProjectData.JudgeExpand.ApprovalOpinion;
            ApprovalOpinionDate.Data = ProjectData.JudgeExpand.ApprovalOpinionDate;
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      