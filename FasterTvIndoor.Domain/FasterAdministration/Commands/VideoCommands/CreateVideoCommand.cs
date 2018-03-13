using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands
{
    public class CreateVideoCommand
    {
        public CreateVideoCommand(string url, int tvAdditional, int idTypeVideo, int idTimeVideo, int idCompany, int idCategoryVideo, int idPlan, DateTime dateEnd, DateTime dateStart, ICollection<VideoEquipment> listVideoEquipment)
        {
            this.Url = url;
            this.IdTypeVideo = idTypeVideo;
            this.IdCompany = idCompany;
            this.IdCategoryVideo = idCategoryVideo;
            this.IdTimeVideo = idTimeVideo;
            this.IdPlan = idPlan;
            this.ListVideoEquipment = listVideoEquipment;
            this.DateEnd = dateEnd;
            this.DateStart = dateStart;
            this.TvAdditional = tvAdditional;
        }
        public int IdVideo { get; private set; }
        public int IdCompany { get; private set; }
        public int IdTypeVideo { get; set; }
        public int IdTimeVideo { get; set; }
        public int IdCategoryVideo { get; set; }
        public int IdPlan { get; set; }
        public string Url { get; private set; }
        public int Time { get; private set; }
        public int TvAdditional { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public ICollection<VideoEquipment> ListVideoEquipment { get; set; }
    }
}
