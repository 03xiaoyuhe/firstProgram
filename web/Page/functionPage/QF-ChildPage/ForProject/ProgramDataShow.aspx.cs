using DAL;
using DAL.DataControl.TableControl;
using DAL.DataControl.ViewControl;
using DAL.DataObject.TableObject;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.functionPage.QF_ChildPage
{
    public partial class ProgramDataShow : System.Web.UI.Page
    {
        public string TableName
        {
            get
            {
                //return tableName; 
                return Request.QueryString["tablename"];
            }
            //set { tableName = value; }
        }

        //static string idLable;
        public string IdLable
        {
            get { return Request.QueryString["idlable"]; }
            //set
            //{
            //    idLable = value;
            //}
        }

        //static string id;
        public string Id
        {
            get
            {
                return Request.QueryString["id"];
            }
            //set
            //{
            //    id = value;
            //}
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            ProgremInf.ProjectData = (ProjectData)(new ProjectViewContron()).SelectReturnObject(ProjectControl.BuildWhereClause(new Dictionary<string, string>() { { "PB_ID", Id } }));
        }
    }
}