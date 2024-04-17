using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.ASCX.Table;

namespace WebForm.ASCX.ProgramInform.ForProgramShow
{
    public partial class DataFormForParters : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdataFormData();
        }


        #region 队员信息

        List<DataForParter> dataForParters = new List<DataForParter>();
        public List<DataForParter> DataForParts
        {
            get
            {
                return dataForParters;
            }
            set
            {
                dataForParters = value;
                UpdataFormData();
            }
        }

        #endregion

        void UpdataFormData()
        {
            DataPutPlaceHolder.Controls.Clear();
            for (int i = 0; i < DataForParts.Count; i++)
            {
                ALineForProgremParter Aline = (ALineForProgremParter)LoadControl("./ALineForProgremParter.ascx");
                Aline.LineDataForParter = DataForParts[i];
                DataPutPlaceHolder.Controls.Add(Aline);
            }
        }
    }
}