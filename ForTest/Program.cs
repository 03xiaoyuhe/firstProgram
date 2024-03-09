using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace ForTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //DBHelper dbHelper = new DBHelper();
            DBHelper.Mode = 2;
            DBHelper.Setting();

            Console.WriteLine("Hello, World!");


            #region UserSighin
            /// UserLoginOn
            Console.WriteLine("\n\n----For UserSighin Test----");
            ForTest.ForUserSigin.ForAuthenticateUser();

            #endregion



            #region UserLoginOn
            /// UserLoginOn
            Console.WriteLine("\n\n----For UserLoginOn Test----");
            ForTest.ForUserLoginOn.ForCheckIfAccountExists();
            ForTest.ForUserLoginOn.ForRegisterUser();

            #endregion



        }
    }
}
