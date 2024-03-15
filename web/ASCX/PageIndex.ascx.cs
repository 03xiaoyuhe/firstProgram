using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebForm.ASCX
{
    public partial class PageIndex : System.Web.UI.UserControl
    {
        protected struct Data
        {
            public string Text;
            public int modo; // 0 非当前页，1当前页
        }

        #region 自定义属性

        int index = 1;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
        #endregion


        #region 自定义事件

        //定义委托
        public delegate void EventHandler(object sender, EventArgs e);

        //定义事件
        public event EventHandler DataChanged;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Index = int.Parse(Request.QueryString["index"] == null ? "1" : Request.QueryString["index"]);
            if (Index < 1)
            {
                Response.Redirect(Request.Url.AbsolutePath + "?index=" + "1");
            }
            List<Data> list = new List<Data>();
            InitList(list);
            PrintList(list);
        }

        protected void InitList(List<Data> list)
        {
            if (Index <= 5)
            {
                int place = 1;
                while (place <= Index + 2)
                {
                    Data data = new Data();
                    data.Text = (place).ToString();
                    if ((place) == Index) data.modo = 1;
                    else data.modo = 0;
                    list.Add(data);
                    place++;
                }
                if (list.Count() < 5)
                {
                    place = int.Parse(list[list.Count() - 1].Text) + 1;
                    while (place <= 5)
                    {
                        Data data = new Data();
                        data.Text = place.ToString();
                        data.modo = 0;
                        list.Add(data);
                        place++;
                    }
                }
            }
            else
            {
                Data data = new Data();
                data.Text = "1";
                data.modo = 0;
                list.Add(data);
                data.Text = "...";
                data.modo = 0;
                list.Add(data);
                for (int i = -2; i < 3; i++)
                {
                    data.Text = (i + Index).ToString();
                    if (i == 0) data.modo = 1;
                    else data.modo = 0;
                    list.Add(data);
                }
            }
        }

        void PrintList(List<Data> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                ((Button)this.FindControl("A" + (i + 1).ToString())).Text = list[i].Text;
                ((Button)this.FindControl("A" + (i + 1).ToString())).Visible = true;
                if (list[i].modo == 0) { ((Button)this.FindControl("A" + (i + 1).ToString())).CssClass = "button"; }
                else
                {
                    ((Button)this.FindControl("A" + (i + 1).ToString())).CssClass = "indexbutton";
                }
            }
        }

        protected void Cleck(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "...") Response.Redirect(Request.Url.AbsolutePath + "?index=" + ((1 + Index) / 2).ToString());
            else if (((Button)sender).Text == "<") Response.Redirect(Request.Url.AbsolutePath + "?index=" + (Index - 1).ToString());
            else if (((Button)sender).Text == ">") Response.Redirect(Request.Url.AbsolutePath + "?index=" + (Index + 1).ToString());
            else Response.Redirect(Request.Url.AbsolutePath + "?index=" + ((Button)sender).Text);
        }
    }
}