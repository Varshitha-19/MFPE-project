using MedicineService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineService
{
    public interface IStoredMedicineRepository
    {
        Task<IEnumerable<StoredMedicine>> GetStoredMedicines();
        Task<StoredMedicine> GetStoredMedicineByID(int storedMedicine, int batchNo);
        Task<StoredMedicine> InsertStoredMedicine(StoredMedicine storedMedicine);
        Task<StoredMedicine> DeleteStoredMedicine(int storedMedicineId);
        Task<StoredMedicine> UpdateStoredMedicine(StoredMedicine storedMedicine);
    }
}
