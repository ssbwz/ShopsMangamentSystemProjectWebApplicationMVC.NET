using MediaBazaar.Logic.Enums;
using System.Data;

namespace MediaBazaar.DataAccess
{
    public interface IReshelveRequestProductListStorage
    {
        public DataTable GetDataTableOfProductListByReshelveRequestId(int reshelveRequestId);

        public DataTable GetDataTableOfProductListBrokenByReshelveRequestId(int reshelveRequestId);

        public void DeleteProductInProductList(int reshelveRequestId, int productId);

        public void AddProductToList(int reshelveRequestId, int productId, int newQuantity);

        public int GetActualQuantityPerProductInReshelveRequestList(int reshelveRequestId, int productId);

        public void ChangeBrokenQuantityOfProductInProductList(int reshelveRequestId, int productId, int newQuantity);

        public bool ProductInList(int reshelveRequestId, int productId);

        public bool ChangeQuantityOfProductInProductList(int reshelveRequestId, int productId, int newQuantity);

        public int? GetQuantityPerProductInReshelveRequestList(int resheleveRequestId, int productId);

        public DataTable GetCreatedRestockRequests(int id);

        public DataTable GetAllRequestedProductById(int requestId);

        public bool UpdateActualQuantity(int id, int req_id, int actualQuantity);
    }
}