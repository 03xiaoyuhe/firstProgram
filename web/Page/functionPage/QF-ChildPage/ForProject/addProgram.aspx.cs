using Antlr.Runtime.Tree;
using DAL;
using DAL.DataControl;
using DAL.DataControl.RelationshipControl;
using DAL.DataControl.TableControl;
using DAL.DataObject.RelationObject;
using DAL.DataObject.TableObject;
using Models;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            SqlConnection sqlConnection =  DataBaseControl.GetSqlConnection();
            DataBaseControl.OpenSqlConnection();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            Massage massage;
            try
            {
                string projectID = (new ProjectControl()).InsertReturnID(sqlTransaction, ProgremInf.ProjectData);
                if (!ProgremInf.PeopleData.IsEmpty())
                    (new RelationForPrincipalControl()).Insert(
                        sqlTransaction,
                        new List<RelationForPrincipalCell>()
                        {
                            new RelationForPrincipalCell() 
                            {
                                PB_ID = int.Parse(projectID), 
                                PEB_ID = ProgremInf.PeopleData.Base.PEB_ID }
                        }
                        );

                clearAll();
                massage = new Massage("blue", "Success", "插入成功");
                massage.PostMassage();
                sqlTransaction.Commit();
            }
            catch (Exception E)
            {
                if (E.Message == "NotLoad")
                {
                    sqlTransaction.Rollback();
                    clearAll();
                    massage = new Massage("#ff0000", "ERRO", "错误！");
                    massage.PostMassage();
                }
                else
                {
                    sqlTransaction.Rollback();
                    clearAll();
                    massage = new Massage("#ff0000", "ERRO", E.Message);
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