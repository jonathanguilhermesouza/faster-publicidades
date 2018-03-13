using FasterTvIndoor.Domain.FasterAdministration.Commands.SectorCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class SectorCompanyApplicationService : ApplicationService,ISectorCompanyApplicationService
    {
        private ISectorCompanyRepository _repository;
        public SectorCompanyApplicationService(ISectorCompanyRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<SectorCompany> GetAll()
        {
            return _repository.GetAll();
        }

        public List<SectorCompany> GetByRange(int skip, int take)
        {
            return _repository.GetByRange(skip,take);
        }

        public SectorCompany GetById(int id)
        {
            return _repository.GetById(id);
        }

        public SectorCompany Create(CreateSectorCompanyCommand command)
        {
            var sector = new SectorCompany(command.Sector);
            sector.Create();
            _repository.Create(sector);

            if (Commit())
                return sector;

            return null;
        }

        public SectorCompany Update(UpdateSectorCompanyCommand command)
        {
            var sector = _repository.GetById(command.IdSectorCompany);
            sector.Update(command);
            _repository.Update(sector);

            if (Commit())
                return sector;

            return null;
        }

        public SectorCompany Delete()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            return _repository.GetCount();
        }
    }
}
