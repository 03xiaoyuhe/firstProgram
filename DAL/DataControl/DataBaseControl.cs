using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DAL.DataControl
{
    /// <summary>
    /// 数据访问基类，用于提供数据访问基础的功能，如各种格式检测
    /// </summary>
    public class DataBaseControl
    {
        #region 数据检查

        /// <summary>
        /// 性别检查
        /// </summary>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public static bool CheckSex(string Data)
        {
            if (string.IsNullOrEmpty(Data)) { return false; }
            else if (Data.Length != 1) { return false; }
            else if (Data == "男" || Data == "女") { return true; }
            else return false;
        }


        /// <summary>
        /// 日期检查
        /// </summary>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public static bool CheckDate(string Data)
        {
            string Pattern = @"^(\d{4})-(\d{2})-(\d{2})$";
            return Regex.IsMatch(Data, Pattern);
        }


        /// <summary>
        /// 邮箱检查
        /// </summary>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public static bool CheckEmall(string Data)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(Data);
        }

        /// <summary>
        /// 手机检查
        /// </summary>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public static bool CheckMobilePhone(string Data)
        {
            string pattern = @"^(\d{11})$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(Data);
        }



        #endregion

        #region 构建where子句


        /// <summary>
        /// 构建SQL的WHERE子句
        /// </summary>
        /// <param name="conditions">键为字段名称，值为匹配的值</param>
        /// <returns>返回构建的WHERE子句字符串</returns>
        public static string BuildWhereClause(Dictionary<string, string> conditions)
        {
            if (conditions == null || conditions.Count == 0)
            {
                return "1 = 1"; // 默认条件，表示无条件
            }

            StringBuilder whereClause = new StringBuilder();
            foreach (var condition in conditions)
            {
                // 如果值包含通配符则进行模糊匹配
                if (condition.Value.Contains("%"))
                {
                    whereClause.Append($"{condition.Key} LIKE '{condition.Value}' AND ");
                }
                else
                {
                    whereClause.Append($"{condition.Key} = '{condition.Value}' AND ");
                }
            }

            // 移除最后一个 AND
            if (whereClause.Length > 0)
            {
                whereClause.Length -= 5; // " AND " 的长度
            }

            return whereClause.ToString();
        }

        /// <summary>
        /// 构建SQL的WHERE子句
        /// </summary>
        /// <param name="conditions">键为字段名称，值为可匹配的多个值</param>
        /// <returns>返回构建的WHERE子句字符串</returns>
        public static string BuildWhereClause(Dictionary<string, HashSet<string>> conditions)
        {
            if (conditions == null || conditions.Count == 0)
            {
                return "1 = 1"; // 默认条件，表示查询所有数据
            }

            StringBuilder whereClause = new StringBuilder();
            bool isFirstCondition = true;

            foreach (var condition in conditions)
            {
                string field = condition.Key;
                HashSet<string> values = condition.Value;

                if (values != null && values.Count > 0)
                {
                    if (!isFirstCondition)
                    {
                        whereClause.Append(" AND ");
                    }
                    else
                    {
                        isFirstCondition = false;
                    }

                    whereClause.Append("(");

                    bool isFirstValue = true;
                    foreach (var value in values)
                    {
                        if (!isFirstValue)
                        {
                            whereClause.Append(" OR ");
                        }
                        else
                        {
                            isFirstValue = false;
                        }

                        whereClause.Append($"{field} = '{value}'");
                    }

                    whereClause.Append(")");
                }
            }

            return whereClause.ToString();
        }

        #endregion
    }
}
