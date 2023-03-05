using Address.Application.Results;
using Address.Application.UseCases.Commands;

namespace Address.Application.UseCases.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<RequestResult> HandleAsync(T command);
    }
}