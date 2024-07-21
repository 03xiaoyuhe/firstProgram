using DAL.DataControl.TableControl;
using DAL.DataObject.TableObject.ProjectApart;
using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using NPOI.SS.Formula.Functions;

namespace WebForm.ForDataControl
{
    public partial class ProjectControlTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Start();
        }
        public void Start()
        {
            try
            {
                // 初始化 ProjectControl 对象
                ProjectControl projectControl = new ProjectControl();

                // 测试插入功能
                ProjectData projectData = CreateDummyProjectData(); // 创建虚拟项目数据对象
                string insertedId = (new ProjectControl()).InseartReturnID(projectData);
                
                this.Controls.Add(new Label()
                {
                    Text = $"Inserted Project ID: {insertedId}"
                });
                this.Controls.Add(new Panel());
                // 测试查询功能
                this.Controls.Add(new Label()
                {
                    Text = "\nQuerying project data:"
                });
                this.Controls.Add(new Panel());
                DataSet projectDataSet = (new ProjectControl()).Select(null, null, null, true, null, null);
                PrintDataSet(projectDataSet);
                 
                this.Controls.Add(new Panel());
                projectData.Base.ProjectName = "Updated Project Name";
                int updateResult = (new ProjectControl()).Update(insertedId, projectData);
                this.Controls.Add(new Label()
                {
                    Text = $"Update result: {updateResult}"
                });
                this.Controls.Add(new Panel());

                // 再次查询以确认更新
                this.Controls.Add(new Label()
                {
                    Text = "\nRe-querying updated project data:"
                });
                this.Controls.Add(new Panel());
                projectDataSet = (new ProjectControl()).Select(null, null, null, true, null, null);
                PrintDataSet(projectDataSet);

                // 测试删除功能
                this.Controls.Add(new Label()
                {
                    Text = "\nDeleting project data:"
                });
                this.Controls.Add(new Panel());
                int deleteResult = (new ProjectControl()).DeleteByID(insertedId);
                this.Controls.Add(new Label()
                {
                    Text = $"Delete result: {deleteResult}"
                });
                this.Controls.Add(new Panel());

                // 再次查询以确认删除
                this.Controls.Add(new Label()
                {
                    Text = "\nRe-querying project data after deletion:"
                });
                this.Controls.Add(new Panel());
                projectDataSet = (new ProjectControl()).Select(null, null, null, true, null, null);
                PrintDataSet(projectDataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                this.Controls.Add(new Label()
                {
                    Text = $"Error occurred: {ex.Message}"
                });
                this.Controls.Add(new Panel());
            }


            this.Controls.Add(new Panel());

            this.Controls.Add(new Label()
            {
                Text = "\n--------->Test End"
            });
            this.Controls.Add(new Panel());
        }

        // 创建虚拟的项目数据对象（用于测试）
        private static ProjectData CreateDummyProjectData()
        {
            ProjectData projectData = new ProjectData();

            // 填充项目基础信息
            projectData.Base = new ProjectBase()
            {
                ProjectState = 1,
                ProjectName = "Test Project",
                ProjectCategory = "Category",
                DisciplineClassification = "Test Discipline",
                FillDate = "2024-7-8",
                Ending = "aaa",
                EndingDate = "2024-7-8"
            };

            // 填充项目拓展信息（这里假设其他拓展信息为空）
            projectData.DemonstrationExpand = new ProjectDemonstrationExpand()
            {
                ProjectSignificance = "Test Significance",
                ProjectDocument = "Test Document",
                ProjectReferences = "Test References"
            };

            return projectData;
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