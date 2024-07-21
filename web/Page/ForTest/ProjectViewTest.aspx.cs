using DAL.DataControl.TableControl;
using DAL.DataControl.ViewControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm.Page.ForTest
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Start();
        }

        public void Start()
        {

            DataSet projectDataSet = (new ProjectViewContron()).Select(null, null, null, true, null, null);
            PrintDataSet(projectDataSet);
        }

        // 打印 DataSet 的方法（用于测试）
        private void PrintDataSet(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                this.Controls.Add(new Label()
                {
                    Text = $"---Table: {table.TableName}"
                });
                this.Controls.Add(new Panel());
                int RowCount = 0;
                foreach (DataRow row in table.Rows)
                {
                    this.Controls.Add(new Label()
                    {
                        Text = $"------Row{RowCount++}"
                    });
                    this.Controls.Add(new Panel());
                    foreach (DataColumn col in table.Columns)
                    {
                        this.Controls.Add(new Label()
                        {
                            Text = $"---------{col.ColumnName}: {row[col]}"
                        });
                        this.Controls.Add(new Panel());
                    }
                    this.Controls.Add(new Panel());
                }
            }
        }
    }
}