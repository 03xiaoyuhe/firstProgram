using DAL;
using DAL.DataControl.RelationshipControl;
using DAL.DataControl.TableControl;
using DAL.DataControl.ViewControl;
using DAL.DataObject.RelationObject;
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
            List<RelationForPrincipalCell> relationForPrincipalCells = (List<RelationForPrincipalCell>)(new RelationForPrincipalControl()).SelectReturnObject(RelationForPrincipalControl.BuildWhereClause(new Dictionary<string, HashSet<string>> { { "PB_ID", new HashSet<string> { ProgremInf.ProjectData.Base.PB_ID.ToString() } } }));
            if(relationForPrincipalCells.Count > 0) ProgremInf.PrincipalData = (PeopleData)(new PeopleControl()).SelectReturnObject(PeopleControl.BuildWhereClause(new Dictionary<string, HashSet<string>> { { "PeopleBase.PEB_ID", new HashSet<string> { relationForPrincipalCells[0].PEB_ID.ToString() } } }));
        }
    }
}