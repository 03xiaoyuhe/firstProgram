using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    internal class DBHelper
    {
        /// <summary>
        /// 获取通过账号名密码连接数据库的字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        public static string GetSqlConnectionString()
        {
            //string appSettings = ConfigurationManager.AppSettings["SQpwdLoad"];
            //return appSettings.ToString();

            return ConfigurationManager.ConnectionStrings["SQpwdLoad"].ConnectionString;
        }

        /// <summary>
        /// 获取windows登录连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        /// <summary>
        /// 适合增删改操作，返回影响条数
        /// </summary>
        /// <param name="sql">增删改语句</param>
        /// <param name="parameters">字段</param>
        /// <returns>影响条数</returns>
        /// <exception cref="Exception"></exception>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetSqlConnectionString()))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = sql;
                        comm.Parameters.AddRange(parameters);
                        return comm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (conn != null && conn.State != ConnectionState.Closed)
                            conn.Close();
                    }

                }
            }
        }

        /// <summary>
        /// 查询操作，返回查询结果中的第一行第一列的值
        /// </summary>
        /// <param name="sql">增删改语句</param>
        /// <param name="parameters">字段</param>
        /// <returns>查询结果中的第一行第一列的值</returns>
        /// <exception cref="Exception"></exception>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetSqlConnectionString()))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    try
                    {
                        conn.Open();
                        comm.CommandText = sql;
                        comm.Parameters.AddRange(parameters);
                        return comm.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        if (conn != null && conn.State != ConnectionState.Closed)
                            conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Adapter调整，查询操作，返回DataTable
        /// </summary>
        /// <param name="sql">增删改语句</param>
        /// <param name="parameters">字段</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, GetSqlConnectionString()))
            {
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(parameters);
                adapter.Fill(dt);
                return dt;
            }
        }


        public static SqlDataReader ExecuteReader(string sqlText, params SqlParameter[] parameters)
        {
            //SqlDataReader要求，它读取数据的时候有，它独占它的SqlConnection对象，而且SqlConnection必须是Open状态
            SqlConnection conn = new SqlConnection(GetSqlConnectionString());//不要释放连接，因为后面还需要连接打开状态
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            //CommandBehavior.CloseConnection当SqlDataReader释放的时候，顺便把SqlConnection对象也释放掉
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                        command.Fill(ds, "ds");
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
            catch (Exception err)
            {

                return null;
            }
        }
    }
}
