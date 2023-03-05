namespace Address.Domain.Entities
{
    public class AddressEntity : EntityBase
    {

        public AddressEntity(string cep, string logradouro, string cidade, string unidadeFederacao, int numero, string bairro)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Cidade = cidade;
            this.UnidadeFederacao = unidadeFederacao;
            this.Numero = numero;
            this.Bairro = bairro;
        }
        public string Cep { get; private set; } = string.Empty;
        public string Logradouro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string UnidadeFederacao { get; private set; } = string.Empty;
        public int Numero { get; private set; }
        public string Bairro { get; set; } = string.Empty;
        public bool IsValid => Validate();
        public bool IsFreteGratis => IsElegivelFreteGratis();

        private bool Validate()
        {
            return
                this.Cep.Length == 9;
        }
        private bool IsElegivelFreteGratis()
        {
            return
                this.UnidadeFederacao.ToUpper() == "SP"
                ||
                this.UnidadeFederacao.ToUpper() == "MG";
        }
    }
}