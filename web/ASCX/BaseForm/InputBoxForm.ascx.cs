using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.BaseForm
{
    public partial class InputBoxForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 未输入消息提示词
        /// </summary>
        public string WarningMassage
        {
            get
            {
                return RequiredFieldValidator.Text;
            }
            set
            {
                RequiredFieldValidator.Text = value;
            }
        }

        /// <summary>
        /// 输入框类型
        /// </summary>
        public TextBoxMode TextBoxMode
        {
            get
            {
                return InputTextBox.TextMode;
            }
            set
            {
                InputTextBox.TextMode = value;
            }
        }

        /// <summary>
        /// 输入内容
        /// </summary>
        public string InputData
        {
            get
            {
                return InputTextBox.Text;
            }
            set
            {
                InputTextBox.Text = value;
            }
        }

        string note = "未设置";
        /// <summary>
        /// 提示框提示信息
        /// </summary>
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
            }
        }

    }
}