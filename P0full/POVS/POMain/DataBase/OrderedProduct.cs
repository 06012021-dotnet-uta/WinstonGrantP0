using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase
{
    public partial class OrderedProduct
    {
        public int? ProductId { get; set; }
        public int CustomerOrderId { get; set; }
        public int? CustomerId { get; set; }
        public int QuantityOfItems { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerOrder CustomerOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
