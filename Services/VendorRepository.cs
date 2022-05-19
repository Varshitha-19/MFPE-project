using MedicineService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineService.Services
{
    public class VendorRepository : IVendorRepository
    {
        public static readonly List<Vendor> vendors = new List<Vendor>()
        {
            new Vendor {Id=1, Name="Johnson&Johnson", EmailId="johnson@gmail.com", MobileNo=7894561230, Address="Wall Street, USA", City="New York"},
            new Vendor {Id=2, Name="Emcure Pharma", EmailId="emcure@gmail.com", MobileNo=9876543211, Address="Pune, India", City="Pune"},
        };

        public async Task<Vendor> DeleteVendor(int vendorId)
        {
            var vendor = vendors.SingleOrDefault(v => v.Id == vendorId);
            if (vendor != null)
            {
                vendors.Remove(vendor);
            }
            return vendor;
        }

        public async Task<Vendor> GetVendorByID(int vendor)
        {
            return vendors.SingleOrDefault(v => v.Id == vendor);
        }

        public async Task<IEnumerable<Vendor>> GetVendors()
        {
            return vendors;
        }

        public async Task<Vendor> InsertVendor(Vendor vendor)
        {
            vendors.Add(vendor);
            return vendor;
        }

        public async Task<Vendor> UpdateVendor(Vendor vendor)
        {
            var ven = vendors.SingleOrDefault(m => m.Id == vendor.Id);

            if (ven != null)
            {
                ven.Name = vendor.Name;
                ven.EmailId = vendor.EmailId;
                ven.MobileNo = vendor.MobileNo;
                ven.Address = vendor.Address;
                ven.City = vendor.City;

                return ven;
            }

            return null;
        }
    }
}
