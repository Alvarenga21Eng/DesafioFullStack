using DesafioFullStack.Integration.Interfaces;
using DesafioFullStack.Integration.Refit;
using DesafioFullStack.Integration.Response;

namespace DesafioFullStack.Integration
{
    public class ApiCepIntegration : IApiCepIntegration
    {
        private readonly IApiCepIntegrationRefit _apiCepIntegrationRefit;
        public ApiCepIntegration(IApiCepIntegrationRefit apiCepIntegrationRefit)
        {
            _apiCepIntegrationRefit = apiCepIntegrationRefit;
        }
        public async Task<APICepResponse> GetDataApiCep(string cep)
        {
            var responseData = await _apiCepIntegrationRefit.GetDataApiCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
