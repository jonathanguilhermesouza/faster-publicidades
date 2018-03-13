using FasterTvIndoor.Domain.Entities.Model;
using FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;


namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class AddressCompany : Address
    {
        public AddressCompany() { }
        public AddressCompany(int idAddressCompany, string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string number, string reference, ERegion region, int idCompany)
        {
            this.IdAddressCompany = idAddressCompany;
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Localidade = localidade;
            this.Uf = uf;
            this.Ibge = ibge;
            this.IdCompany = idCompany;
            this.Gia = gia;
            this.Number = number;
            this.Reference = reference;
            this.Region = region;
        }
        public AddressCompany(string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string ibge, string gia, string number, string reference, ERegion region, int idCompany)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Localidade = localidade;
            this.Uf = uf;
            this.Ibge = ibge;
            this.IdCompany = idCompany;
            this.Gia = gia;
            this.Number = number;
            this.Reference = reference;
            this.Region = region;
        }
        public int IdAddressCompany { get; private set; }
        public int IdCompany { get; set; }
        public virtual Company Company { get; private set; }

        public void Update(UpdateAddressCompanyCommand command)
        {
            if (!this.UpdatePhoneCompanyScopeIsValid(command))
                return;

            this.Cep = command.Cep;
            this.Logradouro = command.Logradouro;
            this.Complemento = command.Complemento;
            this.Bairro = command.Bairro;
            this.Localidade = command.Localidade;
            this.Uf = command.Uf;
            this.Ibge = command.Ibge;
            this.Gia = command.Gia;
            this.Number = command.Number;
            this.Reference = command.Reference;
        }

        public void Delete(DeleteAddressCompanyCommand command)
        {
            this.IdAddressCompany = command.IdAddressCompany;
        }

    }
}
