using Models.PageDataSor;
using Models.PageDataSor.ForMyTable;
using Spire.Xls.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table.ForMyTable
{
    public partial class MyCheckBox : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
            choosedDataIDContain.ID = ChoosedDataID;
            if (choosedDataIDContain.Contains(DataID))
            {
                CheckBox1.Checked = true;
            }
            else
            {
                //if (CacheGenericity<List<bool>>.Data[$"{ChoosedDataID}-ChooseAll"].Count > 0 && CacheGenericity<List<bool>>.Data[$"{ChoosedDataID}-ChooseAll"][0])
                //{
                //    choosedDataIDContain.Add(DataID);
                //    CheckBox1.Checked = true;
                //}
                //else
                //{
                    CheckBox1.Checked = false;
                //}
            }

            CheckBox1.CheckedChanged += CheckedChanged;

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


        public void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
                choosedDataIDContain.ID = ChoosedDataID;
                choosedDataIDContain.Add(DataID);
            }
            else
            {
                ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
                choosedDataIDContain.ID = ChoosedDataID;
                if (choosedDataIDContain.Contains(DataID))
                {
                    choosedDataIDContain.Add(DataID);
                }
            }
        }
    }
}