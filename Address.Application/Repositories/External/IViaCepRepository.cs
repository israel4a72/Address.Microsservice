using Address.Application.Results;

namespace Address.Application.Repositories.External
{
    public interface IViaCepRepository
    {
        Task<RequestResult> GetCep(string cep);
    }
}