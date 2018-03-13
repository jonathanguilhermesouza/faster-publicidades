using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.Domain.Client.Commands.AddressUserCommands;
using FasterTvIndoor.Domain.Client.Scopes;
using FasterTvIndoor.Domain.Entities.Model;

namespace FasterTvIndoor.Domain.Client.Entities
{
    public class AddressUser : Address
    {
        public AddressUser(){}
        public AddressUser(string cep, string logradouro, string bairro, string localidade, string uf, string ibge, string gia, string number, string reference, int idUser)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Bairro = bairro;
            this.Localidade = localidade;
            this.Uf = uf;
            this.Ibge = ibge;
            this.IdUser = idUser;
            this.Gia = gia;
            this.Number = number;
            this.Reference = reference;
        }
        public int IdAddressUser{ get; set; }
        public int IdUser { get; set; }
        public bool Residence { get; set; }
        public User User { get; set; }

        public void Update(UpdateAddressUserCommand command)
        {
            if (!this.UpdateAddressUserScopeIsValid(command))
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

        public void Create()
        {
            if (!this.CreateAddressUserScopeIsValid())
                return;
        }

        public void Delete(DeleteAddressUserCommand command)
        {
            this.IdAddressUser = command.IdAddressUser;
        }
    }
}
