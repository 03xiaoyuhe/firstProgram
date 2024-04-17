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
                //ProgromBaseData progromBaseData = new ProgromBaseData();



                //if (!ProjectCompletion.CheckTeam_id(this.PhoneNum.Text.ToString()))
                //{
                //    throw new Exception("NotLoad");
                //}
                bool Project_Insert = ProjectCompletion.ProjectInfor(
                    progromBaseData.ProjectName,
                    progromBaseData.ProjectKinds,
                    progromBaseData.DatasForAdm.IsYoungProjrem.ToString(),
                    progromBaseData.DatasForDoc.ProjectIntroduce,
                    progromBaseData.DatasForDoc.ProjectMainIdea,
                    progromBaseData.DatasForDoc.ProjectAhead,
                    progromBaseData.ProjectFinish,
                    progromBaseData.ProjectEnd
                    );

                //bool User_Insert = DAL.User.Insert_Infor(
                    
                //    );

                if (Project_Insert)
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