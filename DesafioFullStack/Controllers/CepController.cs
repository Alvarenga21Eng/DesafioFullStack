using DesafioFullStack.Integration.Interfaces;
using DesafioFullStack.Integration.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IApiCepIntegration _apiCepIntegration;
        public CepController(IApiCepIntegration apiCepIntegration)
        {
            _apiCepIntegration = apiCepIntegration;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<APICepResponse>> ListDataAddress(string cep)
        {
            var responseData = await _apiCepIntegration.GetDataApiCep(cep);
            if(responseData == null)
            {
                return BadRequest("CEP not found.");
            }

            return Ok(responseData);
        }
    }
}
