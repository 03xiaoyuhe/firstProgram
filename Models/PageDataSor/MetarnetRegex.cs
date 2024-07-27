using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using System.Collections;
using NPOI.XSSF.Streaming.Values;
using System.Linq.Expressions;
using DAL.DataControl.ViewControl;

namespace Models.PageDataSor
{
    /// <summary>
    /// 通过Framwork类库中的Regex类实现了一些特殊功能数据检查
    /// </summary>
    public class MetarnetRegex
    {

        private static MetarnetRegex instance = null;

        //CacheGenericity<List<string>> cacheGenericity = new CacheGenericity<List<string>>();
        //static List<string> lists = new List<string>();
        //static Hashtable hashtable = new Hashtable();

        /// <summary>
        /// 用于存放从数据库查出的以及网站中用户插入的立项编号
        /// </summary>
        static HashSet<string> hashset = new HashSet<string>();
        /// <summary>
        /// 清空hashSet
        /// </summary>
        public static void RemoveHash()
        {
            hashset = new HashSet<string>();
        }

        static HashSet<string> NameSerch = new HashSet<string>();
        //static Dictionary<string, HashSet<string>> keyValuePairs = new Dictionary<string, HashSet<string>>();

        /// <summary>
        /// 立项编号的查询与存储
        /// </summary>
        public static void Give()
        {

            //CacheGenericity<List<string>>.Data["立项编号"]  = new List<string>();
            
            //DataSet rowAfforts = (new ProjectViewContron()).Select(new List<string>() { });
            
            //DataTable dt = rowAfforts.Tables[0];
            ////int count = 0;
            //foreach(DataRow item in dt.Rows)
            //{
            //    hashset.Add(item[0].ToString());
            //    //CacheGenericity<List<string>>.Data["立项编号"].Add(item[0].ToString());
            //    //lists.Add(item[0].ToString());
            //    //hashtable.Add(count,item[0].ToString());
            //    //count++;
            //}
        }


        public static void Name()
        {
            DataSet rowAfforts = DAL.DBHelper.Query("select  UseName from UserInfor");
            DataTable dt = rowAfforts.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                if (!NameSerch.Contains(item[0].ToString()))
                {
                    NameSerch.Add(item[0].ToString());
                }
                
            }


        }

