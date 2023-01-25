using MediaBazaar.Logic.Enums;

namespace MediaBazaar.Logic.Models
{
    public class Product
    {
        public int? Id { get; set; } 

        public string Brand { get; set;}

        public string Model { get; set;}

        public string Description { get; set;}

        public int Weight { get; set;}

        public int Width { get; set;}

        public int Height { get; set;}

        public int Depth { get; set;}

        public decimal Price { get; set;}

        public string Barcode { get; set;}

        public ProductCategory Category { get; set;}

        public Product(int? ProductId,string brand, string model, string description,int weight, int width, int height, int depth, decimal sellingprice, string barcode, ProductCategory category)
        {
            this.Id = ProductId;
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.Weight = weight;
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.Price = sellingprice;
            this.Barcode = barcode;
            this.Category = category;
        }

    }
}
