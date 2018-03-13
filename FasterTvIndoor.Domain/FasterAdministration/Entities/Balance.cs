using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Balance
    {
        public Balance() { }
        public Balance(int idVideo, string company, decimal value, int countEquipment, int amountDayMonth, decimal valueByDay, DateTime dateStartVideo, DateTime dateEndVideo, string plan)
        {
            this.IdVideo = idVideo;
            this.Company = company;
            this.Value = value;
            this.CountEquipment = countEquipment;
            this.AmountDayMonth = amountDayMonth;
            this.ValueByDay = valueByDay;
            this.DateStartVideo = dateStartVideo;
            this.DateEndVideo = dateEndVideo;
            this.Plan = plan;
        }
        public int IdVideo { get; set; }
        public string Company { get; set; }
        public decimal Value { get; set; }
        public int CountEquipment { get; set; }
        public int AmountDayMonth { get; set; }
        public decimal ValueByDay { get; set; }
        public string Plan { get; set; }
        public DateTime DateStartVideo { get; set; }
        public DateTime DateEndVideo { get; set; }

        public void AjustBalance(EStatusVideo statusVideo, IEnumerable<VideoEquipment> listVideoEquipment)
        {

        }
        public List<Balance> SerializableList(IEnumerable<Balance> listVideoEquipment)
        {


            List<Balance> newListBalance = new List<Balance>();

            var listaGroup = listVideoEquipment.GroupBy(x => new { x.IdVideo, x.Company, x.Value });

            foreach (var item in listaGroup)
            {
                var itemArray = item.First();
                decimal totByMonth = Math.Round((itemArray.Value / itemArray.CountEquipment) * Convert.ToDecimal(.1), 2);
                decimal totByDay = Math.Round((itemArray.ValueByDay / itemArray.CountEquipment) * Convert.ToDecimal(.1), 2);
                newListBalance.Add(new Balance(itemArray.IdVideo, itemArray.Company, totByMonth, itemArray.CountEquipment, itemArray.AmountDayMonth, totByDay, itemArray.DateStartVideo, itemArray.DateEndVideo, itemArray.Plan));
            }

            return newListBalance;
        }
    }
}
