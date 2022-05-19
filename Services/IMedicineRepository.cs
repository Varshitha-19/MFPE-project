using MedicineService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineService
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetMedicines();
        Task<Medicine> GetMedicineByID(int medicine);
        Task<Medicine> InsertMedicine(Medicine medicine);
        Task<Medicine> DeleteMedicine(int medicineId);
        Task<Medicine> UpdateMedicine(Medicine medicine);
    }
}
