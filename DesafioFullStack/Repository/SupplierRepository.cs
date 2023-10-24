using DesafioFullStack.Data;
using DesafioFullStack.Entities;
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
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();

            return supplier;
        }

        public async Task<bool> DeleteSupplier(string CNPJ)
        {
            Supplier supplierCNPJ = await GetSupplierByCNPJ(CNPJ);

            if (supplierCNPJ == null)
            {
                throw new Exception($"Supplier by CNPJ: {CNPJ} not found in Database.");
            }

            _dbContext.Suppliers.Remove(supplierCNPJ);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByCNPJ(string CNPJ)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.CNPJ == CNPJ);
        }

        public async Task<Supplier> GetSupplierByName(string name)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier, string CNPJ)
        {
            Supplier supplierCNPJ = await GetSupplierByCNPJ(CNPJ);

            if (supplierCNPJ == null) 
            {
                throw new Exception($"Supplier by CNPJ: {CNPJ} not found in Database.");
            }

            supplierCNPJ.CNPJ = supplier.CNPJ;
            supplierCNPJ.Name = supplier.Name;
            supplierCNPJ.CEP = supplier.CEP;
            supplierCNPJ.Email = supplier.Email;
            supplierCNPJ.RG = supplier.RG;
            supplierCNPJ.Birthday = supplier.Birthday;

            _dbContext.Suppliers.Update(supplierCNPJ);
            await _dbContext.SaveChangesAsync();

            return supplierCNPJ;
        }
    }
}
