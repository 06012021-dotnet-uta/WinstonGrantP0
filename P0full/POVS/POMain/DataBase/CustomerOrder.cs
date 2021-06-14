using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase
{
    public partial class CustomerOrder
    {
        public CustomerOrder()
        {
            OrderedProducts = new HashSet<OrderedProduct>();
        }

        public int CustomerOrderId { get; set; }
        public DateTime? CustomerOrdertime { get; set; }
        public int? CustomerId { get; set; }
        public int? LocationId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreLocation Location { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}
