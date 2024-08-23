using Models.ErroModels;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Models.PageDataSor
{
    /// <summary>
    /// 数据行开始读入委托
    /// </summary>
    public delegate void DataLineReadStart();

    /// <summary>
    /// 数据行读入结束委托
    /// </summary>
    /// <param name="Attribute">标识表头是否为必填项</param>
    /// <param name="ExcelHeadLineData">中文表头-对应字段 转化</param>
    /// <param name="DataHead">当前行的数据表头</param>
    /// <param name="flag">当前行是否成功读入</param>
    /// <param name="dataRow">当前行读入的数据</param>
    /// <param name="cells">当前行的单元格</param>
    public delegate void DataLineReadEnd(Dictionary<string, bool> Attribute, Dictionary<string, string> ExcelHeadLineData, List<string> DataHead, bool flag, DataRow dataRow, IRow cells);

    /// <summary>
    /// 数据检查委托
    /// </summary>
    /// <param name="Data">待检查的数据</param>
    /// <returns>如果数据无异常则返回Success，有异常则返回报错信息</returns>
    public delegate string DataCheck(string Data);

    public class ExcelRead
    {
        Dictionary<string, bool> attrubite;
        /// <summary>
        /// 标识表头是否为必填项
        /// </summary>
        public Dictionary<string, bool> Attribute
        {
            get
            {
                if (attrubite == null) { throw new Exception("未绑定列信息描述及必要性描述"); }
                return attrubite;
            }
            set
            {
                attrubite = value;
            }
        }

        Dictionary<string, string> excelHeadLineDataColu;
        /// <summary>
        /// 中文表头-对应字段 转化
        /// </summary>
        public Dictionary<string, string> ExcelHeadLineData
        {
            get
            {
                if (excelHeadLineDataColu == null)
                {
                    throw new Exception("未绑定列信息描述及必要性描述");
                }
                return excelHeadLineDataColu;
            }
            set
            {
                excelHeadLineDataColu = value;
            }
        }

        Dictionary<string, DataCheck> checkFunSet;
        /// <summary>
        /// 用来存放对不同字段的检查函数
        /// </summary>
        public Dictionary<string, DataCheck> CheckFunSet
        {
            get
            {
                if (excelHeadLineDataColu == null)
                {
                    throw new Exception("未绑定不同字段的检查函数");
                }
                return checkFunSet;
            }
            set
            {
                checkFunSet = value;
            }
        }

        string erroPutExelPath;
        /// <summary>
        /// 错误输出Excel表路径
        /// </summary>
        public string ErroPutExcelPath
        {
            get
            {
                if (erroPutExelPath == null)
                {
                    throw new Exception("未绑定错误行输出Excel表");
                }
                return erroPutExelPath;
            }
            set
            {
                erroPutExelPath = value;
            }
        }

        string inputExcelPath;
        /// <summary>
        /// 输入表路径
        /// </summary>
        public string InputExcelPath
        {
            get
            {
                if (inputExcelPath == null) { throw new Exception("未绑定输入Excel表"); }
                return inputExcelPath;
            }
            set
            {
                inputExcelPath = value;
            }
        }

        /// <summary>
        /// 载入excel文件函数
        /// </summary>
        /// <param name="ErroRow">错误数据行数</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// 文件“F:\CloneFromGitHub\firstProgram\firstProgram\web\uploadfiles\erro133588353873406294ErroExcel (1).xlsx”正由另一进程使用，因此该进程无法访问此文件。
        public DataTable LoadExcel(out int ErroRow)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            FileStream fs;
            IWorkbook workbook = null;
            IWorkbook erroworkbook = null;
            int cellCount = 0;//列数
            int rowCount = 0;//行数
            int ErroRowCount = 0;


            //判断文件是否存在
            fs = new FileStream(InputExcelPath, FileMode.Open, FileAccess.Read);
            FileStream errofs = new FileStream(ErroPutExcelPath, FileMode.Create, FileAccess.ReadWrite);
            if (InputExcelPath.IndexOf(".xlsx") > 0) // 2007版本
            {
                workbook = new XSSFWorkbook(fs);
                erroworkbook = new XSSFWorkbook();
            }
            else if (InputExcelPath.IndexOf(".xls") > 0) // 2003版本
            {
                workbook = new HSSFWorkbook(fs);
                erroworkbook = new HSSFWorkbook();
            }

            sheet = workbook.GetSheetAt(0);
            ISheet erroSheet = erroworkbook.CreateSheet("erroSheet");

            if (sheet != null)
            {
                // 用来记录输入表中的所有字段，以及出现顺序
                List<string> DataHead = new List<string>();

                IRow firstRow = sheet.GetRow(0);
                cellCount = firstRow.LastCellNum;
                IRow erroHead = erroSheet.CreateRow(0);

                // 错误数据表表头，数据集字段集合初始化
                for (int i = 0; i < cellCount; i++)
                {
                    DataHead.Add(firstRow.GetCell(i).StringCellValue);
                    erroHead.CreateCell(i).SetCellValue(firstRow.GetCell(i).StringCellValue);

                    // 判断，如果表中字段为预设字段，则 将表中字段翻译为数据库字段并将该字段添加到数据集变量的列集合中
                    if (Attribute.ContainsKey(firstRow.GetCell(i).StringCellValue))
                    {
                        DataColumn column = new DataColumn(excelHeadLineDataColu[firstRow.GetCell(i).StringCellValue]);
                        data.Columns.Add(column);
                    }
                }

                // 遍历字段级别描述变量，以判断是否遗漏必须行
                foreach (KeyValuePair<string, bool> pair in Attribute)
                {
                    if (!DataHead.Contains(pair.Key) && pair.Value) throw new LineAbsentException($"缺少必须行->{pair.Key}");
                }
                //统计出总行数，准备遍历以读取数据
                rowCount = sheet.LastRowNum;
                for (int i = 1; i <= rowCount; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null)
                    {
                        continue; //没有数据的行默认是null;
                    }
                    DataRow dataRow = data.NewRow();
                    int DataCellCount = 0;
                    // 记录是否为无效行 false - 不是 true - 是
                    bool flag = false;
                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                    {
                        // 判断当前是否 缺少了必须行
                        if ((row.GetCell(j) == null && Attribute[DataHead[j]]))
                        {
                            flag = true;
                            break;
                        }

                        // 判断当前是否为多余数据列
                        if (Attribute.ContainsKey(firstRow.GetCell(j).StringCellValue))
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                // 数据前向过滤
                                // 将日期转化为正常格式
                                dataRow[DataCellCount] = MetarnetRegex.ExcelDateToSQLDate(row.GetCell(j).ToString());

                                // 对数据表中当前行做数据验证 若不符合则跳出
                                if (MetarnetRegex.Checked(DataHead[j], dataRow[DataCellCount].ToString()) != "Success")
                                {
                                    flag = true;
                                    break;
                                }

                                dataRow[DataCellCount] = MetarnetRegex.filterInfor(DataHead[j], dataRow[DataCellCount].ToString());
                            }
                            DataCellCount++;
                        }
                    }
                    // 异常输出处理，即当check函数输出不为Success时，说明该行存在问题，则应该将该行添加到异常输出处理中
                    if (!flag) data.Rows.Add(dataRow);
                    else
                    {
                        ErroRowCount++;
                        erroSheet.CreateRow(ErroRowCount);
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            // 判断当前是否 缺少了必须行 如果缺失则输出提示
                            if ((row.GetCell(j) == null && Attribute[DataHead[j]]))
                            {
                                IRow erroRow = erroSheet.GetRow(ErroRowCount);
                                erroRow.CreateCell(j).SetCellValue("缺少必填内容");
                                continue;
                            }
                            // 若当前行缺少但不为必须行则什么也不做
                            if (row.GetCell(j) != null)
                            {
                                /// 将当前数据做转化,以解决日期问题
                                string Data;
                                Data = MetarnetRegex.ExcelDateToSQLDate(row.GetCell(j).ToString());

                                // 判断当前行是否为需要检查行，若需要检查则进行检查，
                                if (Attribute.ContainsKey(erroHead.GetCell(j).ToString()))
                                {
                                    string Out = MetarnetRegex.Checked(erroHead.GetCell(j).ToString(), Data);
                                    if (Out != "Success")
                                    {
                                        IRow erroRow = erroSheet.GetRow(ErroRowCount);
                                        erroRow.CreateCell(j).SetCellValue(Out);
                                    }
                                    else
                                    {
                                        IRow erroRow = erroSheet.GetRow(ErroRowCount);
                                        erroRow.CreateCell(j).SetCellValue(Data);
                                    }
                                }
                                else
                                {
                                    IRow erroRow = erroSheet.GetRow(ErroRowCount);
                                    erroRow.CreateCell(j).SetCellValue(Data);
                                }
                            }
                        }
                    }
                }
            }
            using (errofs)
            {
                erroworkbook.Write(errofs);//向打开的这个xls文件中写入数据
            }

            // 关闭文件解除资源占用
            errofs.Close();
            fs.Close();

            // 输出错误行数统计
            ErroRow = ErroRowCount;
            return data;
        }

    }
}
