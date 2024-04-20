using Models;
using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class ForTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute = new DataTableControlAttribute<DataTableLineArgs>();

            dataTableControlAttribute.ControlName = "测试完成";
            dataTableControlAttribute.DataTableControls += func;
            List<DataTableControlAttribute<DataTableLineArgs>> customControls = new List<DataTableControlAttribute<DataTableLineArgs>>();
            customControls.Add(dataTableControlAttribute);


            DataTableControlAttribute<DataTableLineArgs> dataTableControlAttribute1 = new DataTableControlAttribute<DataTableLineArgs>();
            dataTableControlAttribute1.ControlName = "拓展性测试";
            dataTableControlAttribute1.DataTableControls += func1;
            customControls.Add(dataTableControlAttribute1);

            Test.CustomControls = customControls;
            BodyLine1.CustomControls = customControls;

        }

        void func(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage(); ; ;
            massage.MassageText = "asdfsadfasdfasdf\n";
            massage.MassageText  += ((Button)sender).Text + "\n";
            massage.PostMassage();
        }


        void func1(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage();
            massage.HeadText = "Test";
            massage.HeadColor = "red";
            massage.MassageText = "Success\n";
            massage.MassageText += ((Button)sender).Text + "\n";
            massage.PostMassage();
        }
    }
}