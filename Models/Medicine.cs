using System;
using System.Collections.Generic;

#nullable disable

namespace MedicineService.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            StoredMedicines = new HashSet<StoredMedicine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public bool RequiresPrescription { get; set; }
        public string Category { get; set; }
        public int NoInPacket { get; set; }
        public double Price { get; set; }

        public virtual ICollection<StoredMedicine> StoredMedicines { get; set; }
    }
}
