using DesafioFullStack.Entities;

namespace DesafioFullStack.Repository.Interfaces
{
    public interface ICompany
    {
        Task<List<Company>> GetAllCompanies();
        Task<Company> GetCompanyByCNPJ(string CNPJ);
        Task<Company> GetCompanyByTradeName(string name);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(Company company, string CNPJ);
        Task<bool> DeleteCompany(string CNPJ);
    }
}
