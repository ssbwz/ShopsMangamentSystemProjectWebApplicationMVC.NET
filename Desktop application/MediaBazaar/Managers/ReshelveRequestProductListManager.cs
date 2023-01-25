using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using System.Data;

namespace MediaBazaar.Managers
{
    public class ReshelveRequestProductListManager
    {
        private ReshelveRequestProductListStorage reshelveRequestProductListStorage = new ReshelveRequestProductListStorage();
        private ProductManager productManager = new ProductManager(Connection.Connect);

        public DataTable GetDataTableofProductListByReshelveRequestId(int reshelveRequestId)
        {
            return reshelveRequestProductListStorage.GetDataTableOfProductListByReshelveRequestId(reshelveRequestId);
        }
        public DataTable GetDataTableofProductListBrokenByReshelveRequestId(int reshelveRequestId)
        {
            return reshelveRequestProductListStorage.GetDataTableOfProductListBrokenByReshelveRequestId(reshelveRequestId);
        }

        public void ChangeQuantityOfProductInProductList(int reshelveRequestId, int productId, int newQuantity)
        {
            if (newQuantity == 0) 
            {
                reshelveRequestProductListStorage.DeleteProductInProductList(reshelveRequestId, productId);
                return;
            }
            if (reshelveRequestProductListStorage.ProductInList(reshelveRequestId,productId))
            {
                reshelveRequestProductListStorage.ChangeQuantityOfProductInProductList(reshelveRequestId, productId, newQuantity);
                return;
            }
            reshelveRequestProductListStorage.AddProductToList(reshelveRequestId, productId, newQuantity);
            return;
            
        }

        public DataTable GetDataTableForAddingProductsInReshelveRequest(int resheleveRequestId)
        {
            DataTable dbCreateReshelveRequest = productManager.GetAllProducts();

            //Deleting columns from the dataTable
            dbCreateReshelveRequest.Columns.Remove("Description");
            dbCreateReshelveRequest.Columns.Remove("Weight in g");
            dbCreateReshelveRequest.Columns.Remove("Height in cm");
            dbCreateReshelveRequest.Columns.Remove("Width in cm");
            dbCreateReshelveRequest.Columns.Remove("Depth in cm");
            dbCreateReshelveRequest.Columns.Remove("Price");
            dbCreateReshelveRequest.Columns.Remove("Category");

            //Adding a column from the dataTable
            dbCreateReshelveRequest.Columns.Add("Quantity");

            //Geting Quantity of product
            for (int i = 0; i < dbCreateReshelveRequest.Rows.Count; i++)
            {
                int? quantity = reshelveRequestProductListStorage.GetQuantityPerProductInReshelveRequestList(resheleveRequestId, Convert.ToInt32(dbCreateReshelveRequest.Rows[i]["ID"]));

                if (quantity == null)
                {
                    dbCreateReshelveRequest.Rows[i]["Quantity"] = string.Empty;
                }
                else
                {
                    dbCreateReshelveRequest.Rows[i]["Quantity"] = quantity;
                }
            }

            return dbCreateReshelveRequest;
        }

        public int GetTotalActualByCategory(string category)
        {
            return reshelveRequestProductListStorage.GetTotalActualByCategory(category);
        }

        public int GetTotalBrokenByCategory(string category)
        {
            return reshelveRequestProductListStorage.GetTotalBrokenByCategory(category);
        }

        public int GetTotalRequestedByCategory(string category)
        {
            return reshelveRequestProductListStorage.GetTotalRequestedByCategory(category);
        }

        public bool ChangeBrokenQuantityOfProductInProductList(int reshelveRequestId, int productId, int newQuantity)
        {
            if(newQuantity > reshelveRequestProductListStorage.GetActualQuantityPerProductInReshelveRequestList(reshelveRequestId, productId))
            {
                return false;
            }
            reshelveRequestProductListStorage.ChangeBrokenQuantityOfProductInProductList(reshelveRequestId, productId, newQuantity);
            return true;
        }

        public DataTable GetCreatedRestockRequestsById(int id)
        {
            return reshelveRequestProductListStorage.GetCreatedRestockRequests(id);
        }

        public DataTable GetRequestProducts(int request_id)
        {
            return reshelveRequestProductListStorage.GetAllRequestedProductById(request_id);
        }

        public bool SaveReshelvedProduct(int id,int req_id, int actual_quantity)
        {
            return reshelveRequestProductListStorage.UpdateActualQuantity(id, req_id, actual_quantity);
            
        }
    }
}
