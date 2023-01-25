using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using MediaBazaar.Logic.Enums;

namespace MediaBazaar.DataAccess
{
    public class ReshelveRequestProductListStorage : IReshelveRequestProductListStorage
    {

        private MySqlConnection conn
        {
            get { return Connection.Connect; }
        }

        public DataTable GetDataTableOfProductListByReshelveRequestId(int reshelveRequestId)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `id` as ID, `brand` as Brand, `model` as Model,`barcode` as Barcode, `requested_quantity` as Quantity " +
                    "FROM `products` p INNER JOIN request_products rp ON rp.product_id = p.id " +
                    " where request_id = @REQUESTID"
                    , conn);

                adapter.SelectCommand.Parameters.AddWithValue("REQUESTID", reshelveRequestId);

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

        public DataTable GetDataTableOfProductListBrokenByReshelveRequestId(int reshelveRequestId)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `id` as ID, `brand` as Brand, `model` as Model,`barcode` as Barcode, `requested_quantity` as 'Requested quantity', `actual_quantity` as 'Delivered quantity', `broken_quantity` as 'Broken quantity' " +
                    "FROM `products` p INNER JOIN request_products rp ON rp.product_id = p.id " +
                    " where request_id = @REQUESTID"
                    , conn);

                adapter.SelectCommand.Parameters.AddWithValue("REQUESTID", reshelveRequestId);

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

        public void DeleteProductInProductList(int reshelveRequestId, int productId)
        {
            try {

                MySqlCommand cmd = new MySqlCommand(
                       "DELETE FROM `request_products` " +
                       "where `product_id` = @PRODUCTID AND `request_id` = @REQUESTID "
                       , conn);

                cmd.Parameters.AddWithValue("PRODUCTID", productId);
                cmd.Parameters.AddWithValue("REQUESTID", reshelveRequestId);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return;
            }
        }

        public void AddProductToList(int reshelveRequestId, int productId, int newQuantity)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "INSERT INTO `request_products`(`request_id`, `product_id`, `requested_quantity`)" +
                    " VALUES(@RESHELVEREQUESTID,@PRODUCTID,@NEWQUANTITY)"
                    , conn);

                cmd.Parameters.AddWithValue("PRODUCTID", productId);
                cmd.Parameters.AddWithValue("RESHELVEREQUESTID", reshelveRequestId);
                cmd.Parameters.AddWithValue("NEWQUANTITY", newQuantity);

                cmd.ExecuteNonQuery();

            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return;
            }
        }

        public int GetTotalActualByCategory(string category)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(actual_quantity) FROM request_products AS r INNER JOIN products AS p ON r.product_id = p.id " +
                "INNER JOIN restock_requests as rr ON r.request_id = rr.id WHERE p.category = @CATEGORY AND rr.tracking_status = 'Delivered'", conn);

            cmd.Parameters.AddWithValue("CATEGORY", category);

            if (cmd.ExecuteScalar() is DBNull)
            {
                return 0;
            }
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetTotalBrokenByCategory(string category)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(broken_quantity) FROM request_products AS r INNER JOIN products AS p ON r.product_id = p.id " +
                "INNER JOIN restock_requests as rr ON r.request_id = rr.id WHERE p.category = @CATEGORY AND rr.tracking_status = 'Delivered'", conn);

            cmd.Parameters.AddWithValue("CATEGORY", category);

            if (cmd.ExecuteScalar() is DBNull)
            {
                return 0;
            }
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetTotalRequestedByCategory(string category)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(requested_quantity) FROM request_products AS r INNER JOIN products AS p ON r.product_id = p.id " +
                "INNER JOIN restock_requests as rr ON r.request_id = rr.id WHERE p.category = @CATEGORY AND rr.tracking_status = 'Delivered'", conn);

            cmd.Parameters.AddWithValue("CATEGORY", category);

            if(cmd.ExecuteScalar() is DBNull)
            {
                return 0;
            }
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int GetActualQuantityPerProductInReshelveRequestList(int reshelveRequestId, int productId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "Select  actual_quantity " +
                    "from `request_products` " +
                    "where product_id = @PRODUCTID AND request_id = @REQUESTID"
                    , conn);

                cmd.Parameters.AddWithValue("PRODUCTID", productId);
                cmd.Parameters.AddWithValue("REQUESTID", reshelveRequestId);

                return cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return 0;
            }
        }

        public void ChangeBrokenQuantityOfProductInProductList(int reshelveRequestId, int productId, int newQuantity)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE `request_products` SET `broken_quantity` = @NEWQUANTITY " +
                    "WHERE `request_id` = @REQUESTID AND `product_id` = @PRODUCTID"
                    , conn);

                cmd.Parameters.AddWithValue("NEWQUANTITY", newQuantity);
                cmd.Parameters.AddWithValue("REQUESTID", reshelveRequestId);
                cmd.Parameters.AddWithValue("PRODUCTID", productId);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return;
            }
        }

        public bool ProductInList(int reshelveRequestId, int productId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                        "Select  COUNT(product_id) " +
                        "from `request_products` " +
                        "where product_id = @PRODUCTID AND request_id = @REQUESTID"
                        , conn);

                cmd.Parameters.AddWithValue("PRODUCTID", productId);
                cmd.Parameters.AddWithValue("REQUESTID", reshelveRequestId);

                return Convert.ToInt32(cmd.ExecuteScalar()) == 1 ? true : false;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return false;
            }
        }

        public bool ChangeQuantityOfProductInProductList(int reshelveRequestId, int productId, int newQuantity)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE `request_products` SET `requested_quantity` = @NEWQUANTITY " +
                    "WHERE `request_id` = @REQUESTID AND `product_id` = @PRODUCTID"
                    , conn);

                cmd.Parameters.AddWithValue("NEWQUANTITY", newQuantity);
                cmd.Parameters.AddWithValue("REQUESTID", reshelveRequestId);
                cmd.Parameters.AddWithValue("PRODUCTID", productId);

                return cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return false;
            }
        }

        public int? GetQuantityPerProductInReshelveRequestList(int resheleveRequestId, int productId)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(
                    "Select  requested_quantity " +
                    "from `request_products` " +
                    "where product_id = @PRODUCTID AND request_id = @REQUESTID"
                    , conn);

                cmd.Parameters.AddWithValue("PRODUCTID", productId);
                cmd.Parameters.AddWithValue("REQUESTID", resheleveRequestId);

                return cmd.ExecuteScalar() == DBNull.Value ? 0 : Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return null;
            }
        }

        public DataTable GetCreatedRestockRequests(int id)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `id`, `tracking_status`FROM `restock_requests` where id=@id and tracking_status != @tracking_status", conn);

                adapter.SelectCommand.Parameters.AddWithValue("id", id);
                adapter.SelectCommand.Parameters.AddWithValue("tracking_status", "Delivered");
             
                var dt = new DataTable();

                adapter.Fill(dt);
                return dt;
            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                conn.Close();
            }

            return null;
        }
        
        public DataTable GetAllRequestedProductById(int requestId)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT `id` as 'ID', `brand` as 'Brand', `model` as 'Model',`barcode` as 'Barcode', `requested_quantity` as 'Requested quantity', `actual_quantity` as 'Actual quantity'" +
                    "FROM `products` as p INNER JOIN request_products ON request_products.product_id = p.id " +
                    " where request_id = @ID", conn);

                adapter.SelectCommand.Parameters.AddWithValue("ID", requestId);


                var dt = new DataTable();
                
                
                adapter.Fill(dt);
                return dt;

            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                conn.Close();
            }
            
            return null;
        }

        public bool UpdateActualQuantity(int id,int req_id, int actualQuantity)
        {

            try
            {
             
                MySqlCommand mySqlCommand = new MySqlCommand("UPDATE request_products SET actual_quantity = @actual_quantity where product_id = @product_id and request_id = @request_id", conn);

                mySqlCommand.Parameters.AddWithValue("@product_id", id);
                mySqlCommand.Parameters.AddWithValue("@request_id", req_id);
                mySqlCommand.Parameters.AddWithValue("@actual_quantity", actualQuantity);
                return mySqlCommand.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (MySqlException)
            {
                Connection.CloseConnection();
                return false;
            }
        }
    }
}