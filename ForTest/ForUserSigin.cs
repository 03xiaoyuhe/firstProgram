using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace ForTest
{
    public class ForUserSigin
    {
        public ForUserSigin() { }
        static public void ForAuthenticateUser()
        {
            UserLogin userLogin = new UserLogin();
            WorkerLogin workerLogin = new WorkerLogin();
            Console.WriteLine("\n--For AuthenticateUser() Test");
            Console.WriteLine("账户名:");
            workerLogin.username = Console.ReadLine();
            Console.WriteLine("密码:");
            workerLogin.password = Console.ReadLine();
            if (userLogin.AuthenticateUser(workerLogin.username, workerLogin.password)) Console.WriteLine("登陆成功");
            else Console.WriteLine("登陆失败");

        }
    }
}
