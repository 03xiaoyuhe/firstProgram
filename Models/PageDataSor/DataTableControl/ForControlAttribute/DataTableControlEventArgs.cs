using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PageDataSor.DataTableControl.ForControlAttribute
{
    public class DataTableControlEventArgs : EventArgs
    {
        public DataTableControlEventArgs() 
        { 

        }

        public DataTableControlEventArgs(params object[] args)
        {
            Args = new List<object>(args);
        }

        public int ArgsCount
        {
            get
            {
                return args.Count;
            }
        }

        List<object> args = new List<object>();
        /// <summary>
        /// 事件处理所需的必要参数
        /// </summary>
        public List<object> Args
        {
            get
            {
                return args;
            }
            set
            {
                args = value;
                Init_argsKinds();
            }
        }


        /// <summary>
        /// 解释存放参数
        /// </summary>
        Dictionary<object,string> argsKinds = new Dictionary<object,string>();

        void Init_argsKinds()
        {
            foreach(object arg in Args)
            {
                if(!argsKinds.ContainsKey(arg))
                {
                    argsKinds.Add(arg, arg.GetType().Name);
                }
            }
        }

        /// <summary>
        /// 将参数解释绑定到参数
        /// </summary>
        /// <param name="arg">参数</param>
        /// <param name="kind">参数类型解释</param>
        public void SetArgKinds(Object arg,string kind)
        {
            if (!argsKinds.ContainsKey(arg))
            {
                argsKinds.Add(arg, kind);
            }
            else
            {
                argsKinds[arg] = kind;
            }
        }


        /// <summary>
        /// 获取参数的解释
        /// </summary>
        /// <param name="arg">参数</param>
        /// <returns>参数的类型与解释</returns>
        public string GetArgKinds(Object arg)
        {
            if (!argsKinds.ContainsKey(arg))
            {
                return arg.GetType().Name;
            }
            else
            {
                return argsKinds[arg];
            }
        }

    }
}
