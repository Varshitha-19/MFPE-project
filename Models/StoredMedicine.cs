using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineService.Models
{
    public partial class StoredMedicine
    {
        public int BatchNo { get; set; }
        public int MedicineId { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int VendorId { get; set; }

        public virtual Medicine Medicine { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
