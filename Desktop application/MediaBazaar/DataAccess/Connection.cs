using MySql.Data.MySqlClient;

namespace MediaBazaar.DataAccess
{
    public static class Connection
    {
        private static MySqlConnection? connection;

        public static MySqlConnection Connect
        {
            get
            {
                if (connection == null)
                {
                    connection = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi486523;Database=dbi486523;Pwd=12345678;");
                    connection.Open();

                }
                return connection;
            }
        }

        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
            connection = null;
        }
    }
}