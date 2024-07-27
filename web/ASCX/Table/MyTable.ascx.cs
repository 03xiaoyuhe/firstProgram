using DAL;
using Models;
using Models.PageDataSor.ForMyTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebForm.ASCX.Table
{
    public partial class MyTable : System.Web.UI.UserControl
    {

        #region 自定义参数


        #region 表格样式参数

        int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        #endregion


        #region 表格数据绑定属性

        DataTable dataCollection;
        /// <summary>
        /// 表单数据集
        /// </summary>
        public DataTable DataCollection
        {
            get
            {
                return dataCollection;
            }

            set
            {
                dataCollection = value;
            }
        }

        TableAttribute tableBase = null;
        /// <summary>
        /// 绑定数据说明属性
        /// </summary>
        public TableAttribute TableBase
        {
            get
            {
                return tableBase;
            }
            set
            {
                tableBase = value;
            }
        }

        #region 解释绑定数据属性

        /// <summary>
        /// 解释主键字段名
        /// </summary>
        public string IDLable
        {
            get
            {
                return TableBase.IDLable;
            }
            set
            {
                TableBase.IDLable = value;
            }
        }

        /// <summary>
        /// 解释绑定数据库对应表单
        /// </summary>
        public string TableName
        {
            get
            {
                if (TableBase.DataBase == null) throw new Exception("表格未绑定表单");
                return TableBase.DataBase;
            }
            set
            {
                TableBase.DataBase = value;
            }
        }


        /// <summary>
        /// 解释数据总行数
        /// </summary>
        public int RowsCount
        {
            get
            {
                if (dataCollection != null)
                {
                    return DataCollection.Rows.Count;
                }
                return 0;
            }
        }

        #endregion

        #endregion

        #region 其他 如控制性属性
        bool showCheck;
        public bool ShowCheck
        {
            get
            {
                return showCheck;
            }
            set
            {
                showCheck = value;
            }
        }

        bool showControl;
        /// <summary>
        /// 是否要显示控制行
        /// </summary>
        public bool ShowControl
        {
            get
            {
                return showControl;
            }
            set
            {
                showControl = value;
            }
        }

        string controlASCX;
        /// <summary>
        /// 绑定功能列的组件
        /// </summary>
        public string ControlASCX
        {
            get
            {
                return controlASCX;
            }
            set
            {
                controlASCX = value;
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
                if (choosedDataID == null) choosedDataID = GetRandomStr(10);
                return choosedDataID;
            }
            set
            {
                choosedDataID = value;
            }
        }

        int Count
        {
            get
            {
                if (ViewState["TableLineControlCount"] == null)
                    ViewState["TableLineControlCount"] = 0;
                return (int)ViewState["TableLineControlCount"];
            }
            set
            {
                ViewState["TableLineControlCount"] = value;
            }
        }

        #endregion

        #endregion

        #region 自定义事件

        public event EventHandler DataChanged;

        #endregion


        public void Page_Load(object sender, EventArgs e)
        {

            HeadHolder.Controls.Clear();
            BodyHolder.Controls.Clear();

            if (!ChoosedDataIDContain.Contian(ChoosedDataID))
            {
                ChoosedDataIDContain.Creat(ChoosedDataID);
            }
            List<string> NewLineToShow = new List<string>();
            foreach(string item in TableBase.LineToShow)
            {
                if (DataCollection.Columns.Contains(item)) NewLineToShow.Add(item);
            }
            TableBase.LineToShow = NewLineToShow;
            if(Height != 0 )stickytable.Style["height"] = Height + "px";
            LineForHead NewHead = (LineForHead)LoadControl("~/ASCX/Table/ForMyTable/LineForHead.ascx");
            NewHead.LineToShow = TableBase.LineToShow;
            NewHead.LineToMean = TableBase.LineToMean;
            NewHead.ShowCheck = ShowCheck;
            // 初始化本表所有ID
            HashSet<string> AllDataID = new HashSet<string>();
            if(ShowCheck)
            for (int i = 0; i < RowsCount; i++)
            {
                AllDataID.Add(DataCollection.Rows[i][TableBase.IDLable].ToString());
            }
            NewHead.AllDataId = AllDataID;
            NewHead.ShowControl = ShowControl;
            NewHead.ChoosedDataID = ChoosedDataID;
            NewHead.UpdateTable += Update;
            NewHead.ChooseAll += ChooseAll;
            NewHead.UnChooseAll += UnChooseAll;
            NewHead.AllDataCount = RowsCount;
            HeadHolder.Controls.Add(NewHead);
            if (DataCollection != null)
            {
                if (RowsCount == 0)
                {
                    NullMassage.Visible = true;
                }
                for (int i = 0; i < RowsCount; i++)
                {
                    LineForBody NewLine = (LineForBody)LoadControl("~/ASCX/Table/ForMyTable/LineForBody.ascx");
                    NewLine.ID = ID + String.Format("_{0}", i);
                    NewLine.DataForALine = DataCollection.Rows[i];
                    NewLine.TheLineDateForTable = TableBase;
                    NewLine.ShowControl = ShowControl;
                    NewLine.ControlASCX = ControlASCX;
                    NewLine.ChoosedDataID = ChoosedDataID;
                    NewLine.ShowCheck = ShowCheck;
                    BodyHolder.Controls.Add(NewLine);
                    Count++;
                }
            }
            else
            {
                Massage massage = new Massage("#ff0000", "ERRO", "未将数据绑定到表格");
                massage.PostMassage();
            }
        }

        void ChooseAll(object sender, EventArgs e)
        {
            foreach(object item in BodyHolder.Controls)
            {
                LineForBody NewLine = (LineForBody)item;
                NewLine.Checked = true;
            }
        }


        void UnChooseAll(object sender, EventArgs e)
        {
            foreach (object item in BodyHolder.Controls)
            {
                LineForBody NewLine = (LineForBody)item;
                NewLine.Checked = false;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        private static Random random = new Random();
        /// <summary>
        /// 随机字符串
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string GetRandomStr(int length, string chars = null)
        {
            if (string.IsNullOrEmpty(chars))
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghizklmnopqrstuvwxyz0123456789";
            }
            //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
            choosedDataIDContain.ID = ChoosedDataID;
            Page_Load(sender, e);
        }

        public void ClearCheck()
        {
            
            if(!ChoosedDataIDContain.Contian(ChoosedDataID))
            {
                ChoosedDataIDContain.Creat(ChoosedDataID);
            }
            ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
            choosedDataIDContain.ID = ChoosedDataID;
            choosedDataIDContain.Clear();
        }


    }
}