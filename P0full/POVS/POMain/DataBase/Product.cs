using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderedProducts = new HashSet<OrderedProduct>();
        }

        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductName { get; set; }
        public int? ProductCount { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
    }
}
