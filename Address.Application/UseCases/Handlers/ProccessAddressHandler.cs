using System.Net;
using Address.Application.DTOs;
using Address.Application.Repositories.External;
using Address.Application.Results;
using Address.Application.UseCases.Commands;
using Address.Application.UseCases.Tools;

namespace Address.Application.UseCases.Handlers
{
    public class ProccessAddressHandler : IHandler<ProccessAddressCommand>
    {
        private readonly IViaCepRepository _repository;
        public ProccessAddressHandler(IViaCepRepository repository)
        {
            _repository = repository;

        }
        public async Task<RequestResult> HandleAsync(ProccessAddressCommand command)
        {
            var cepResult = await _repository.GetCep(command.Cep);
            if (cepResult.StatusCode != (int)HttpStatusCode.OK)
                return cepResult;

            var cepDTO = (ViaCepDTO)cepResult.Data;
            var address = EntityMapper.ParseAddress(cepDTO, command.NumeroLogradouro);

            if (!address.IsValid)
                return new RequestResult().BadRequest("Verify the fields and try again.", cepDTO);

            return new RequestResult().Ok(address);

        }
    }
}