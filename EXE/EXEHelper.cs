using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE
{
    public class EXEHelper
    {
        /// <summary>
        /// exe文件绝对路径
        /// </summary>
        public string path;

        public string arguments;
        public string OperationReturn()
        {
            Process exe = new Process();
            exe.StartInfo.FileName = path;
            exe.StartInfo.Arguments = " "+arguments;
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
