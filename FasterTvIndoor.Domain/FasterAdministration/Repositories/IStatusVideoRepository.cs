﻿using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Repositories
{
    public interface IStatusVideoRepository
    {
        List<StatusVideo> GetAll();
    }
}
