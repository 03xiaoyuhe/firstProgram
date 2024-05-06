using Models;
using Models.PageDataSor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Filtrate
{
    public partial class FiltrateForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AllFiltrate.Count > 0)
            {
                FiltrateItemHolder.Controls.Clear();
                foreach (KeyValuePair<string, HashSet<string>> item in  AllFiltrate)
                {
                    FiltrateItemForm filtrateItemForm = (FiltrateItemForm)LoadControl("~/ASCX/Filtrate/FiltrateItemForm.ascx");
                    filtrateItemForm.Title = AllFiltrateKeyToMean[item.Key];
                    filtrateItemForm.DataBaseTargate = item.Key;
                    filtrateItemForm.AllChoose = item.Value;
                    FiltrateItemHolder.Controls.Add(filtrateItemForm);
                }
            }
        }

        /// <summary>
        /// 获取确认筛选缓存的索引
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCacheIndex(string key)
        {
            return $"Filtrate-Choosed-{key}";
        }

        Dictionary<string, string> allFiltrateKeyToMean;
        /// <summary>
        /// 将筛选项的键翻译为筛选项标题
        /// </summary>
        public Dictionary<string, string> AllFiltrateKeyToMean
        {
            get
            {
                if(allFiltrateKeyToMean == null) allFiltrateKeyToMean = new Dictionary<string, string>();
                return allFiltrateKeyToMean;
            }
            set
            {
                allFiltrateKeyToMean = value;
            }
        }

        /// <summary>
        /// 获取用户所做的筛选
        /// </summary>
        public Dictionary<string, HashSet<string>> GetChoosed
        {
            get
            {
                Dictionary<string, HashSet<string>>  output = new Dictionary<string, HashSet<string>>();

                foreach (string key in AllFiltrate.Keys)
                {
                    output.Add(key, CacheGenericity<HashSet<string>>.Data[GetCacheIndex(key)]);
                }
                return output;
            }
        }

        Dictionary<string, HashSet<string>> allFiltrate;


        /// <summary>
        /// 绑定所有筛选项<br/>
        /// 键为数据库字段< br/>
        /// 值为该字段对应的所有筛选项
        /// </summary>
        public Dictionary<string, HashSet<string>> AllFiltrate
        {
            get
            {
                if(allFiltrate == null) allFiltrate = new Dictionary<string, HashSet<string>>();
                return allFiltrate;
            }
            set
            {
                allFiltrate = value;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Massage massage = new Massage();
            massage.MassageText = "";
            foreach (string s in GetChoosed["project_level"])
            {
                massage.MassageText += s;
            }
            massage.PostMassage();
            foreach (string key in AllFiltrate.Keys)
            {
                CacheGenericity<HashSet<string>>.Data[GetCacheIndex(key)] = CacheGenericity<HashSet<string>>.Data[FiltrateItemForm.GetCheIndex(key)];
            }
        }
    }
}