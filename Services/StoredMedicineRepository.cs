using MedicineService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineService
{
    public class StoredMedicineRepository : IStoredMedicineRepository
    {

        public static readonly List<StoredMedicine> storedmedicines = new List<StoredMedicine>()
        {
            new StoredMedicine {BatchNo=101, VendorId=1, MedicineId=1, Quantity=20, DateOfEntry=Convert.ToDateTime("05/30/2022"), ManufactureDate=Convert.ToDateTime("06/01/2022"), ExpiryDate=Convert.ToDateTime("06/01/2025")},
            new StoredMedicine {BatchNo=101, VendorId=1, MedicineId=4, Quantity=30, DateOfEntry=Convert.ToDateTime("05/30/2022"), ManufactureDate=Convert.ToDateTime("06/01/2022"), ExpiryDate=Convert.ToDateTime("06/01/2025")},
            new StoredMedicine {BatchNo=102, VendorId=2, MedicineId=5, Quantity=50, DateOfEntry=Convert.ToDateTime("05/30/2022"), ManufactureDate=Convert.ToDateTime("06/01/2022"), ExpiryDate=Convert.ToDateTime("06/01/2025")},
        };

        public async Task<StoredMedicine> DeleteStoredMedicine(int storedMedicineId)
        {
            var storedMedicine = storedmedicines.SingleOrDefault(v => v.MedicineId == storedMedicineId);
            if (storedMedicine != null)
            {
                storedmedicines.Remove(storedMedicine);
            }
            return storedMedicine;
        }

        public async Task<StoredMedicine> GetStoredMedicineByID(int storedMedicine, int batchNo)
        {
            return storedmedicines.SingleOrDefault(v => v.MedicineId == storedMedicine && v.BatchNo == batchNo);
        }

        public async Task<IEnumerable<StoredMedicine>> GetStoredMedicines()
        {
            return storedmedicines;
        }

        public async Task<StoredMedicine> InsertStoredMedicine(StoredMedicine storedMedicine)
        {
            storedmedicines.Add(storedMedicine);
            return storedMedicine;
        }

        public async Task<StoredMedicine> UpdateStoredMedicine(StoredMedicine storedMedicine)
        {
            var storedMed = storedmedicines.SingleOrDefault(m => m.MedicineId == storedMedicine.MedicineId && m.BatchNo == storedMedicine.BatchNo);

            if (storedMed != null)
            {
                storedMed.BatchNo = storedMedicine.BatchNo;
                storedMed.VendorId = storedMedicine.VendorId;
                storedMed.DateOfEntry = storedMedicine.DateOfEntry;
                storedMed.MedicineId = storedMedicine.MedicineId;
                storedMed.Quantity = storedMedicine.Quantity;
                storedMed.ManufactureDate = storedMedicine.ManufactureDate;
                storedMed.ExpiryDate = storedMedicine.ExpiryDate;

                return storedMed;
            }

            return null;
        }
    }
}



