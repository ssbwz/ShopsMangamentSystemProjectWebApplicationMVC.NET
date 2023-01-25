using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Logic.Models
{
    public class RequestProduct
    {

        public RequestProduct(int requstedId, int productId, int requestedQuantity, int actualQuantity, int brokenQuantity)
        {
            this.RequstedId = requstedId;
            this.ProductId = productId;
            this.RequestedQuantity = requestedQuantity;
            this.ActualQuantity = actualQuantity;
            this.BrokenQuantity = brokenQuantity;
        }

         


        public int RequstedId { get; }

        public int ProductId { get; }

        public int RequestedQuantity { get; set; }

        public int ActualQuantity { get; set; }

        public int BrokenQuantity { get; set; }
    }
}
