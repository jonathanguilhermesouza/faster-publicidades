namespace FasterTvIndoor.Domain.Client.Commands.AddressUserCommands
{
    public class CreateAddressUserCommand
    {
        public CreateAddressUserCommand(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string number, string reference,int idUser)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Localidade = localidade;
            this.Uf = uf;
            this.Ibge = ibge;
            this.Gia = Gia;
            this.Number = number;
            this.Reference = reference;
            this.IdUser = idUser;
        }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Number { get; set; }
        public string Reference { get; set; }
        public int IdUser { get; set; }
    }
}
