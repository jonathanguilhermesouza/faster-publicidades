using FasterTvIndoor.Domain.FasterAdministration.Commands.AddressCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class AddressCompanyApplicationService : ApplicationService, IAddressCompanyApplicationService
    {
        private IAddressCompanyRepository _repository;
        public AddressCompanyApplicationService(IAddressCompanyRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public AddressCompany GetById(int id)
        {
            return _repository.GetById(id);
        }

        public AddressCompany Update(UpdateAddressCompanyCommand command)
        {
            var address = _repository.GetById(command.IdAddressCompany);
            address.Update(command);
            _repository.Update(address);

            if (Commit())
                return address;

            return null;
        }

        public AddressCompany Delete(DeleteAddressCompanyCommand command)
        {
            var address = _repository.GetById(command.IdAddressCompany);
            _repository.Delete(address);

            if (Commit())
                return address;

            return null;
        }
    }
}
