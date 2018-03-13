using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System.Linq;
using FasterTvIndoor.Domain.FasterAdministration.Specs;

namespace FasterTvIndoor.Infrastructure.Repositories.FasterAdministration
{
    public class BalanceRepository : IBalanceRepository
    {
        private FasterTvIndoorDataContext _context;
        public BalanceRepository(FasterTvIndoorDataContext context)
        {
            this._context = context;
        }

        public List<Balance> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Balance> GetByRange(int skip, int take, EStatusVideo statusVideo, string word)
        {
            throw new NotImplementedException();
        }

        public int GetCount(string word, int idCompany)
        {
            return _context.VideoEquipment.Where(a => a.ControlLoan.IdCompany == idCompany && a.Status == EStatusVideoEquipment.Ativo && a.Video.Status == EStatusVideo.Ativo).Count();
        }
    }
}
