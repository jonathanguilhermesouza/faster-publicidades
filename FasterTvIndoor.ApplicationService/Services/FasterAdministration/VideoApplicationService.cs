using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System;
using System.Collections.Generic;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class VideoApplicationService : ApplicationService, IVideoApplicationService
    {
        private IVideoRepository _repository;
        private IVideoEquipmentRepository _repositoryVideoEquipment;
        private IBalanceApplicationService _repositoryBalance;
        private IHistoryEquipmentRepository _repositoryHistoryEquipment;
        private IControlLoanRepository _repositoryLoan;
        public VideoApplicationService(IControlLoanRepository repositoryLoan, IVideoEquipmentRepository repositoryVideoEquipment, IVideoRepository repository, IBalanceApplicationService repositoryBalance, IHistoryEquipmentRepository repositoryHistoryEquipment, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
            _repositoryBalance = repositoryBalance;
            _repositoryHistoryEquipment = repositoryHistoryEquipment;
            _repositoryVideoEquipment = repositoryVideoEquipment;
            _repositoryLoan = repositoryLoan;
        }

        public List<Video> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Video> GetByRange(int skip, int take, string word, EStatusVideo status)
        {
            return _repository.GetByRange(skip, take, word, status);
        }

        public Video GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Video Create(CreateVideoCommand command)
        {
            var video = new Video(command.Url, command.TvAdditional, command.IdTypeVideo, command.IdTimeVideo, command.IdCompany, command.IdCategoryVideo, command.IdPlan, command.DateEnd, command.DateStart, command.ListVideoEquipment);

            //Marca todos itens da lista ListVideoEquipment com status Ativo
            foreach (var videoEquipment in command.ListVideoEquipment)
            {
                videoEquipment.Status = EStatusVideoEquipment.Ativo;
                videoEquipment.DateRegister = DateTime.Now;
            }

            video.Create();
            _repository.Create(video);

            Commit();

            foreach (var videoEquipment in command.ListVideoEquipment)
            {
                var item = _repositoryVideoEquipment.GetById(videoEquipment.IdVideoEquipment);
                decimal valueByTv = _repositoryBalance.GetValueByVideo(item.IdVideo);
                var history = new HistoryEquipment(item.IdVideo, item.IdEquipment, item.ControlLoan.IdCompany, item.Video.Plan.Description, EAction.Inclusão, valueByTv);
                history.Create();
                _repositoryHistoryEquipment.Create(history);
            }




            if (Commit())
                return video;

            return null;
        }

        public Video Update(UpdateVideoCommand command)
        {
            var video = _repository.GetById(command.IdVideo);
            video.Update(command);
            _repository.Update(video);


            //if(video.Plan.IdPlan != command.IdPlan || video.)

            Commit();

            var videoEquipment = _repositoryVideoEquipment.GetAllByVideo(video.IdVideo);

            foreach (var item in videoEquipment)
            {
                decimal valueByTv = _repositoryBalance.GetValueByVideo(video.IdVideo);

                var history = new HistoryEquipment(command.IdVideo, item.IdEquipment, item.ControlLoan.IdCompany, video.Plan.Description, EAction.Atualização, valueByTv);
                history.Create();
                _repositoryHistoryEquipment.Create(history);
            }

            if (Commit())
                return video;

            return null;
        }

        public Video Delete(DeleteVideoCommand command)
        {

            var video = _repository.GetById(command.IdVideo);
            video.Delete();
            _repository.Delete(video);

            //Caso o vídeo seja inativado ele também será inativado na tabela VideoEquipment
            var listVideoEquipment = _repositoryVideoEquipment.GetAllByVideo(command.IdVideo);
            VideoEquipment videoEquipment = new VideoEquipment();
            var listVideoEquipmentInativada = videoEquipment.Delete(listVideoEquipment);
            _repositoryVideoEquipment.Delete(listVideoEquipmentInativada);

            if (Commit())
                return video;

            return null;
        }

        public int GetCount(string word, EStatusVideo status)
        {
            return _repository.GetCount(word, status);
        }

        public List<Video> GetByRangeCompany(int skip, int take, int id, EStatusVideo status)
        {
            return _repository.GetByRangeCompany(skip, take, id, status);
        }

        public int GetCountCompany(int id, EStatusVideo status)
        {
            return _repository.GetCountCompany(id, status);
        }
    }
}
