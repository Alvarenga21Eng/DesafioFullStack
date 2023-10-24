using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioFullStack.Entities;
using DesafioFullStack.Repository.Interfaces;

namespace DesafioFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompany _companyRepository;

        public CompanyController(ICompany companyRepository)
        {
                _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            List<Company> companies = await _companyRepository.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("cnpj/{CNPJ}")]
        public async Task<ActionResult<Company>> GetCompanyByCNPJ(string CNPJ)
        {
            Company company = await _companyRepository.GetCompanyByCNPJ(CNPJ);
            return Ok(company);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<Company>> GetCompanyByTradeName(string name)
        {
            Company company = await _companyRepository.GetCompanyByCNPJ(name);
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany([FromBody] Company company)
        {
            Company companyRep = await _companyRepository.AddCompany(company);
            return Ok(companyRep);
        }

        [HttpPut("{CNPJ}")]
        public async Task<ActionResult<Company>> UpdateCompany([FromBody] Company company, string CNPJ)
        {

            Company companyRep = await _companyRepository.UpdateCompany(company, CNPJ);
            return Ok(companyRep);
        }

        [HttpDelete("{CNPJ}")]
        public async Task<ActionResult<Company>> DeleteCompany(string CNPJ)
        {

            bool deleted = await _companyRepository.DeleteCompany(CNPJ);
            return Ok(deleted);
        }
    }
}
