namespace Address.Application.UseCases.Commands
{
    public class ProccessAddressCommand : ICommand
    {
        public int NumeroLogradouro { get; set; }
        public string Cep { get; set; } = string.Empty;
    }
}