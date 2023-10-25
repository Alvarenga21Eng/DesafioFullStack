using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioFullStack.Entities;
using DesafioFullStack.Repository.Interfaces;

namespace DesafioFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SupplierController : ControllerBase
    {
        private readonly ISupplier _supplierRepository;

        public SupplierController(ISupplier supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAllSuppliers()
        {
            List<Supplier> suppliers = await _supplierRepository.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("cnpj/{CNPJ}")]
        public async Task<ActionResult<Supplier>> GetSupplierByCnpj(string cnpj)
        {
            Supplier supplier = await _supplierRepository.GetSupplierByCnpj(cnpj);
            return Ok(supplier);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Supplier>> GetSupplierByName(string name)
        {
            Supplier supplier = await _supplierRepository.GetSupplierByCnpj(name);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> AddSupplier([FromBody] Supplier supplier)
        {
            Supplier supplierRep = await _supplierRepository.AddSupplier(supplier);
            return Ok(supplierRep);
        }

        [HttpPut("{CNPJ}")]
        public async Task<ActionResult<Supplier>> UpdateSupplier([FromBody] Supplier supplier, string cnpj)
        {

            Supplier supplierRep = await _supplierRepository.UpdateSupplier(supplier, cnpj);
            return Ok(supplierRep);
        }

        [HttpDelete("{CNPJ}")]
        public async Task<ActionResult<Supplier>> DeleteSupplier(string cnpj)
        {

            bool deleted = await _supplierRepository.DeleteSupplier(cnpj);
            return Ok(deleted);
        }
    }
}
