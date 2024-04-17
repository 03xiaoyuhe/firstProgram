using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;

namespace WebForm
{
    public partial class ForTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DataForParter> dataForParters = new List<DataForParter>();
            dataForParters.Add(new DataForParter());
            dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            //dataForParters.Add(new DataForParter());
            ProgremInf1.DataForParts = dataForParters;
        }
    }
}