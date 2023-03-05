using Address.API.Tools;
using Address.Application.Repositories.External;
using Address.Application.UseCases.Commands;
using Address.Application.UseCases.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Address.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddressController : ControllerBase
    {
        [HttpPost]
        [Route("cep")]
        public async Task<ActionResult> GetCep([FromBody] ProccessAddressCommand cepCommand, [FromServices] ProccessAddressHandler handler)
        {
            return new ParseRequestResult().ParseToActionResult(await handler.HandleAsync(cepCommand));
        }
    }
}