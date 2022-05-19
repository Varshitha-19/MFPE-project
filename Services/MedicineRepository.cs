using MedicineService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineService
{
    public class MedicineRepository : IMedicineRepository
    {
        public static readonly List<Medicine> medicines = new List<Medicine>()
        {
            new Medicine {Id=1, Name="Calpol-650mg",ScientificName="Paracetamol",Category="Fever", NoInPacket=15, Price=25, RequiresPrescription=false},
            new Medicine {Id=2, Name="Dolo-650mg", ScientificName="Paracetamol",Category="Fever", NoInPacket=15, Price=30, RequiresPrescription=false},
            new Medicine {Id=4, Name="Cetcip 10mg Tablet ", ScientificName="Cetirizine 10 mg  ",Category="Allergy", NoInPacket=10, Price=15, RequiresPrescription=true},
            new Medicine {Id=5, Name="COFSILS COUGH Syrup 100ml", ScientificName="AMMONIUM CHLORIDE 138 mg+DIPHENHYDRAMINE 14.08 mg+SODIUM CITRATE 57.03 mg",Category="Cough and cold", NoInPacket=1, Price=72, RequiresPrescription=false}
        };

        public async Task<Medicine> DeleteMedicine(int medicineId)
        {
            var medicine = medicines.SingleOrDefault(m => m.Id == medicineId);
            if(medicine != null)
            {
                medicines.Remove(medicine);
            }
            return medicine;
        }

        public async Task<Medicine> GetMedicineByID(int medicineId)
        {
            return medicines.SingleOrDefault(m => m.Id == medicineId);
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return medicines;
        }

        public async Task<Medicine> InsertMedicine(Medicine medicine)
        {
            medicines.Add(medicine);
            return medicine;
        }


        public async Task<Medicine> UpdateMedicine(Medicine medicine)
        {
            var med = medicines.SingleOrDefault(m => m.Id == medicine.Id);

            if(med != null)
            {
                med.Name = medicine.Name;  
                med.ScientificName = medicine.ScientificName;
                med.Category = medicine.Category;
                med.NoInPacket = medicine.NoInPacket;
                med.Price = medicine.Price;

                return med;
            }

            return null;
        }

    }
}
