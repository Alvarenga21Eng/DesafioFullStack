using DesafioFullStack.Integration.Response;
using Refit;

namespace DesafioFullStack.Integration.Refit
{
    public interface IApiCepIntegrationRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<ApiResponse<APICepResponse>> GetDataApiCep(string cep);
    }
}
