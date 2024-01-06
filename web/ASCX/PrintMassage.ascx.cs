using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class MassageBox
{
    public string HeadColor;
    public string HeadLine;
    public string Massage;
    public string DataTime;
}

public partial class ASCX_PrintMassage : System.Web.UI.UserControl
{
    public static List<Control> controls = new List<Control>();

    int Count
    {
        get
        {
            if (ViewState["ControlCount"] == null)
                ViewState["ControlCount"] = 0;
            return (int)ViewState["ControlCount"];
        }
        set
        {
            ViewState["ControlCount"] = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Count = 0;
        }
        Timer1.Interval = 100;

        for (int i = Request.Cookies.Count-1; i > -1 ; i--)
        {
            if (Request.Cookies[i].Values["Type"] != null)
            {
                if (Request.Cookies[i].Values["Type"].ToString() == "Massage")
                {
                    LoadUserControl(
                       Request.Cookies[i].Values["HeadColor"].ToString(),
                       Request.Cookies[i].Values["HeadLine"].ToString(),
                       Request.Cookies[i].Values["Massage"].ToString(),
                       Request.Cookies[i].Values["DataTime"].ToString(),
                       Request.Cookies[i].Name.ToString()
                       );
                }
            }
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {

    }

    void LoadUserControl(
        string HeadColor,
        string HeadLine,
        string Massage,
        string DataTime,
        string Name
        )
    {
        ASCX_popMassage ErroMassage = (ASCX_popMassage)LoadControl("~/ASCX/popMassage.ascx");
        ErroMassage.HeadColor = System.Drawing.ColorTranslator.FromHtml(HeadColor);
        ErroMassage.HeadLine = HeadLine;
        ErroMassage.Massage = Massage;
        ErroMassage.DataTime = DataTime;
        ErroMassage.CookieName = Name;
        //up1.ContentTemplateContainer.Controls.Add
        MassageP.ContentTemplateContainer.Controls.Add(ErroMassage);
    }

}