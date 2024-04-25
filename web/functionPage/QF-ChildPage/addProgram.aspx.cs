using DAL;
using Models;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class addProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                ProgromBaseData progromBaseData = ProgremInf.ProgromBaseDatas;

                //申请时向项目信息表中插入对应的字段值
                bool Project_Insert = ProjectCompletion.ProjectInfor(
                    progromBaseData.DatasForAdm.AdmPhone,
                    progromBaseData.ProjectName,
                    progromBaseData.ProjectKinds,
                    progromBaseData.DatasForAdm.IsYoungProjrem.ToString(),
                    progromBaseData.DatasForDoc.ProjectIntroduce,
                    progromBaseData.DatasForDoc.ProjectMainIdea,
                    progromBaseData.DatasForDoc.ProjectAhead,
                    progromBaseData.ProjectFinish,
                    progromBaseData.ProjectEnd
                    );

                //申请时对负责人信息进行插入完善
                bool User_Insert = DAL.User.Insert_Infor(
                    progromBaseData.DatasForAdm.AdmName,
                    progromBaseData.DatasForAdm.AdmBorn,
                    progromBaseData.DatasForAdm.AdmSex,
                    progromBaseData.DatasForAdm.AdmOrd,
                    progromBaseData.DatasForAdm.AdmOrdName,
                    progromBaseData.DatasForAdm.AdmMar,
                    progromBaseData.DatasForAdm.AdmMajBest,
                    progromBaseData.DatasForAdm.AdmNowDo,
                    progromBaseData.DatasForAdm.AdmJobWhere,
                    progromBaseData.DatasForAdm.AdmPhontWhere,
                    progromBaseData.DatasForAdm.AdmAdmPhone,
                    progromBaseData.DatasForAdm.AdmPhone,
                    progromBaseData.DatasForAdm.AdmEmail
                    );

                if (Project_Insert && User_Insert)
                {
                    clearAll();
                    Massage massage = new Massage("Blue", "Success", "添加成功");
                    massage.PostMassage();
                }
            }
            catch (Exception E)
            {
                if (E.Message == "NotLoad")
                {
                    clearAll();
                    Massage massage = new Massage("#ff0000", "ERRO", "错误！");
                    massage.PostMassage();
                }
                else
                {
                    clearAll();
                    Massage massage = new Massage("#ff0000", "ERRO", E.Message);
                    massage.PostMassage();
                }
            }
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        protected void clearAll()
        {

        }
    }
}