using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using DAL.DataControl.TableControl;
using DAL.DataObject.TableObject;
using System.Data;
using DAL.DataObject.TableObject.ProjectApart;

namespace Test1001.ProjectControlTest
{
    class ForProjectTest
    {
        static public void Start()
        {
            try
            {
                // 初始化 ProjectControl 对象
                ProjectControl projectControl = new ProjectControl();

                // 测试插入功能
                ProjectData projectData = CreateDummyProjectData(); // 创建虚拟项目数据对象
                string insertedId = projectControl.InseartReturnID(projectData);
                Console.WriteLine($"Inserted Project ID: {insertedId}");

                // 测试查询功能
                Console.WriteLine("\nQuerying project data:");
                DataSet projectDataSet = projectControl.Select();
                PrintDataSet(projectDataSet);

                // 测试更新功能
                Console.WriteLine("\nUpdating project data:");
                projectData.Base.ProjectName = "Updated Project Name";
                int updateResult = projectControl.Update(insertedId,projectData);
                Console.WriteLine($"Update result: {updateResult}");

                // 再次查询以确认更新
                Console.WriteLine("\nRe-querying updated project data:");
                projectDataSet = projectControl.Select();
                PrintDataSet(projectDataSet);

                // 测试删除功能
                Console.WriteLine("\nDeleting project data:");
                int deleteResult = projectControl.Delete(insertedId);
                Console.WriteLine($"Delete result: {deleteResult}");

                // 再次查询以确认删除
                Console.WriteLine("\nRe-querying project data after deletion:");
                projectDataSet = projectControl.Select();
                PrintDataSet(projectDataSet);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // 创建虚拟的项目数据对象（用于测试）
        private static ProjectData CreateDummyProjectData()
        {
            ProjectData projectData = new ProjectData();

            // 填充项目基础信息
            projectData.Base = new ProjectBase()
            {
                ProjectName = "Test Project",
                ProjectCategory = "Test Category",
                DisciplineClassificaton = "Test Discipline",
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
        private static void PrintDataSet(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine($"Table: {table.TableName}");
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        Console.WriteLine($"{col.ColumnName}: {row[col]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

