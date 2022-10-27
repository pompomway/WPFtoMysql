using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dbutils
{
    class DBUtil
    {
        private readonly string server = "localhost";
        private readonly string user = "root";
        private readonly string pw = "123456";
        private readonly string db = "dbconnection";

        private DBUtil() { }
        public static DBUtil getUtils()
        {
            return new DBUtil();
        }

        private MySqlConnection conn = null;
        public MySqlConnection getConnection()
        {
            conn = new MySqlConnection("server=" + server + ";User ID=" + user + ";Password=" + pw + ";initial Catalog=" + db);
            conn.Open();
            return conn;
        }

        public void close(MySqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        public void close(MySqlDataReader rs)
        {
            if (rs != null)
            {
                rs.Close();
            }
        }
    }
}
