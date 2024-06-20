using DAL.DataBase;
using DAL.DataControl.Interface;
using DAL.DataObject.TableObject;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.DataControl.TableControl
{
    public class ProjectControl : DataBaseControl, IDataSelect, IDataInseart, IDataDelete, IDataUpdate
    {
        #region 查询功能
        /// <summary>
        /// 构建SQL查询语句
        /// </summary>
        /// <param name="OutTable"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        private string BulidSelectSQL(string OutTable, string where = "PeopleBase.PB_ID = PeopleBase.PB_ID")
        {
            string SQL =
            "-- 人员信息查询SQL                                   " + "\n" +

            "---- 变量定义区                                      " + "\n" +

            "DECLARE @SelectSQL NVARCHAR(MAX); --人员信息查询语句 " + "\n" +

            "DECLARE @Where nvarchar(MAX); --查询规则             " + "\n" +

            "DECLARE @SelectOutTable nvarchar(50); --定义输出表   " + "\n" +

            "---- 变量赋值区                                      " + "\n" +
           $"set @Where = '{where}';                              " + "\n" +
           $"set @SelectOutTable = '{OutTable}';                  " + "\n" +
            "set @SelectSQL =                                     " + "\n" +
            "'IF EXISTS                                           " + "\n" +
            "(                                                    " + "\n" +
            "    SELECT *                                         " + "\n" +
            "    FROM information_schema.tables                   " + "\n" +


            "    WHERE table_name = '''+@SelectOutTable+'''       " + "\n" +
            ")                                                    " + "\n" +
            "Drop Table '+@SelectOutTable+'                       " + "\n" +

            "select                                               " + "\n" +
            "PeopleBase.*,                                        " + "\n" +
            "PeoplePrincipalExpandData.PE_ID ,                    " + "\n" +
            "PeoplePrincipalExpandData.PE_Major,                  " + "\n" +
            "PeoplePrincipalExpandData.PE_Speciality,             " + "\n" +
            "PeoplePrincipalExpandData.PE_Engage,                 " + "\n" +
            "PeoplePrincipalExpandData.PE_Address,                " + "\n" +
            "PeoplePrincipalExpandData.PE_Employer,               " + "\n" +
            "PeoplePrincipalExpandData.PE_IsYouth,                " + "\n" +
            "PeoplePrincipalExpandData.PE_OfficePhone,            " + "\n" +
            "PeoplePrincipalExpandData.PE_MobilePhone,            " + "\n" +
            "PeoplePrincipalExpandData.PE_Email                   " + "\n" +

            "into '+@SelectOutTable+'                             " + "\n" +
            "from PeopleBase                                      " + "\n" +
            "left JOIN PeoplePrincipalExpandData on PeopleBase.PB_ID = PeoplePrincipalExpandData.PB_ID  " + "\n" +
            "where '+@Where+';                                    " + "\n" +
            "';                                                   " + "\n" +
            "EXECUTE sp_executesql @SelectSQL;                    " + "\n";


            return SQL;
        }
        public DataSet Select(string whereString = "PeopleBase.PB_ID = PeopleBase.PB_ID")
        {
            DBHelper.ExecuteSql(BulidSelectSQL(whereString, "SelectOutTable"));
            return OutputTable.Query("SelectOutTable");
        }

        public void Select(string OutTable, string whereString = "PeopleBase.PB_ID = PeopleBase.PB_ID")
        {
            DBHelper.ExecuteSql(BulidSelectSQL(whereString, OutTable));
        }

        #endregion

        #region 插入功能

        private string BuildInseartSQL(List<string> Fields, List<string> Datas)
        {
            string FieldsString = "";
            string DatesString = "";

            for (int i = 0; i < Fields.Count; i++)
            {
                if (i > 0) { FieldsString += ","; }
                FieldsString += $"'{Fields[i]}'";
            }
            for (int i = 0; i < Datas.Count; i++)
            {
                if (i > 0) FieldsString += ",";
                DatesString += $"'{Datas[i]}'";
            }
            string SQL =
               $"insert into ProjectBase({FieldsString})          \r\n" +
                "output inserted.PB_ID as id -- 返回插入数据的ID  \r\n" +
               $"values({DatesString});                           ";
            return SQL;
        }

        public int Inseart(Object item)
        {

        }

        public string InseartReturnID(Object item)
        {

        }
        // TODO 
        /// <summary>
        /// 插入项目基础数据，返回
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InseartBaseData(Object item)
        {
            ProjectData projectData = (ProjectData)item;
            if(projectData.IsEmpty())
            {
                return string.Empty;
            }
            projectData.Base.

        }

        #endregion
    }
}
