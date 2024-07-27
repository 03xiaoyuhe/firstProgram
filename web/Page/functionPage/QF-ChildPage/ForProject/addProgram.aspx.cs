using DAL;
using DAL.DataControl.TableControl;
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
                (new ProjectControl()).Inseart(null, ProgremInf.ProjectData);
                {

                    clearAll();
                    Massage massage = new Massage("blue", "Success", "插入成功");
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
            ProgremInf.ClearAll();
        }
    }
}