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
    }
}
