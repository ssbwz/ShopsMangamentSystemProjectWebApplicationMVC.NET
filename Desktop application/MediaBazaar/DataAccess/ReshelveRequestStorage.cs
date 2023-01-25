using MySql.Data.MySqlClient;
using System.Data;
using MediaBazaar.Managers;
using MediaBazaar.Logic.Models;
using MediaBazaar.Logic.Enums;

namespace MediaBazaar.DataAccess
{
    public class ReshelveRequestStorage : IReshelveRequestStorage
    {
        private const int UNKNOWN_VALUE = -1;

        private MySqlConnection conn
        {
            get { return Connection.Connect; }
        }

        private EmployeeManager employeeManager
        {
            get
            {
                try
                {
                    return new EmployeeManager(conn);
                }
                catch (MySqlException)
                {
                    Connection.CloseConnection();
                    return null;
                }
            }

        }

        public ReshelveRequest GetReshelveRequestById(int reshelveRequestId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select * from `restock_requests` where id = @ID", conn);

                cmd.Parameters.AddWithValue("ID", reshelveRequestId);

                Employee creater = employeeManager.GetEmployeeById(getCreaterIdByReshleveRequestId(reshelveRequestId));
                Employee assignedTo = employeeManager.GetEmployeeById(getAssignedToIdByReshleveRequestId(reshelveRequestId));

                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                ReshelveRequest reshelveRequest = new ReshelveRequest(
                    reader.GetInt32("id"),
                    reader.GetDateTime("request_date"),
                    reader["arrival_date"] == DBNull.Value ? null : reader.GetDateTime("arrival_date"),
                    (TrackingStatus)Enum.Parse(typeof(TrackingStatus), reader.GetString("tracking_status")),
                    creater,
                    assignedTo
                    );

                reader.Close();
                return reshelveRequest;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return null;
            }
        }

        public DataTable GetSentReshelveRequests()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "Select id ID,request_date `Request Date`, arrival_date `Arrival Date`, tracking_status `Status`, " +
                    "request_creator_id `Creator ID`, assigned_user_id `Assigned to Id` " +
                    "from `restock_requests` WHERE tracking_status != 'Created' ", conn);

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

        public void UpdateStatusByReshelveRequestId(int reshelveRequestId, TrackingStatus trackingStatus)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Update `restock_requests`" +
                        "SET tracking_status=@TRACKINGSTATUS " +
                        "Where id = @REQUESTID",
                        conn);

                cmd.Parameters.AddWithValue("REQUESTID", reshelveRequestId);
                cmd.Parameters.AddWithValue("TRACKINGSTATUS", trackingStatus.ToString());

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return;
            }
        }

        public void CreateReshelveRequest(int creatorId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `restock_requests`" +
                    "(`request_date`, `tracking_status`, `request_creator_id`) " +
                    "VALUES (@REQUESTDATE,\"Created\",@REQUESTCREATORID)", conn);

                cmd.Parameters.AddWithValue("REQUESTDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("REQUESTCREATORID", creatorId);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return;
            }
        }

        public int? GetReshelveRequestIdByPersonIdIfStatusCreated(int employeeId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select id from `restock_requests` " +
                    "where request_creator_id = @REQUESTCREATORID AND tracking_status like \"Created\"", conn);

                cmd.Parameters.AddWithValue("REQUESTCREATORID", employeeId);

                return cmd.ExecuteScalar() == DBNull.Value ? null : Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return null;
            }
        }

        public DataTable GetReshelveRequests()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(
                    "Select id ID,request_date `Request Date`, arrival_date `Arrival Date`, tracking_status `Status`, " +
                    "request_creator_id `Creator ID`, assigned_user_id `Assigned to Id` " +
                    "from `restock_requests`", conn);

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

        public DataTable GetRequestItems(int id)
        {
            var adapter = new MySqlDataAdapter(
                "select p.id as 'ID', p.barcode as 'Barcode', p.brand as 'Brand', p.model as 'Model', rp.requested_quantity as 'Requested quantity' from request_products rp " +
                "join products p on rp.product_id = p.id " +
                "where rp.request_id = @ID " +
                "order by request_id;",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("ID", id);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public DataTable GetRequestDetails2(int id)
        {
            var adapter = new MySqlDataAdapter(
                "select rr.id, rr.request_date, concat(e.first_name, ' ', e.last_name) as full_name from restock_requests rr " +
                "join employees e on rr.request_creator_id = e.id " +
                "where rr.id = @ID;",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("ID", id);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void AssignEmployeeToRequest(int requestId, int userId)
        {
            var cmd = new MySqlCommand(
                "update restock_requests set assigned_user_id = @USER_ID where id = @REQUEST_ID",
                conn);
            cmd.Parameters.AddWithValue("USER_ID", userId);
            cmd.Parameters.AddWithValue("REQUEST_ID", requestId);

            cmd.ExecuteNonQuery();
        }

        public int getCreaterIdByReshleveRequestId(int reshelveRequestId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select request_creator_id from `restock_requests` where id = @ID", conn);

                cmd.Parameters.AddWithValue("ID", reshelveRequestId);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return UNKNOWN_VALUE;
            }
        }

        public int getAssignedToIdByReshleveRequestId(int reshelveRequestId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select assigned_user_id from `restock_requests` where id = @ID", conn);

                cmd.Parameters.AddWithValue("ID", reshelveRequestId);

                return cmd.ExecuteScalar() == DBNull.Value ? UNKNOWN_VALUE : Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return UNKNOWN_VALUE;
            }
        }
        public bool UpdateStatusInRestockRequest(int id, TrackingStatus trackingStatus)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE `restock_requests` SET `tracking_status` = @tracking_status " +
                    "WHERE `id` = @id "
                    , conn);

                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("tracking_status", trackingStatus.ToString());


                return cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return false;
            }
        }

        public void UpdateArrivalDate(int id, DateTime date)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE `restock_requests` SET `arrival_date` = @DATE " +
                    "WHERE `id` = @REQUESTID"
                    , conn);

                cmd.Parameters.AddWithValue("REQUESTID", id);
                cmd.Parameters.AddWithValue("DATE", date);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return;
            }
        }
    }
}
