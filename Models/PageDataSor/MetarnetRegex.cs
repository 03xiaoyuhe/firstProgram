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
        static HashSet<string> hashset = new HashSet<string>();

        
        public static void Give()
        {

            //CacheGenericity<List<string>>.Data["立项编号"]  = new List<string>();
            
            DataSet rowAfforts = DAL.DBHelper.Query("select project_number from ProjectApplications");
            DataTable dt = rowAfforts.Tables[0];
            //int count = 0;
            foreach(DataRow item in dt.Rows)
            {
                hashset.Add(item[0].ToString());
                //CacheGenericity<List<string>>.Data["立项编号"].Add(item[0].ToString());
                //lists.Add(item[0].ToString());
                //hashtable.Add(count,item[0].ToString());
                //count++;
            }
        }

        public static string Checked(string Kinds, string Data)
        {

            
            switch (Kinds)
            {
                case "项目名称":
                    if (Data.Length < 50)
                    {
                        return "Success";
                    }
                    else
                    {
                        return $"(项目名称长度超过限制){Data}";
                    }
                    break;
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
                    break;
                
                case "项目类别":
                    if(Data.Length > 50)
                    {
                        return $"(项目类别长度过长，最多可输入50个字){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "是否符合青年项目申报条件":
                    if (Data.Length != 1)
                    {
                        return $"(填写长度不规范，请填写“是”或“否”){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "本项目国内外研究现状述评":
                    if (Data.Length > 1300)
                    {
                        return $"(填写的述评长度过长，请限制在1300字内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "本项目研究的主要观点":
                    if (Data.Length > 2100)
                    {
                        return $"(填写的主要观点长度过长，请限制在2100字内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "前期研究成果":
                    if (Data.Length > 1000)
                    {
                        return $"(填写的主要观点长度过长，请限制在1000字内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "项目完成时间":
                    try
                    {
                        DateTime.Parse(Data);
                        return "Success";
                    }
                    catch
                    {
                        return $"(不是正确的日期格式，请按照年-月-日填写){Data}";
                    }
                    break;
                case "成果形式":
                    if (Data.Length > 50)
                    {
                        return $"(成果形式填写过长，请控制在50字以内){Data}";
                    }
                    else{
                        return "Success";
                    }
                    break;
                case "项目单位评审意见":
                    if(Data.Length > 500)
                    {
                        return $"(填写过长，请控制在500字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "专家评审":
                    if (Data.Length > 500)
                    {
                        return $"(填写过长，请控制在500字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "项目审批意见":
                    if (Data.Length > 500)
                    {
                        return $"(填写过长，请控制在500字以内){Data}";
                    }
                    else
                    {
                        return "Success";
                    }
                    break;
                case "立项编号":
                    if (Data.Length != 12)
                    {
                        return $"(立项编号的长度不合法，应为五位大写字母加七位整数){Data}";
                    }
                    else
                    {
                        for (int i = 0; i < Data.Length; i++)
                        {
                            if (i < 5)
                            {
                                if (Data[i] < 65 && Data[i] > 90)
                                {
                                    return $"(前五位有非A-Z的大写字母){Data}";
                                }
                            }
                            else
                            {
                                if (Data[i] < 49 || Data[i] > 57)
                                {
                                    return $"(第六到七位有非0-9的整数数字){Data}";
                                }
                            }
                        }
                        if (hashset.Contains(Data))
                        {
                            return $"(输入的立项编号合法，但已经存在，请重新输入){Data}";
                        }
                        hashset.Add(Data);

                        //if (hashtable.ContainsValue(Data))
                        //{
                        //    return $"(输入的立项编号合法，但已经存在，请重新输入){Data}";
                        //}

                        //hashtable.Add(hashtable.Count, Data);

                        //for (int i = 0; i < lists.Count; i++)
                        //{
                        //    if (Data == lists[i])
                        //    {
                        //        return $"(输入的立项编号合法，但已经存在，请重新输入){Data}";
                        //    }
                        //}
                        //lists.Add(Data);
                        //for(int i =0;i< CacheGenericity<List<string>>.Data["立项编号"].Count; i++)
                        //{
                        //    if (Data == CacheGenericity<List<string>>.Data["立项编号"][i])
                        //    {
                        //        return $"(输入的立项编号合法，但已经存在，请重新输入){Data}";
                        //    }
                        //}

                        //CacheGenericity<List<string>>.Data["立项编号"].Add(Data);

                        return "Success";

                    }
                    break;
            }



            return $"(系统出现异常请联系工作人员){Data}"; 
        }
        public static MetarnetRegex GetInstance()
            {
                if (MetarnetRegex.instance == null)
                {
                    MetarnetRegex.instance = new MetarnetRegex();
                }
                return MetarnetRegex.instance;
            }
            private MetarnetRegex()
            {

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
                Regex regex = new Regex("^13\\d{9}$");
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
