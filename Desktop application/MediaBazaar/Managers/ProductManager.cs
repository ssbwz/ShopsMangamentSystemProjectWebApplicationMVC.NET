using System.Data;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MySql.Data.MySqlClient;

namespace MediaBazaar.Managers
{
    public class ProductManager
    {

        private MySqlConnection conn;

        public ProductManager(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public void AddProduct(Product product)
        {
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO products (brand,model,description,weight,height,width,depth,price,barcode,category ) VALUES (@Brand,@Model,@Description,@Weight,@Height,@Width,@Depth,@Price,@Barcode,@Category);",
                conn);

            cmd.Parameters.AddWithValue("Brand", product.Brand);
            cmd.Parameters.AddWithValue("Model", product.Model);
            cmd.Parameters.AddWithValue("Description", product.Description);
            cmd.Parameters.AddWithValue("Weight", product.Weight);
            cmd.Parameters.AddWithValue("Height", product.Height);
            cmd.Parameters.AddWithValue("Width", product.Width);
            cmd.Parameters.AddWithValue("Depth", product.Depth);
            cmd.Parameters.AddWithValue("Price", product.Price);
            cmd.Parameters.AddWithValue("Barcode", product.Barcode);
            cmd.Parameters.AddWithValue("Category", product.Category.ToString());

            cmd.ExecuteNonQuery();
        }

        public int GetProductsByCategory(string category)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(id) from products WHERE category = @CATEGORY;", conn);

            cmd.Parameters.AddWithValue("CATEGORY", category);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public string[] GetAllProductCategories()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT SUBSTRING(COLUMN_TYPE, 5) as 'Values' FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='dbi486523' AND TABLE_NAME='products' AND COLUMN_NAME='category'", conn);

            string categoryString = cmd.ExecuteScalar().ToString();
            string[] categories = categoryString.Replace('(', ' ').Replace(')', ' ').Trim().Split(',');
            for (int i = 0; i < categories.Count(); i++)
            {
                categories[i] = categories[i].Replace('\'', ' ').Trim();
            }
            return categories;
        }

        public DataTable GetAllProducts()
        {
            var adapter = new MySqlDataAdapter(
                "SELECT id as ID, brand as Brand, model as Model, description as Description, weight as `Weight in g`, height as `Height in cm`, width as `Width in cm`, depth as `Depth in cm`, price as Price, barcode as Barcode, category as Category FROM products",
                conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public Product? GetProductById(int id)
        {
            MySqlCommand cmd = new MySqlCommand(
                "SELECT * FROM products WHERE id=@Id",
                conn);

            cmd.Parameters.AddWithValue("Id", id);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            reader.Read();

            var product = new Product(
                reader.GetInt32("id"),
                reader.GetString("brand"),
                reader.GetString("model"),
                reader.GetString("description"),
                reader.GetInt32("weight"),
                reader.GetInt32("height"),
                reader.GetInt32("width"),
                reader.GetInt32("depth"),
                reader.GetDecimal("price"),
                reader.GetString("barcode"),
                (ProductCategory)Enum.Parse(typeof(ProductCategory), reader.GetString("category"))
                );

            reader.Close();

            return product;
        }

        public Product? GetProductByBarcode(int barcode)
        {

            MySqlCommand cmd = new MySqlCommand(
                "SELECT * FROM products WHERE barcode=@Barcode",
                conn);

            cmd.Parameters.AddWithValue("Barcode", barcode);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            reader.Read();

            var product = new Product(
                reader.GetInt32("id"),
                reader.GetString("brand"),
                reader.GetString("model"),
                reader.GetString("description"),
                reader.GetInt32("weight"),
                reader.GetInt32("height"),
                reader.GetInt32("width"),
                reader.GetInt32("depth"),
                reader.GetDecimal("price"),
                reader.GetString("barcode"),
                (ProductCategory)Enum.Parse(typeof(ProductCategory), reader.GetString("category"))
                );

            reader.Close();

            return product;
        }

        public void DeleteProduct(int id)
        {
            MySqlCommand cmd = new MySqlCommand(
                "DELETE FROM products WHERE id= @Id", 
                conn);
           
            cmd.Parameters.AddWithValue("@Id", id);

            cmd.ExecuteNonQuery();
        }

        public void EditProduct(Product product)
        {
            MySqlCommand cmd = new MySqlCommand(
                "UPDATE products SET brand = @Brand, model = @Model, description = @Description, weight = @Weight, height = @Height, width = @Width, depth = @Depth, price = @Price, barcode = @Barcode, category = @Category WHERE id=@Id;",
                conn);
            
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Brand", product.Brand);
            cmd.Parameters.AddWithValue("@Model", product.Model);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Height", product.Height);
            cmd.Parameters.AddWithValue("@Weight", product.Weight);
            cmd.Parameters.AddWithValue("@Width", product.Width);
            cmd.Parameters.AddWithValue("@Depth", product.Depth);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Barcode", product.Barcode);
            cmd.Parameters.AddWithValue("@Category", product.Category.ToString());

            cmd.ExecuteNonQuery();
        }
    }
}
