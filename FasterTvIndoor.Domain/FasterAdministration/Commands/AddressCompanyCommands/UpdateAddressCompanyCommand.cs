
namespace FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands
{
    public class UpdateAddressCompanyCommand
    {
        public UpdateAddressCompanyCommand(int idAddressCompany,string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia,string number, string reference)
        {
            this.IdAddressCompany = idAddressCompany;
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
        }
        public int IdAddressCompany { get; set; }
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
    }
}
