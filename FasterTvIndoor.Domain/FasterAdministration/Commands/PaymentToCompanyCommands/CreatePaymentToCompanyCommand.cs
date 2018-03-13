using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands
{
    public class CreatePaymentToCompanyCommand
    {
        public CreatePaymentToCompanyCommand(int idCompany, decimal value, DateTime datePayment, string description)
        {            
            this.IdCompany = idCompany;
            this.Description = description;
            this.Value = value;
            this.DatePayment = datePayment;
        }
        public int IdDayOfMonth { get; set; }
        public int IdYear { get; set; }
        public int IdCompany { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime DatePayment { get; set; }
    }
}
