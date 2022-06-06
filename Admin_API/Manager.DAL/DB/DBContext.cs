

using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Manager.DAL.DB
{
    public class DBContext
    {

        private readonly static string ConnectionString = "Server=180.76.107.142;DataBase=manager;uid=manager;pwd=159357ljn...;Connect TimeOut=3";
        public static string ErrMsg { get; set; } = string.Empty;

        private static IDbConnection _conn = null;

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        private static void Connection()
        {
            if (_conn.State != ConnectionState.Open)
            {
                //_conn.Query
                _conn.Open();
            }
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        private static void Close()
        {
            if (_conn.State != ConnectionState.Closed)
            {

                _conn.Close();
            }
        }

        /// <summary>
        /// 执行查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Excute(string sql)
        {
            try
            {
                using (_conn = new SqlConnection(ConnectionString))
                {
                    return _conn.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// 单条查询
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static dynamic QuerySingle(string sqlString)
        {
            try
            {
                using (_conn = new SqlConnection(ConnectionString))
                {
                    return _conn.QueryFirst(sqlString);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 执行查询返回DataSet
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static List<dynamic> Query(string sqlString)
        {
            try
            {
                using (_conn = new SqlConnection(ConnectionString))
                {
                    return _conn.Query(sqlString).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static T ExecuteScalar<T>(string sqlString)
        {
            using (_conn = new SqlConnection(ConnectionString))
            {

                return _conn.ExecuteScalar<T>(sqlString);
            }
        }

        /// <summary>
        /// 执行查询返回DataSet
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static List<T> Query<T>(string sqlString)
        {
            try
            {
                using (_conn = new SqlConnection(ConnectionString))
                {

                    return _conn.Query<T>(sqlString).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
