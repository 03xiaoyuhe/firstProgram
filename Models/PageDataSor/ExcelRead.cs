using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.PageDataSor
{
    public class ExcelRead
    {
        Dictionary<string, bool> attrubite;
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

        string erroPutExelPath;
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

        public DataTable LoadExcel()
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            FileStream fs;
            IWorkbook workbook = null;
            IWorkbook erroworkbook = null;
            int cellCount = 0;//列数
            int rowCount = 0;//行数
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
                List<string> DataHead = new List<string>();
                IRow firstRow = sheet.GetRow(0);
                cellCount = firstRow.LastCellNum;
                IRow erroHead = erroSheet.CreateRow(0);
                for (int i = 0; i < cellCount; i++)
                {
                    DataHead.Add(firstRow.GetCell(i).StringCellValue);
                    erroHead.CreateCell(i).SetCellValue(firstRow.GetCell(i).StringCellValue);

                    if (Attribute.ContainsKey(firstRow.GetCell(i).StringCellValue))
                    {
                        DataColumn column = new DataColumn(excelHeadLineDataColu[firstRow.GetCell(i).StringCellValue]);
                        data.Columns.Add(column);
                    }
                }
                foreach (KeyValuePair<string, bool> pair in Attribute)
                {
                    if (!DataHead.Contains(pair.Key) && pair.Value) throw new Exception($"缺少必须行{pair.Key}");
                }
                int count = 1;
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
                        if ((row.GetCell(j) == null && Attribute[DataHead[j]]))
                        {
                            erroSheet.CreateRow(count);
                            IRow erroRow = erroSheet.GetRow(count);
                            count++;
                            flag = true;
                            for (int k = row.FirstCellNum; k < cellCount; ++k)
                            {
                                if (row.GetCell(k) != null)
                                {
                                    erroRow.CreateCell(k).SetCellValue(row.GetCell(k).ToString());
                                }
                                else if(Attribute[DataHead[k]])
                                {
                                    erroRow.CreateCell(k).SetCellValue("缺少必填内容");
                                }
                            }
                            break;
                        }
                        if(Attribute.ContainsKey( firstRow.GetCell(j).StringCellValue))
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            {
                                dataRow[DataCellCount] = row.GetCell(j).ToString();
                                if (row.GetCell(j).CellType == CellType.Numeric)
                                {
                                    dataRow[DataCellCount] = Convert.ToDateTime(row.GetCell(j).DateCellValue).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    dataRow[DataCellCount] = row.GetCell(j).ToString();
                                }
                                string Out = MetarnetRegex.Checked(DataHead[j], row.GetCell(j).ToString());
                                if (Out != "Success")
                                {
                                    erroSheet.CreateRow(count);
                                    IRow erroRow = erroSheet.GetRow(count);
                                    count++;
                                    flag = true;
                                    for (int k = row.FirstCellNum; k < cellCount; ++k)
                                    {
                                        if(j == k)
                                        {
                                            erroRow.CreateCell(k).SetCellValue(Out);
                                        }
                                        else if (row.GetCell(k) != null)
                                        {
                                            erroRow.CreateCell(k).SetCellValue(row.GetCell(k).ToString());
                                        }
                                        else if (Attribute[DataHead[k]])
                                        {
                                            erroRow.CreateCell(k).SetCellValue("缺少必填内容");
                                        }
                                    }
                                    break;
                                }
                            }
                            DataCellCount++;
                        }
                    }
                    if(!flag)data.Rows.Add(dataRow);
                }
            }
            using (errofs)
            {
                erroworkbook.Write(errofs);//向打开的这个xls文件中写入数据  
            }
            return data;
        }

    }
}
