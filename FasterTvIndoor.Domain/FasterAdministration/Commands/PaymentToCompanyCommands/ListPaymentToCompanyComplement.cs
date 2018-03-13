using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands
{
    public class ListPaymentToCompanyComplement
    {
        public ListPaymentToCompanyComplement(int idCompany, decimal value, DateTime datePayment, int day, int year, int month, string description)
        {
            this.IdCompany = idCompany;
            this.Value = value;
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }
        public int IdPaymentToCompany { get; set; }
        public int IdCompany { get; set; }
        public decimal Value { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
