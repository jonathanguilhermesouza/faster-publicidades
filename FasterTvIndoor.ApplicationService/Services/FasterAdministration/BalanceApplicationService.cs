using System;
using System.Collections.Generic;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Linq;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class BalanceApplicationService : ApplicationService, IBalanceApplicationService
    {
        private IVideoEquipmentRepository _repository;
        private IVideoRepository _repositoryVideo;
        private IBalanceRepository _repositoryBalance;
        List<Balance> listBalance = new List<Balance>();

        public BalanceApplicationService(IVideoEquipmentRepository repository, IVideoRepository repositoryVideo, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
            _repositoryVideo = repositoryVideo;

        }

        public List<Balance> GetAll()
        {
            //IEnumerable<VideoEquipment> listVideoEquipment = _repository.GetAll();

            //Balance balance = new Balance();

            //List<Balance> listBalance = new List<Balance>();
            //List<Balance> listBalance2 = new List<Balance>();
            //Balance balance1;

            //foreach (var video in listVideoEquipment)
            //{
            //    decimal tot = _repository.GetTotalVideoByEquipment(video.IdVideo);
            //    int qtd2 = _repository.GetVideoCountByEquipment(video.IdVideo);
            //    balance = new Balance(video.IdVideo,video.Video.Company.FantasyName,  video.Video.Plan.ValueEquipmentMain + video.Video.Plan.ValueEquipmentAdditional * video.Video.TvAdditional, qtd2, 0,0);

            //    listBalance.Add(balance);
            //}



            //List<Balance> lbSingle = new List<Balance>();

            //var lista = listBalance.GroupBy(x => new { x.IdVideo, x.Company, x.Value });

            //foreach (var item in lista)
            //{
            //    var itemArray = item.First();
            //    //decimal tot = _repository.GetTotalVideoByEquipment(itemArray.IdVideo);//sem utilidade
            //    int qtd2 = _repository.GetVideoCountByEquipment(itemArray.IdVideo);
            //    listBalance2.Add(new Balance(itemArray.IdVideo,itemArray.Company, itemArray.Value,qtd2, 0, 0));
            //}
            
            //foreach (var item in listBalance)
            //{
            //    var group = listBalance.Single(x => x.IdVideo == item.IdVideo);
            //    listBalance.Add(item);
            //}

            //balance.SerializableList(listBalance);

            //IEnumerable<Balance> list = listBalance;

            //balance.AjustBalance(statusVideo,videoEquipment

            // List<Balance> l = lista;

            //return listBalance2;
            return null;
        }

        public List<Balance> GetByRange(int skip, int take, EStatusVideo statusVideo, string word)
        {
            //List<VideoEquipment> videoEquipment = _repository.GetAll();
            //List<Balance> listBalance = new List<Balance>();
            //Balance balance = new Balance(); 

            //foreach (var video in videoEquipment)
            //{
            //    Balance obj = new Balance(video.IdVideo, video.Video.Company.FantasyName, video.Video.Plan.ValueEquipmentMain + video.Video.Plan.ValueEquipmentAdditional * video.Video.TvAdditional, _repository.GetVideoCountByEquipment(video.IdVideo),0,0);
            //    listBalance.Add(obj);
            //}
            
            //balance.AjustBalance(statusVideo,videoEquipment);

            return null;
            //return balance.SerializableList(listBalance);
        }

        public List<Balance> GetByRange(int skip, int take, EStatusVideo statusVideo, int id, string word)
        {
            List<VideoEquipment> videoEquipment = _repository.GetByRange(skip,take,id);
            List<Balance> listBalance = new List<Balance>();
            Balance balance = new Balance();


            DateTime date = DateTime.Today;
            DateTime ultimoDiaDoMes = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            decimal valueMonth = 0;

            //saber a quantidade de dias do mes atual
            int amoutDaysOfMonth = DateTime.DaysInMonth(date.Year, date.Month);

            //dividir o valor mensal pela quantidade de dias do mes

            //Se a data de inicio do video for mes atual, calcular a diferença até o ultimo dia do mes
            //Se a data de fim do video for no mes atual, calcular a diferenca até a da de fim
            //multiplicar a quantidade de dias do mes pelo valor diario ganho em cima do video



            foreach (var video in videoEquipment)
            {
                int amountDaysVideoVigente = amoutDaysOfMonth;

                // video.Video.Plan

                decimal value = (video.Video.Plan.ValueEquipmentMain + video.Video.Plan.ValueEquipmentAdditional * video.Video.TvAdditional) / amoutDaysOfMonth;


                if (video.Video.DateStart.Month == DateTime.Today.Month && video.Video.DateEnd.Month != DateTime.Today.Month && video.Video.Status == statusVideo)
                {
                    amountDaysVideoVigente = amoutDaysOfMonth - video.Video.DateStart.Day + 1;
                    //listBalance.Add(new Balance(video.IdVideo, video.Video.Company.FantasyName, value * amountDaysVideoVigente, _repository.GetVideoCountByEquipment(video.IdVideo), amountDaysVideoVigente, value, video.Video.DateStart, video.Video.DateEnd));
                }
                else if (video.Video.DateEnd.Month == DateTime.Today.Month && video.Video.DateStart.Month != DateTime.Today.Month && video.Video.Status == statusVideo)
                {
                    amountDaysVideoVigente = amoutDaysOfMonth - video.Video.DateEnd.Day + 1;
                    //listBalance.Add(new Balance(video.IdVideo, video.Video.Company.FantasyName, value * amountDaysVideoVigente, _repository.GetVideoCountByEquipment(video.IdVideo), amountDaysVideoVigente, value, video.Video.DateStart, video.Video.DateEnd));
                }
                else if (video.Video.DateEnd.Month == DateTime.Today.Month && video.Video.DateStart.Month == DateTime.Today.Month && video.Video.Status == statusVideo)
                {
                    amountDaysVideoVigente = video.Video.DateEnd.Day - video.Video.DateStart.Day + 1;
                    //listBalance.Add(new Balance(video.IdVideo, video.Video.Company.FantasyName, value * amountDaysVideoVigente, _repository.GetVideoCountByEquipment(video.IdVideo), amountDaysVideoVigente, value, video.Video.DateStart, video.Video.DateEnd));
                }

                if ((video.Video.DateEnd.Month == DateTime.Today.Month || video.Video.DateStart.Month == DateTime.Today.Month || video.Video.DateStart.Month <= DateTime.Today.Month && video.Video.DateEnd.Month >= DateTime.Today.Month) && video.Video.Status == statusVideo)
                    listBalance.Add(new Balance(video.IdVideo, video.Video.Company.FantasyName, value * amountDaysVideoVigente, video.Video.TvAdditional + 1, amountDaysVideoVigente, value, video.Video.DateStart, video.Video.DateEnd, video.Video.Plan.Title));
            }

            //balance.AjustBalance(statusVideo,videoEquipment);

            return balance.SerializableList(listBalance);
        }

        public decimal GetValueByVideo(int id)
        {

            var video = _repositoryVideo.GetById(id);
            int qtdEquipment = video.TvAdditional + 1;
            decimal valuePlan = video.Plan.ValueEquipmentMain + video.Plan.ValueEquipmentAdditional * video.TvAdditional;

            var result = valuePlan / qtdEquipment * Convert.ToDecimal(0.1);

            return valuePlan / qtdEquipment * Convert.ToDecimal(0.1);
        }

        public int GetCount(string word, int idCompany)
        {
            return _repository.GetCount(word, idCompany); ;
        }
    }
}
