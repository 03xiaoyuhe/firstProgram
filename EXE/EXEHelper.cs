using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EXE
{
    public class EXEHelper
    {
        /// <summary>
        /// EXE文件的绝对路径
        /// </summary>
        public string path;
        public string Arguments;
        /// <summary>
        /// 运行程序并返回运行结果
        /// </summary>
        /// <returns>EXE文件返回(字符串)</returns>
        public string OperationReturn()
        {
            Process exe = new Process();
            exe.StartInfo.FileName = path;
            exe.StartInfo.Arguments = " " + Arguments;
            exe.StartInfo.UseShellExecute = false;
            exe.StartInfo.RedirectStandardOutput = true;
            exe.StartInfo.RedirectStandardInput = true;
            exe.StartInfo.CreateNoWindow = true;
            exe.Start();
            exe.WaitForExit();
            string data = exe.StandardOutput.ReadToEnd();
            return data;
        }
    }
}
