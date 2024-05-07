using Models.PageDataSor;
using Models.PageDataSor.Filtrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Filtrate
{
    public partial class FiltrateItemForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(AllChoose.Count > 0)
            {
                CheckBoxHolder.Controls.Clear();
                foreach (string item in AllChoose)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = item;
                    checkBox.CheckedChanged += CheckBoxOnChange;
                    if (FiltrateControl.Data[DataBaseTargate].Contains(item)) { checkBox.Checked = true; }
                    checkBox.Style["padding"] = "0 5px;";
                    CheckBoxHolder.Controls.Add(checkBox);
                    Label label = new Label();
                    label.Text = "  ";
                    CheckBoxHolder.Controls.Add(label);
                }
            }
        }

        HashSet<string> _allChoose;
        public HashSet<string> AllChoose
        {
            get
            {
                if (_allChoose == null) {  _allChoose = new HashSet<string>(); }
                return _allChoose;
            }
            set
            {
                _allChoose = value;
            }
        }

        string dataBaseTargate;
        public string DataBaseTargate
        {
            get
            {
                return dataBaseTargate;
            }
            set
            {
                dataBaseTargate = value;
            }
        }

        public string GetCacheIndex
        {
            get
            {
                return GetCheIndex(DataBaseTargate);
            }
        }
        
        public HashSet<string> Choosed
        {
            get
            {
                return CacheGenericity<HashSet<string>>.Data[GetCacheIndex];
            }
        }


        public string Title
        {
            get
            {
                return TitleLable.Text;
            }
            set { TitleLable.Text = value; }
        }

        public static string GetCheIndex(string key)
        {
            return $"Filtrate-Choose-{key}";
        }

        public void CheckBoxOnChange(object sender, EventArgs e)
        {
            CheckBox item = sender as CheckBox;
            if(item.Checked)
            {
                FiltrateControl.Data[DataBaseTargate].Add(item.Text);
            }
            else
            {
                FiltrateControl.Data[DataBaseTargate].Remove(item.Text);
            }
        }


    }
}