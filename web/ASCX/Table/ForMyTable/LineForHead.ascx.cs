using DAL.DataControl.TableControl;
using Models;
using Models.PageDataSor;
using Models.PageDataSor.ForMyTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebForm.ASCX.Table.ForMyTable;

namespace WebForm.ASCX.Table
{
    public partial class LineForHead : System.Web.UI.UserControl
    {

        Dictionary<string, string> lineToMean = null;
        /// <summary>
        /// 表格列信息 以及对应中文
        /// </summary>
        public Dictionary<string, string> LineToMean
        {
            get
            {
                return lineToMean;
            }
            set
            {
                lineToMean = value;
            }
        }

        List<string> lineToShow = null;
        /// <summary>
        /// 设置需要显示的列以及显示顺序<br/>
        /// 注:使用表的字段名
        /// </summary>
        public List<string> LineToShow
        {
            get
            {
                return lineToShow;
            }
            set
            {
                lineToShow = value;
            }
        }

        HashSet<string> _allDataId;
        /// <summary>
        /// 存放所有的数据ID
        /// </summary>
        public HashSet<string> AllDataId
        {
            get
            {
                if (_allDataId == null) _allDataId = new HashSet<string>();
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

        bool showControl = false;
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

        public int ColumnNum
        {
            get { return lineToShow.Count; }
        }

        /// <summary>
        /// 用来存放表格控件刷新事件
        /// </summary>
        public EventHandler UpdateTable;

        public EventHandler ChooseAll;

        public EventHandler UnChooseAll;


        public int AllDataCount;

        string choosedDataID;
        /// <summary>
        /// 复选框缓存
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

        int Count
        {
            get
            {
                if (ViewState["HeadControlCount"] == null)
                    ViewState["HeadControlCount"] = 0;
                return (int)ViewState["HeadControlCount"];
            }
            set
            {
                ViewState["HeadControlCount"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            checkBox.AllDataId = AllDataId;
            checkBox.ChoosedDataID = ChoosedDataID;
            checkBox.AllDataCount = AllDataCount;
            checkBox.ChooseAll += ChooseAll;
            checkBox.UnChooseAll += UnChooseAll;
            checkBox.UpdateTable += UpdateTable;
            checkBox.Visible = ShowCheck;
            for (int i = 0; i < ColumnNum; i++)
            {
                CellForHead NewCell = (CellForHead)LoadControl("~/ASCX/Table/ForMyTable/CellForHead.ascx");
                NewCell.ID = ID + String.Format("_{0}", i);
                NewCell.CellData = LineToMean[lineToShow[i]];
                CellHolder.Controls.Add(NewCell);
                Count++;
            }
            PlaceHolder1.Visible = ShowControl;
        }

        protected void DeletButton_Click(object sender, EventArgs e)
        {           
            ChoosedDataIDContain choosedDataIDContain = new ChoosedDataIDContain();
            choosedDataIDContain.ID = ChoosedDataID;

            int ans = choosedDataIDContain.ChoosedIDs.Count;
            
            if(ans != 0)
            {
                foreach (string item in choosedDataIDContain.ChoosedIDs)
                {
                    if (
                        !(
                        (new ProjectControl()).Delete(null, ProjectControl.BuildWhereClause(new Dictionary<string, string>(){{ "PB_ID",item }}))>=1
                        )
                       )
                    {
                        Massage massage1 = new Massage();
                        massage1.MassageText = "项目ID为：" + item + "的项目删除失败！";
                        massage1.HeadColor = "Red";
                        massage1.HeadText = "ERROR";
                        massage1.PostMassage();
                        ans--;
                    }

                    
                }

                Massage massage12 = new Massage();
                if (ans == choosedDataIDContain.ChoosedIDs.Count)
                {
                    massage12.MassageText = "选择的所有项目均删除成功";
                    massage12.HeadText = "Success";
                    massage12.HeadColor = "Blue";
                }
                massage12.PostMassage();
                
                Response.Redirect(Request.Url.ToString());
            }
            else
            {
                Massage massage = new Massage();
                massage.MassageText = "未选择数据删除";
                massage.HeadText = "WANNING";
                massage.HeadColor = "Orange";
                massage.PostMassage();
            }
        }
            

    }
}