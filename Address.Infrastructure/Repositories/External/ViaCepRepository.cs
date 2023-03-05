using System.Net;
using System.Text.Json;
using Address.Application.DTOs;
using Address.Application.Helpers;
using Address.Application.Repositories.External;
using Address.Application.Results;

namespace Address.Infrastructure.Repositories.External
{
    public class ViaCepRepository : IViaCepRepository
    {
        public HttpClient _client { get; }
        public ViaCepRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<RequestResult> GetCep(string cep)
        {
            HttpRequestMessage request = new();
            request.Method = HttpMethod.Get;
            request.RequestUri = UriHelper.GetCepUrl(cep);

            try
            {
                using (_client)
                {
                    var response = await _client.SendAsync(request);
                    if (response.StatusCode != HttpStatusCode.OK)
                        return new RequestResult().BadRequest("Error when recovering data.");

                    var cepText = await response.Content.ReadAsStringAsync();
                    var cepDTO = JsonSerializer.Deserialize<ViaCepDTO>(cepText);
                    if (cepDTO is not null)
                        return new RequestResult().Ok(cepDTO);
                    throw new Exception("Invalid data.");
                }
            }
            catch (Exception ex)
            {
                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}