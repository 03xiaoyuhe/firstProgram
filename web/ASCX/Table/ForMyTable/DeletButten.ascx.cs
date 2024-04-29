using DAL;
using Models;
using System;
using WebForm.ASCX.Table.ForMyTable;

namespace WebForm.ASCX.Table
{
    public partial class DeletButten : ControlBase
    {

        #region 参数成员



        #region 自定义事件
        //定义委托
        public delegate void EventHandler(object sender, EventArgs e);

        //定义事件
        public event EventHandler DataChanged;

        #endregion


        protected new void Page_Load(object sender, EventArgs e)
        {
            if (DataID == null) throw new Exception("删除按钮(" + ID + ")未指定数据项ID");
        }



        protected void DeletButton_Click(object sender, EventArgs e)
        {
            if (ProjectCompletion.ProjectDeteleVision(DataID))
            {
                Massage message = new Massage("Blue", "Success", "删除成功，请刷新页面");
                message.PostMassage();
                Response.Redirect(Request.Url.PathAndQuery);
            }
            else
            {
                Massage message = new Massage("Red", "ERROR", "删除失败");
                message.PostMassage();

            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            string gotoURL = "~/functionPage/QF-ChildPage/ResetPage.aspx?tablename=" + TableName + "&idlable=" + IDLable + "&id=" + DataID;
            Response.Redirect(gotoURL);
        }

        protected void DetailButton_Click(object sender, EventArgs e)
        {

        }
    }
}