        static int  Count = 0;
        /// <summary>
        /// 导入表格数据检查函数
        /// </summary>
        /// <param name="Kinds">类别描述</param>
        /// <param name="Data">当前单元格数据</param>
        /// <returns></returns>
        public static string Checked(string Kinds, string Data)
        {
            int count = 0;
            
            switch (Kinds)
            {
                case "课题名称":
                    if (Data.Length < 50)
                    {
                        return "Success";
                    }
                    else
                    {
                        return $"(项目名称长度超过限制){Data}";
                    }
                     
                case "项目评级":
                    if (Data.Length != 1)
                    {
                        return $"(项目评级只能为单个大写字母){Data}";
                    }
                    else if (Data[0] < 65 || Data[0] > 70)
                    {
                        return $"(项目评级只能为A-E的大写字母){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                case "项目状态":
                    if (Data == "申报" || Data == "在研" || Data == "结项" || Data == "结项" || Data == "结项")
                    {
                        return "Success";
                    }
                    else return "(只能为\"申报\"、\"在研\"、\"结项\"、\"结项\"、\"结项\"，中的一项)";

                case "项目类别":
                    if (Data.Length > 50)
                    {
                        return $"(项目类别长度过长，最多可输入50个字){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                case "学科分类":
                    if (Data.Length > 50)
                    {
                        return $"(学科分类长度过长，最多可输入50个字){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                case "最后成果形式":
                    if (Data.Length > 50)
                    {
                        return $"(最后成果形式长度过长，最多可输入50个字){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                case "是否符合青年项目申报条件":
                    if (Data.Length != 1)
                    {
                        return $"(填写长度不规范，请填写“是”或“否”){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                     
                    //todo
                case "项目负责人":

                    return "Success";
                     
                case "本项目国内外研究现状述评":
                    if (Data.Length > 1300)
                    {
                        return $"(填写的述评长度过长，请限制在1300字内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                     
                case "本项目研究的主要观点":
                    if (Data.Length > 2100)
                    {
                        return $"(填写的主要观点长度过长，请限制在2100字内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                     
                case "前期研究成果":
                    if (Data.Length > 1000)
                    {
                        return $"(填写的主要观点长度过长，请限制在1000字内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                     

                case "项目完成时间":
                case "填表日期":
                case "专家组评审意见时间":
                case "审批意见时间":
                case "所在单位评审意见时间":
                    try
                    {
                        DateTime.Parse(ExcelDateToSQLDate(Data));
                        return "Success";
                    }
                    catch
                    {
                        return $"(不是正确的日期格式，请按照年-月-日填写){Data}";
                    }
                     
                case "成果形式":
                    if (Data.Length > 50)
                    {
                        return $"(成果形式填写过长，请控制在50字以内){Data}";
                    }
                    else{
                        return "Success";
                    }

                case "项目国内外研究现状述评，选题意义及价值":
                case "项目研究的主要观点、基本思路和方法、重点难点及创新之处":
                case "项目负责人和主要成员前期研究成果及主要参考文献":
                    if (Data.Length > 1200)
                    {
                        return $"(填写过长，请控制在1200字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }


                case "所在单位评审意见":
                case "审批意见":
                case "专家组评审意见":
                    if (Data.Length > 500)
                    {
                        return $"(填写过长，请控制在500字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     
                case "立项编号":
                    if (Data.Length != 12)
                    {
                        return $"(立项编号的长度不合法，应为五位大写字母加七位整数){Data}";
                    }
                    else
                    {
                        if (!IsProjectNumber(Data))
                        {
                            return $"(输入的立项编号不规范，应为五位大写字母加七位整数){Data}";
                        }

                    
                        if (hashset.Contains(Data))
                        {
                            return $"(输入的立项编号合法，但已经存在，请重新输入){Data}";
                        }
                        Count++;
                        if(Count%2 == 0)
                        {
                            hashset.Add(Data);
                        }
                        
                      
                        return "Success";

                    }
                     

                case "姓名":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        if (NameSerch.Contains(Data))
                        {
                           return $"(该姓名已存在，请你检查是否需要插入，如果需要请你在名字后添加一个特殊字符){Data}";
                        }
                        else
                        {
                            NameSerch.Add(Data);
                            return "Success";
                        }
                    }
                     

                case "生日":
                    try
                    {
                        DateTime.Parse(ExcelDateToSQLDate(Data));
                        return "Success";
                    }
                    catch
                    {
                        return $"(不是正确的日期格式，请按照年-月-日填写){Data}";
                    }
                     

                case "性别":
                    if (Data.Length > 1)
                    {
                        return $"(请填写男或女，您填的性别有点太长了){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                     

                case "职务":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     

                case "职称":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     
                case "专业":
                    if (Data.Length > 30)
                    {
                        return $"(填写过长，请控制在30字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     
                case "研究专长":
                    if (Data.Length > 50)
                    {
                        return $"(填写过长，请控制在50字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     

                case "现从事职业":
                    if (Data.Length > 30)
                    {
                        return $"(填写过长，请控制在30字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     

                case "工作单位":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     
                case "通信地址":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     

                    //////////////todo
                case "办公电话":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }

                     

                case "电话号码":
                    if (Data.Length > 11)
                    {
                        return $"(填写过长，请符合电话号码的规范控制在11个整数内){Data}";
                    }
                    else
                    {
                        if (IsMobilePhone(Data))
                        {
                            return "Success";
                        }
                        else
                        {
                            return $"(填写的电话号码不符合规范，请填11位以1开头的数字。){Data}";
                        }
                        
                    }

                case "队员0":
                case "队员1":
                case "队员2":
                case "队员3":
                case "队员4":
                case "队员5":
                case "队员6":
                case "队员7":
                case "队员8":
                case "队员9":
                case "队员10":
                case "队员11":
                case "队员12":
                case "队员13":
                    return "Success";



                case "邮箱":
                    if (Data.Length > 20)
                    {
                        return $"(填写过长，请控制在20字以内){Data}";
                    }
                    else
                    {
                        if (IsEmail(Data))
                        {
                            return "Success";
                        }
                        else
                        {
                            return  $"(填写的邮箱不规范，请检查该邮箱的格式){Data}";
                        }
                    }
                     

            }



            return $"(系统出现异常请联系工作人员){Data}";
        }


        public static string filterInfor(string Kinds, string Data)
        {
            switch (Kinds)
            {
                case "姓名":
                    return RetainChineseString(Data);
            }
            return Data;
        }


        #region 正则表达式判断函数及转化函数-特例




        /// <summary>
        /// 将指定格式的字符串转换为数据库可识别日期，若不匹配则返回原值
        /// </summary>
        /// <param name="input">待转换的字符</param>
        /// <returns>转换后的字符</returns>
        public static string ExcelDateToSQLDate(string input)
        {
            string ExcelPattern = @"(\d{1,2})-(\d{1,2})月-(\d{4})";
            if (Regex.IsMatch(input, ExcelPattern))
            {
                string pattern = @"月?-月?";
                string[] Day = Regex.Split(input, pattern);
                return $"{Day[2]}/{Day[1]}/{Day[0]}";
            }
            else
            {
                return input;
            }
        }

        /// <summary>
        /// 检查立项编号
        /// </summary>
        /// <param name="input">待检查的字符</param>
        /// <returns>是否匹配</returns>
        public static bool IsProjectNumber(string input)
        {
            string pattern = @"[A-Z]{5}\d{7}";
            return Regex.IsMatch(input, pattern);
        }

        public static MetarnetRegex GetInstance()
            {
                if (MetarnetRegex.instance == null)
                {
                    MetarnetRegex.instance = new MetarnetRegex();
                }
                return MetarnetRegex.instance;
            }

        #endregion

        private MetarnetRegex()
            {

            }


        /// <summary>
        /// 去除掉汉字中的特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RetainChineseString(string str)
        {
            StringBuilder chineseString = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 0x4E00 && str[i] <= 0x9FA5 || str[i] == '·') //汉字
                {
                    chineseString.Append(str[i]);
                }
            }
            return chineseString.Length > 0 ? chineseString.ToString() : string.Empty;
        }
        /// <summary>
        /// 判断输入的字符串只包含汉字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsChineseCh(string input)
            {
                Regex regex = new Regex("^[\u4e00-\u9fa5]+$");
                return regex.IsMatch(input);
            }
            /// <summary>
            /// 匹配3位或4位区号的电话号码，其中区号可以用小括号括起来，
            /// 也可以不用，区号与本地号间可以用连字号或空格间隔，
            /// 也可以没有间隔
            /// \(0\d{2}\)[- ]?\d{8}|0\d{2}[- ]?\d{8}|\(0\d{3}\)[- ]?\d{7}|0\d{3}[- ]?\d{7}
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsPhone(string input)
            {
                string pattern = "^\\(0\\d{2}\\)[- ]?\\d{8}$|^0\\d{2}[- ]?\\d{8}$|^\\(0\\d{3}\\)[- ]?\\d{7}$|^0\\d{3}[- ]?\\d{7}$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(input);
            }
            /// <summary>
            /// 判断输入的字符串是否是一个合法的手机号
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsMobilePhone(string input)
            {
                Regex regex = new Regex("^1\\d{10}$");
                return regex.IsMatch(input);

            }


            /// <summary>
            /// 判断输入的字符串只包含数字
            /// 可以匹配整数和浮点数
            /// ^-?\d+$|^(-?\d+)(\.\d+)?$
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsNumber(string input)
            {
                string pattern = "^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(input);
            }
            /// <summary>
            /// 匹配非负整数
            ///
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsNotNagtive(string input)
            {
                Regex regex = new Regex(@"^\d+$");
                return regex.IsMatch(input);
            }
            /// <summary>
            /// 匹配正整数
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsUint(string input)
            {
                Regex regex = new Regex("^[0-9]*[1-9][0-9]*$");
                return regex.IsMatch(input);
            }
            /// <summary>
            /// 判断输入的字符串字包含英文字母
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsEnglisCh(string input)
            {
                Regex regex = new Regex("^[A-Za-z]+$");
                return regex.IsMatch(input);
            }


            /// <summary>
            /// 判断输入的字符串是否是一个合法的Email地址
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsEmail(string input)
            {
                string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(input);
            }


            /// <summary>
            /// 判断输入的字符串是否只包含数字和英文字母
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsNumAndEnCh(string input)
            {
                string pattern = @"^[A-Za-z0-9]+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(input);
            }


            /// <summary>
            /// 判断输入的字符串是否是一个超链接
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsURL(string input)
            {
                //string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                string pattern = @"^[a-zA-Z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";
                System.Text.RegularExpressions.Regex regex = new Regex(pattern);
                return regex.IsMatch(input);
            }


            /// <summary>
            /// 判断输入的字符串是否是表示一个IP地址
            /// </summary>
            /// <param name="input">被比较的字符串</param>
            /// <returns>是IP地址则为True</returns>
            public static bool IsIPv4(string input)
            {

                string[] IPs = input.Split('.');
                Regex regex = new Regex(@"^\d+$");
                for (int i = 0; i < IPs.Length; i++)
                {
                    if (!regex.IsMatch(IPs[i]))
                    {
                        return false;
                    }
                    if (Convert.ToUInt16(IPs[i]) > 255)
                    {
                        return false;
                    }
                }
                return true;
            }


            /// <summary>
            /// 计算字符串的字符长度，一个汉字字符将被计算为两个字符
            /// </summary>
            /// <param name="input">需要计算的字符串</param>
            /// <returns>返回字符串的长度</returns>
            public static int GetCount(string input)
            {
                return Regex.Replace(input, @"[\u4e00-\u9fa5/g]", "aa").Length;
            }

            /// <summary>
            /// 调用Regex中IsMatch函数实现一般的正则表达式匹配
            /// </summary>
            /// <param name="pattern">要匹配的正则表达式模式。</param>
            /// <param name="input">要搜索匹配项的字符串</param>
            /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
            public static bool IsMatch(string pattern, string input)
            {
                System.Text.RegularExpressions.Regex regex = new Regex(pattern);
                return regex.IsMatch(input);
            }

            /// <summary>
            /// 从输入字符串中的第一个字符开始，用替换字符串替换指定的正则表达式模式的所有匹配项。
            /// </summary>
            /// <param name="pattern">模式字符串</param>
            /// <param name="input">输入字符串</param>
            /// <param name="replacement">用于替换的字符串</param>
            /// <returns>返回被替换后的结果</returns>
            public static string Replace(string pattern, string input, string replacement)
            {
                Regex regex = new Regex(pattern);
                return regex.Replace(input, replacement);
            }

            /// <summary>
            /// 在由正则表达式模式定义的位置拆分输入字符串。
            /// </summary>
            /// <param name="pattern">模式字符串</param>
            /// <param name="input">输入字符串</param>
            /// <returns></returns>
            public static string[] Split(string pattern, string input)
            {
                Regex regex = new Regex(pattern);
                return regex.Split(input);
            }
            /// <summary>
            /// 判断输入的字符串是否是合法的IPV6 地址
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public static bool IsIPV6(string input)
            {
                string pattern = "";
                string temp = input;
                string[] strs = temp.Split(':');
                if (strs.Length > 8)
                {
                    return false;
                }
                int count = MetarnetRegex.GetStringCount(input, "::");
                if (count > 1)
                {
                    return false;
                }
                else if (count == 0)
                {
                    pattern = @"^([\da-f]{1,4}:){7}[\da-f]{1,4}$";

                    Regex regex = new Regex(pattern);
                    return regex.IsMatch(input);
                }
                else
                {
                    pattern = @"^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$";
                    Regex regex1 = new Regex(pattern);
                    return regex1.IsMatch(input);
                }

            }
            /* *******************************************************************
            * 1、通过“:”来分割字符串看得到的字符串数组长度是否小于等于8
            * 2、判断输入的IPV6字符串中是否有“::”。
            * 3、如果没有“::”采用 ^([\da-f]{1,4}:){7}[\da-f]{1,4}$ 来判断
            * 4、如果有“::” ，判断"::"是否止出现一次
            * 5、如果出现一次以上 返回false
            * 6、^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$
            * ******************************************************************/
            /// <summary>
            /// 判断字符串compare 在 input字符串中出现的次数
            /// </summary>
            /// <param name="input">源字符串</param>
            /// <param name="compare">用于比较的字符串</param>
            /// <returns>字符串compare 在 input字符串中出现的次数</returns>
            private static int GetStringCount(string input, string compare)
            {
                int index = input.IndexOf(compare);
                if (index != -1)
                {
                    return 1 + GetStringCount(input.Substring(index + compare.Length), compare);
                }
                else
                {
                    return 0;
                }

            }
        }
    }
