using DesafioFullStack.Data;
using DesafioFullStack.Entities;
using DesafioFullStack.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioFullStack.Repository
{
    
    public class CompanyRepository : ICompany
    {
        private readonly SystemDBContext _dbContext;
        public CompanyRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<Company> AddCompany(Company company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company;
        }

        public async Task<bool> DeleteCompany(string cnpj)
        {
            Company companyCnpj = await GetCompanyByCnpj(cnpj);

            if (companyCnpj == null)
            {
                throw new Exception($"Company by CNPJ: {cnpj} not found in Database.");
            }

            _dbContext.Companies.Remove(companyCnpj);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByCnpj(string cnpj)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }

        public async Task<Company> GetCompanyByTradeName(string name)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.TradeName == name);
        }

        public async Task<Company> UpdateCompany(Company company, string cnpj)
        {
            Company companyCnpj = await GetCompanyByCnpj(cnpj);

            if (companyCnpj == null) 
            {
                throw new Exception($"Company by CNPJ: {cnpj} not found in Database.");
            }

            companyCnpj.Cnpj = company.Cnpj;
            companyCnpj.TradeName = company.TradeName;
            companyCnpj.Cep = company.Cep;

            _dbContext.Companies.Update(companyCnpj);
            await _dbContext.SaveChangesAsync();

            return companyCnpj;
        }
    }
}
