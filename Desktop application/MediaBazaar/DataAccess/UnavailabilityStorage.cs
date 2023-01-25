using Logic.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace MediaBazaar.DataAccess
{
    public class UnavailabilityStorage
    {
        public static string ENTER_AVAILABILITY = "INSERT INTO unavailability (user_id, reason, start_date, end_date) VALUES (@userId, @reason, @start_date, @end_date);";

        public static string GET_UNAVAILABILITY = "SELECT user_id, reason, start_date, end_date FROM `unavailability` WHERE user_id=@userId ORDER BY start_date ASC;";
        private MySqlConnection conn
        {
            get { return Connection.Connect; }
        }

        public DataTable ReadUnAvailability(int userId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(GET_UNAVAILABILITY, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                var adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return null;
            }
        }

        public DateTime? GetEarliestSickDate(int userId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT start_date FROM unavailability WHERE user_id = @USERID AND reason = 'Sick' AND end_date IS NULL ORDER BY start_date ASC LIMIT 1", conn);
                cmd.Parameters.AddWithValue("USERID", userId);

                if(cmd.ExecuteScalar() is not null)
                {
                    var startDate = Convert.ToDateTime(cmd.ExecuteScalar());
                    return startDate;
                }

            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }

            return null;
        }

        public bool CheckForSick(int userId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT count(*) FROM `unavailability` WHERE user_id = @USERID AND reason = 'Sick' AND end_date IS NULL;", conn);
                cmd.Parameters.AddWithValue("USERID", userId);

                var count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    return true;
                }

            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }

            return false;
        }

        public bool EnterUnAvailability(Unavailability unavailability)
        {
            try
            {
                //    @userId, @reason, @start_date, @end_date

                MySqlCommand cmd = new MySqlCommand(ENTER_AVAILABILITY, conn);
                cmd.Parameters.AddWithValue("@userId", unavailability.User_id);
                cmd.Parameters.AddWithValue("@start_date", unavailability.StartDate);
                cmd.Parameters.AddWithValue("@end_date", unavailability.EndDate);
                cmd.Parameters.AddWithValue("@reason", unavailability.Reason);


                int numCreatedRows = cmd.ExecuteNonQuery();

                if (numCreatedRows == 1)
                {
                    return true;
                }

            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }

            return false;
        }

        public bool SetEndDate(int userId, string endDate)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE unavailability SET end_date = @ENDDATE WHERE user_id = @USERID AND reason = 'Sick' AND end_date IS NULL AND start_date <= @ENDDATE", conn);
                cmd.Parameters.AddWithValue("USERID", userId);
                cmd.Parameters.AddWithValue("ENDDATE", endDate);

                int updatedRowsCount = cmd.ExecuteNonQuery();

                if (updatedRowsCount > 0)
                {
                    return true;
                }

            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }

            return false;
        }
    }
}
