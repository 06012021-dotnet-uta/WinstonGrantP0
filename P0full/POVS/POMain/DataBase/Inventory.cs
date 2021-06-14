using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase
{
    public partial class Inventory
    {
        public int? ProductId { get; set; }
        public int? LocationId { get; set; }
        public int? InventoryNumber { get; set; }
        public int InventoryId { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
