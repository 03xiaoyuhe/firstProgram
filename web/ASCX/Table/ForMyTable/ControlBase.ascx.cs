using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForMyTable
{
    public partial class ControlBase : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 参数成员


        /// <summary>
        /// 由于不含DateBase 独立的变量
        /// </summary>
        string idLable;
        public string IDLable
        {
            get
            {
                return idLable;
            }
            set
            {
                idLable = value;
            }
        }

        /// <summary>
        /// 绑定数据库对应表单
        /// </summary>
        string tableName = null;
        public string TableName
        {
            get
            {
                if (tableName == null) throw new Exception("表格未绑定表单");
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        string dataID;
        public string DataID
        {
            get
            {
                return dataID;
            }
            set
            {
                dataID = value;
            }
        }

        #endregion
    }
}