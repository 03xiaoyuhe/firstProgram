using DAL;
using Models;
using System;
using WebForm.ASCX.Table.ForMyTable;

namespace WebForm.ASCX.Table.ForPeople
{
    public partial class DeletButten : ControlBase
    {
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

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            string gotoURL = "~/functionPage/QF-ChildPage/ResetPage.aspx?tablename=" + TableName + "&idlable=" + IDLable + "&id=" + DataID;
            Response.Redirect(gotoURL);
        }

        protected void DetailButton_Click(object sender, EventArgs e)
        {
            // G:\01____资源管理\______myProgram\哲学与社会科学规划项目信息化管理平台\firstProgram\web\Page\functionPage\QF-ChildPage\ForProject\ProgramDataShow.aspx
            string gotoURL = "~/Page/functionPage/QF-ChildPage/ForPeople/PeopleInformShow.aspx?tablename=" + TableName + "&idlable=" + IDLable + "&id=" + DataID;
            Response.Redirect(gotoURL);
        }
    }
}