using FasterTvIndoor.Domain.FasterAdministration.Commands.VideoEquipmentCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;
using System;
using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class VideoEquipmentApplicationService : ApplicationService, IVideoEquipmentApplicationService
    {
        private IVideoEquipmentRepository _repository;
        private IVideoRepository _repositoryVideo;
        private IHistoryEquipmentRepository _repositoryHistoryEquipment;
        private IBalanceApplicationService _repositoryBalance;
        private IControlLoanApplicationService _repositoryLoan;
        private IVideoEquipmentRepository _repositoryVideoEquipment;
        public VideoEquipmentApplicationService(IVideoRepository repositoryVideo, IVideoEquipmentRepository repository, IHistoryEquipmentRepository repositoryHistoryEquipment, IBalanceApplicationService repositoryBalance, IControlLoanApplicationService repositoryLoan, IVideoEquipmentRepository repositoryVideoEquipment, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
            _repositoryHistoryEquipment = repositoryHistoryEquipment;
            _repositoryBalance = repositoryBalance;
            _repositoryLoan = repositoryLoan;
            _repositoryVideo = repositoryVideo;
            _repositoryVideoEquipment = repositoryVideoEquipment;
        }

        public List<VideoEquipment> GetAll()
        {
            return _repository.GetAll();
        }

        public VideoEquipment GetIdVideoEquipment(int equipment, int video)
        {
            return _repository.GetIdVideoEquipment(equipment, video);
        }

        public List<VideoEquipment> GetByRange(int skip, int take, string word)
        {
            return _repository.GetByRange(skip, take, word);
        }

        public VideoEquipment GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<VideoEquipment> GetByIdEquipment(int id)
        {
            return _repository.GetByIdEquipment(id);
        }

        public VideoEquipment GetByIdVideoEquipment(int idEquipment, int idVideo)
        {
            return _repository.GetIdVideoEquipment(idEquipment, idVideo);
        }

        public VideoEquipment Create(CreateVideoEquipmentCommand command)
        {

            //Insere dados na tabela de histórico
            var loan = _repositoryLoan.GetById(command.IdControlLoan);
            decimal valueByTv = _repositoryBalance.GetValueByVideo(command.IdVideo);
            var video = _repositoryVideo.GetById(command.IdVideo);
            var history = new HistoryEquipment(command.IdVideo, command.IdEquipment, loan.IdCompany, video.Plan.Description, EAction.Inclusão, valueByTv);
            history.Create();
            _repositoryHistoryEquipment.Create(history);


            //Caso já exista os mesmos dados na tabela VideoEquipment, o registro é apenas atualizado com status ativo
            VideoEquipment videoEquipment = null;

            videoEquipment = _repository.GetById(command.IdEquipment, command.IdVideo, command.IdControlLoan);

            if (videoEquipment != null)
            {
                videoEquipment.Status = EStatusVideoEquipment.Ativo;
            }
            else
            {
                videoEquipment = new VideoEquipment(command.IdVideo, command.IdEquipment, command.IdControlLoan);
                videoEquipment.Create(videoEquipment);
                _repository.Create(videoEquipment);
            }

            if (Commit())
                return videoEquipment;

            return null;
        }

        public VideoEquipment Update(UpdateVideoEquipmentCommand command)
        {
            var videoEquipment = _repository.GetById(command.IdEquipment);
            videoEquipment.Update(command);
            _repository.Update(videoEquipment);

            if (Commit())
                return videoEquipment;

            return null;
        }

        public VideoEquipment Delete(int idEquipment, int idVideo, int controlLoan)
        {
            var loan = _repositoryLoan.GetById(controlLoan);

            decimal valueByTv = _repositoryBalance.GetValueByVideo(idVideo);
            var video = _repositoryVideo.GetById(idVideo);

            var history = new HistoryEquipment(idVideo, idEquipment, loan.IdCompany, video.Plan.Description, EAction.Exclusão, valueByTv);
            history.Create();
            _repositoryHistoryEquipment.Create(history);

            var videoEquipment = _repository.GetIdVideoEquipment(idEquipment, idVideo);
            videoEquipment.Delete(videoEquipment);
            _repository.Delete(videoEquipment);

            if (Commit())
                return videoEquipment;

            return null;
        }

        public int GetCount(string word)
        {
            return _repository.GetCount(word);
        }

        public decimal GetTotalVideoByEquipment(int idVideo)
        {
            return _repository.GetTotalVideoByEquipment(idVideo);
        }

        public int GetVideoCountByEquipment(int idVideo)
        {
            return _repository.GetVideoCountByEquipment(idVideo);
        }

        public List<VideoEquipment> GetByRange(int skip, int take, int id)
        {
            return _repository.GetByRange(skip, take, id);
        }

        public List<VideoEquipment> GetByRangeCompany(int skip, int take, int id)
        {
            return _repository.GetByRangeCompany(skip, take, id);
        }

        public int GetVideoCountByCompany(int id)
        {
            return _repository.GetVideoCountByCompany(id);
        }

        public void UpdateStatusListVideo()
        {
            VideoEquipment videoEquipment = new VideoEquipment();
            var listVideoEquipment = _repository.GetByStatus(EStatusVideoEquipment.Ativo);
            ICollection<VideoEquipment> listVideoEquipmentUpdate = videoEquipment.UpdateStatusListVideo(listVideoEquipment);

            foreach (var video in listVideoEquipmentUpdate)
            {
                var item = _repositoryVideoEquipment.GetById(videoEquipment.IdVideoEquipment);
                decimal valueByTv = _repositoryBalance.GetValueByVideo(item.IdVideo);
                var history = new HistoryEquipment(item.IdVideo, item.IdEquipment, item.ControlLoan.IdCompany, item.Video.Plan.Description, EAction.Exclusão, valueByTv);
                history.Create();
                _repositoryHistoryEquipment.Create(history);
            }

            _repository.UpdateStatusListVideo(listVideoEquipmentUpdate);

            Commit();

        }
    }
}
