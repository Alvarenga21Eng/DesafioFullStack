using DesafioFullStack.Entities;

namespace DesafioFullStack.Repository.Interfaces
{
    public interface ISupplier
    {
        Task<List<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierByCnpj(string cnpj);
        Task<Supplier> GetSupplierByName(string name);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier, string cnpj);
        Task<bool> DeleteSupplier(string cnpj);
    }
}

