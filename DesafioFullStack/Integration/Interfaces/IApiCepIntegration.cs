using DesafioFullStack.Integration.Response;

namespace DesafioFullStack.Integration.Interfaces
{
    public interface IApiCepIntegration
    {
        Task<APICepResponse> GetDataApiCep(string cep);
    }
}
