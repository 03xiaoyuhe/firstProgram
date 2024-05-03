using Models.PageDataSor.ForMyTable;
using Models.PageDataSor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices.ComTypes;
using Models;

namespace WebForm.ASCX.Table.ForMyTable
{
    public partial class CheckBoxTree : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        HashSet<string> _allDataId;
        /// <summary>
        /// 存放所有的数据ID
        /// </summary>
        public HashSet<string> AllDataId
        {
            get
            {
                if( _allDataId == null ) _allDataId = new HashSet<string>();
                return _allDataId;
            }
            set
            {
                if (_allDataId != value)
                {
                    _allDataId = value;
                }
            }
        }


        /// <summary>
        /// 用来存放表格控件刷新事件
        /// </summary>
        public EventHandler UpdateTable;

        public EventHandler ChooseAll;

        /// <summary>
        /// 解释缓存的数据
        /// </summary>
        HashSet<string> ChoosedDataIDContain
        { 
            get
            {
                ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
                choosedDataIDContain.ID = ChoosedDataID;
                return choosedDataIDContain.ChoosedIDs;
            }
            set
            {
                ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
                choosedDataIDContain.ID = ChoosedDataID;
                choosedDataIDContain.ChoosedIDs = value;
            }
        }

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

        public void HtmlBtn_Click(object sender, EventArgs e)
        {
            ChooseAll(sender, e);
        }
    }
}