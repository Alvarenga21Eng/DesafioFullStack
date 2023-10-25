using DesafioFullStack.Data;
using DesafioFullStack.Entities;
using DesafioFullStack.Integration.Response;
using DesafioFullStack.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioFullStack.Repository
{
    
    public class SupplierRepository : ISupplier
    {
        private readonly SystemDBContext _dbContext;
        public SupplierRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            if (supplier.CnpjCpf.Length == 11)
            {
                if(supplier.RG == null || supplier.Birthday == null)
                {
                    throw new Exception("RG and Birthday must be informed correctly " +
                        "for registration of individual supplier.");
                }
                
            } 
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();

            return supplier;
        }

        public async Task<bool> DeleteSupplier(string cnpj)
        {
            Supplier supplierCnpj = await GetSupplierByCnpj(cnpj);

            if (supplierCnpj == null)
            {
                throw new Exception($"Supplier by CNPJ: {cnpj} not found in Database.");
            }

            _dbContext.Suppliers.Remove(supplierCnpj);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByCnpj(string cnpj)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.CnpjCpf == cnpj);
        }

        public async Task<Supplier> GetSupplierByName(string name)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier, string cnpj)
        {
            Supplier supplierCnpj = await GetSupplierByCnpj(cnpj);

            if (supplierCnpj == null) 
            {
                throw new Exception($"Supplier by CNPJ: {cnpj} not found in Database.");
            }

            supplierCnpj.CnpjCpf = supplier.CnpjCpf;
            supplierCnpj.Name = supplier.Name;
            supplierCnpj.Cep = supplier.Cep;
            supplierCnpj.Email = supplier.Email;
            supplierCnpj.RG = supplier.RG;
            supplierCnpj.Birthday = supplier.Birthday;

            _dbContext.Suppliers.Update(supplierCnpj);
            await _dbContext.SaveChangesAsync();

            return supplierCnpj;
        }
    }
}
