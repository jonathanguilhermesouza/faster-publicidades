using FasterTvIndoor.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private FasterTvIndoorDataContext _contex;

        public UnitOfWork(FasterTvIndoorDataContext context)
        {
            _contex = context;
        }
        public void Commit()
        {
            _contex.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_contex != null)
                {
                    _contex.Dispose();
                    _contex = null;
                }
            }
        }
    }
}
