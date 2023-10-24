using DesafioFullStack.Integration.Response;
using Refit;

namespace DesafioFullStack.Integration.Refit
{
    public interface IApiCepIntegrationRefit
    {
        [Get("/consulta/cep/{cep}")]
        Task<ApiResponse<APICepResponse>> GetDataApiCep(string cep);
    }
}
