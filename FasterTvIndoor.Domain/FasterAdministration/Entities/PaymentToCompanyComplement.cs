using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class PaymentToCompanyComplement
    {
        public PaymentToCompanyComplement(int idPaymentToCompany, int idCompany, decimal value, DateTime datePayment, int day, int year, string month)
        {
            this.IdPaymentToCompany = idPaymentToCompany;
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
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
