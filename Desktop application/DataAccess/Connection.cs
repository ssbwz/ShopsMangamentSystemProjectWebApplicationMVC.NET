using MySql.Data.MySqlClient;

namespace DataAccess
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
                    connection = new MySqlConnection("Enter your server link");
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