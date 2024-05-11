using Models.PageDataSor;
using Models.PageDataSor.ForMyTable;
using Spire.Xls.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Filtrate
{
    public partial class MyCheckBox : UserControl
    {
        CheckBox checkBox;
        CheckBox CheckBox1
        {
            get
            {
                if(checkBox == null)
                {
                    checkBox = new CheckBox();
                }
                return checkBox;
            }
            set
            {
                checkBox = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBox1.CheckedChanged += CheckedChanged;
            CheckBox1.ID = $"{Text}1";
        }

        public string DataID;


        string choosedDataID;
        /// <summary>
        /// 复选框缓存对象ID
        /// </summary>
        public string ChoosedDataID
        {
            get
            {
                return choosedDataID;
            }
            set
            {
                choosedDataID = value;
            }
        }

        public bool Checked
        {
            get
            {
                return CheckBox1.Checked;
            }
            set
            {
                CheckBox1.Checked = value;
            }
        }
        public string Text
        {
            get
            {
                return CheckBox1.Text;
            }
            set
            {
                CheckBox1.Text = value;
            }
        }

        public EventHandler CheckedChanged;
    }
}