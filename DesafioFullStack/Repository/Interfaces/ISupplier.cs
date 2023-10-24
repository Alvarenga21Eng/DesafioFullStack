using DesafioFullStack.Entities;

namespace DesafioFullStack.Repository.Interfaces
{
    public interface ISupplier
    {
        Task<List<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierByCNPJ(string CNPJ);
        Task<Supplier> GetSupplierByName(string name);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier, string CNPJ);
        Task<bool> DeleteSupplier(string CNPJ);
    }
}

