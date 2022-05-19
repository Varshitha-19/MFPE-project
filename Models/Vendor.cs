using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineService.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            StoredMedicines = new HashSet<StoredMedicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long MobileNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public virtual ICollection<StoredMedicine> StoredMedicines { get; set; }
    }
}
