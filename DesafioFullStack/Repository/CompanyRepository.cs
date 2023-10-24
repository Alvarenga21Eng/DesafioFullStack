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

        public async Task<bool> DeleteCompany(string CNPJ)
        {
            Company companyCNPJ = await GetCompanyByCNPJ(CNPJ);

            if (companyCNPJ == null)
            {
                throw new Exception($"Company by CNPJ: {CNPJ} not found in Database.");
            }

            _dbContext.Companies.Remove(companyCNPJ);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByCNPJ(string CNPJ)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.CNPJ == CNPJ);
        }

        public async Task<Company> GetCompanyByTradeName(string name)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.TradeName == name);
        }

        public async Task<Company> UpdateCompany(Company company, string CNPJ)
        {
            Company companyCNPJ = await GetCompanyByCNPJ(CNPJ);

            if (companyCNPJ == null) 
            {
                throw new Exception($"Company by CNPJ: {CNPJ} not found in Database.");
            }

            companyCNPJ.CNPJ = company.CNPJ;
            companyCNPJ.TradeName = company.TradeName;
            companyCNPJ.CEP = company.CEP;

            _dbContext.Companies.Update(companyCNPJ);
            await _dbContext.SaveChangesAsync();

            return companyCNPJ;
        }
    }
}
