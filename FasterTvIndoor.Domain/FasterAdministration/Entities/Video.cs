using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Video
    {
        public Video() { }
        public Video(string url, int tvAdditional, int idTypeVideo, int idTimeVideo, int idCompany, int idCategoryVideo, int idPlan, DateTime dateEnd, DateTime dateStart, ICollection<VideoEquipment> listVideoEquipment)
        {
            this.Url = url;
            this.IdTypeVideo = idTypeVideo;
            this.IdCompany = idCompany;
            this.IdCategoryVideo = idCategoryVideo;
            this.IdTimeVideo = idTimeVideo;
            this.IdPlan = idPlan;
            this.ListVideoEquipment = listVideoEquipment;
            this.DateEnd = dateEnd;
            this.TvAdditional = tvAdditional;
            this.DateStart = dateStart;
        }
        public Video(int idVideo, string url, EStatusVideo status, int tvAdditional, int idTypeVideo, int idTimeVideo, int idCompany, int idCategoryVideo, DateTime dateEnd, DateTime dateStart)
        {
            this.IdVideo = idVideo;
            this.Url = url;
            this.IdTypeVideo = idTypeVideo;
            this.IdCompany = idCompany;
            this.IdCategoryVideo = idCategoryVideo;
            this.Status = status;
            this.IdTimeVideo = idTimeVideo;
            this.DateEnd = dateEnd;
            this.DateStart = dateStart;
            this.TvAdditional = tvAdditional;
        }
        public int IdVideo { get; private set; }
        public int IdCompany { get; private set; }
        public int IdTypeVideo { get; private set; }
        public int IdTimeVideo { get; private set; }
        public int IdCategoryVideo { get; private set; }
        public int IdPlan { get; set; }
        public string Url { get; private set; }
        public int TvAdditional { get; set; }
        public EStatusVideo Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateRegister { get; private set; }
        public TypeVideo TypeVideo { get; private set; }
        public TimeVideo TimeVideo { get; private set; }
        public Company Company { get; private set; }
        public CategoryVideo CategoryVideo { get; private set; }
        public Plan Plan { get; private set; }
        public ICollection<VideoEquipment> ListVideoEquipment { get; set; }
        public ICollection<HistoryEquipment> ListHistoryEquipment { get; set; }

        public void Create()
        {
            if (!this.CreateVideoScopeIsValid())
                return;

            this.Status = EStatusVideo.Ativo;
            this.DateRegister = DateTime.Now;
        }

        public void Update(UpdateVideoCommand command)
        {
            if (!this.UpdateVideoScopeIsValid(command))
                return;

            this.IdCategoryVideo = command.IdCategoryVideo;
            this.IdTypeVideo = command.IdTypeVideo;
            this.IdPlan = command.IdPlan;
            this.Status = command.Status;
            this.IdTimeVideo = command.IdTimeVideo;
            this.Url = command.Url;
            this.DateEnd = command.DateEnd;
            this.TvAdditional = command.TvAdditional;
            this.DateStart = command.DateStart;
        }

        public void Delete()
        {
            this.Status = EStatusVideo.Inativo;
        }
    }
}
