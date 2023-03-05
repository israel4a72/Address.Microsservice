using Address.Application.DTOs;
using Address.Domain.Entities;

namespace Address.Application.UseCases.Tools
{
    public partial class EntityMapper
    {
        public static AddressEntity ParseAddress(ViaCepDTO cepDTO, int numeroLogradouro)
        {
            return new AddressEntity(
                cep: cepDTO.Cep,
                logradouro: cepDTO.Logradouro,
                cidade: cepDTO.Localidade,
                unidadeFederacao: cepDTO.Uf,
                numero: numeroLogradouro,
                bairro: cepDTO.Bairro
            );
        }
    }
}