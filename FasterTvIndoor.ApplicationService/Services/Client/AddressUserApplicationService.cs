using FasterTvIndoor.Domain.Client.Commands.AddressUserCommands;
using FasterTvIndoor.Domain.Client.Entities;
using FasterTvIndoor.Domain.Client.Repositories;
using FasterTvIndoor.Domain.Client.Services;
using FasterTvIndoor.Infrastructure.Persistence;

namespace FasterTvIndoor.ApplicationService.Services.Client
{
    public class AddressUserApplicationService : ApplicationService, IAddressUserApplicationService
    {
        private IAddressUserRepository _repository;
        public AddressUserApplicationService(IAddressUserRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public AddressUser GetById(int id)
        {
            return _repository.GetById(id);
        }

        public AddressUser Update(UpdateAddressUserCommand command)
        {
            var address = _repository.GetById(command.IdAddressUser);
            address.Update(command);
            _repository.Update(address);

            if (Commit())
                return address;

            return null;
        }

        public AddressUser Create(CreateAddressUserCommand command)
        {
            var address = new AddressUser(command.Cep,command.Logradouro,command.Bairro,command.Localidade,command.Uf,command.Ibge,command.Gia,command.Number,command.Reference,command.IdUser);
            address.Create();
            _repository.Create(address);

            if (Commit())
                return address;

            return null;
        }

        public AddressUser Delete(DeleteAddressUserCommand command)
        {
            var address = _repository.GetById(command.IdAddressUser);
            _repository.Delete(address);

            if (Commit())
                return address;

            return null;
        }
    }
}
