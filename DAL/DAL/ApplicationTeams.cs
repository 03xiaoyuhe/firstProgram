using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationTeams
    {

       /// <summary>
       /// 表名
       /// </summary>
        private static string formName = "ApplicationTeams";
        

        /// <summary>
        /// 字段名
        /// </summary>
        private static Dictionary<string, string> fieldName = new Dictionary<string, string>()
        {
            { "RecordID","RecordID" },
            { "TeamName","TeamName" },
            { "TeamLeader","TeamLeader" },
            { "CreationDate","CreationDate" },
        };


        /// <summary>
        /// 查询包含某字符串的所有信息<br/>
        /// 可指定查询的字段,无指定默认全部<br/>
        /// <br/>
        /// <b>字段名</b><br/>
        /// RecordID ------- 记录ID<br/>
        /// TeamName -- 小队名称<br/>
        /// TeamLeader ---- 负责人<br/>
        /// CreationDate - 创建日期<br/>
        /// 
        /// </summary>
        /// <param name="Str">需要查询的信息</param>
        /// <param name="moreParas">指定查询的字段,无指定默认全部</param>
        /// <returns></returns>
        public static DataSet Query(string Str,params string[]moreParas)
        {

            // Query

            DataSet ds = new DataSet();
            if(moreParas != null)
            {

            }
            else
            {
                // 
            }
        }

        /// <summary>
        /// 向表中添加行<br/>
        /// <br/>
        /// 需传入参数:<br/>
        /// TeamName>小队名称<br/>
        /// TeamLeader>负责人<br/>
        /// CreationDate>创建日期<br/>
        /// </summary>
        /// <param name="TeamName">小队名称</param>
        /// <param name="TeamLeader">负责人</param>
        /// <param name="CreationDate">创建日期</param>
        /// <returns></returns>
        public int addDate(string TeamName,string TeamLeader,string CreationDate)
        {
            // ExecuteSql
            

        }
    }
}
