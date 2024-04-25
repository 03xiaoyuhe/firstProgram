using Antlr.Runtime.Misc;
using Models;
using Models.PageDataSor.DataTableControl;
using Models.PageDataSor.DataTableControl.ForControlAttribute;
using Models.PageDataSor.ProgremData;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class ForTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTableControlAttribute dataTableControlAttribute = new DataTableControlAttribute();

            dataTableControlAttribute.ControlName = "测试完成";
            dataTableControlAttribute.DataTableControls += func;
            List<DataTableControlAttribute> customControls = new List<DataTableControlAttribute>();
            customControls.Add(dataTableControlAttribute);


            DataTableControlAttribute dataTableControlAttribute1 = new DataTableControlAttribute();
            dataTableControlAttribute1.ControlName = "拓展性测试";
            dataTableControlAttribute1.DataTableControls += func1;

            dataTableControlAttribute1.DataTableControls += func2;
            customControls.Add(dataTableControlAttribute1);

            Test.CustomControls = customControls;
            BodyLine1.CustomControls = customControls;
            //D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\Table\ForMyTable\DeletButten.ascx
            //D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\Table\ForDataTable\MyButton.ascx
            Control control = LoadControl("~\\ASCX\\ProgramInform\\ProgramAdd.ascx");
            control.ID = "aaa";
            PlaceHolder1.Controls.Add(control);
            //D:\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\ASCX\ProgramInform\ProgramShow.ascx
        }

        void func(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage();
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
       

        void func2(object sender, DataTableLineArgs e)
        {
            Massage massage = new Massage();
            massage.HeadText = "Func2";
            massage.HeadColor = "red";
            massage.MassageText = "Success\n";
            massage.MassageText += ((Button)sender).Text + "\n";
            massage.PostMassage();
        }
    }
}