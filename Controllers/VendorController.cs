using MedicineService.Models;
using MedicineService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorRepository _vendorrepository;

        public VendorController(IVendorRepository vendorRepository)
        {
            _vendorrepository = vendorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var vendors = _vendorrepository.GetVendors();
            return new OkObjectResult(vendors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var vendor = _vendorrepository.GetVendorByID(id);
            return new OkObjectResult(vendor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Vendor vendor)
        {
            using (var scope = new TransactionScope())
            {
                _vendorrepository.InsertVendor(vendor);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = vendor.Id }, vendor);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Vendor vendor)
        {
            if (vendor != null)
            {
                using (var scope = new TransactionScope())
                {
                    _vendorrepository.UpdateVendor(vendor);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _vendorrepository.DeleteVendor(id);
            return new OkResult();
        }
    }
}
