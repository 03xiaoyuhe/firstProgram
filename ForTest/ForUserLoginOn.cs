using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace ForTest
{
    public class ForUserLoginOn
    {

        static public void ForCheckIfAccountExists()
        {
            UserRegistration userRegistration = new UserRegistration();
            Console.WriteLine("\n--For CheckIfAccountExists() test");
            Console.WriteLine("需要查询的账户:");
            string UID = Console.ReadLine();
            if(userRegistration.CheckIfAccountExists(UID)) { Console.WriteLine("账户已存在");}
            else { Console.WriteLine("账户不存在");}

        }
        static public void ForRegisterUser()
        {
            Console.WriteLine("\n--For RegisterUser() test");
            WorkerLogin worker = new WorkerLogin();
            Console.WriteLine("账号:");
            worker.username =  Console.ReadLine();
            Console.WriteLine("密码:");
            worker.password = Console.ReadLine();
            Console.WriteLine("联系电话:");
            worker.phoneNumber = Console.ReadLine();
            UserRegistration userRegistration = new UserRegistration();
            if (userRegistration.RegisterUser(worker.username, worker.password, worker.phoneNumber))
            {
                Console.WriteLine("插入成功");
            }
            else Console.WriteLine("插入失败");
        }
    }
}
