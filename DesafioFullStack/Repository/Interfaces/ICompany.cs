using DesafioFullStack.Entities;

namespace DesafioFullStack.Repository.Interfaces
{
    public interface ICompany
    {
        Task<List<Company>> GetAllCompanies();
        Task<Company> GetCompanyByCnpj(string cnpj);
        Task<Company> GetCompanyByTradeName(string name);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company, string cnpj);
        Task<bool> DeleteCompany(string cnpj);
    }
}
