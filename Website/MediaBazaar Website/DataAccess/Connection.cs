using MySql.Data.MySqlClient;

namespace MediaBazaar_Website.DataAccess
{
    public class Connection
    {
        private static MySqlConnection? conn;

        public static void Reconnect()
        {
            CloseConnection();
            conn = Connect;
        }

        public static MySqlConnection Connect
        {
            get
            {
                try
                {
                    if (conn == null)
                    {
                        conn = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi486523;Database=dbi486523;Pwd=12345678;");
                        conn.Open();
                    }
                    return conn;
                }
                catch (AggregateException) 
                {
                    return null;
                }
            }
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            conn = null;
        }
    }
}
