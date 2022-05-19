using MedicineService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineService.Services
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetVendors();
        Task<Vendor> GetVendorByID(int vendor);
        Task<Vendor> InsertVendor(Vendor vendor);
        Task<Vendor> DeleteVendor(int vendorId);
        Task<Vendor> UpdateVendor(Vendor vendor);
    }
}
