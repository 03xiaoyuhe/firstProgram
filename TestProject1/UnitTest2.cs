using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace TestProject1
{
    public class UnitTest2
    {
        public static bool Insert(string account, string psd, string number)
        {
            string query = "insert into UserControl (control_account,control_pswcontrol_number) values (@account,@psd,@number)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@account", SqlDbType.NVarChar) { Value = account });
            parameters.Add(new SqlParameter("@psd", SqlDbType.NVarChar) { Value = psd });
            parameters.Add(new SqlParameter("@number", SqlDbType.NVarChar) { Value = number });

            int rowAfforts = DBHelper.ExecuteSql(query, parameters);

            return rowAfforts > 0;

        }

        //[Test("12345", "000", "12312312312")]
        [TestMethod]
        static void TestMethod()
        {

        }
    }
}
