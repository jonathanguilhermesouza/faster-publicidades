using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands
{
    public class UpdatePaymentToCompanyCommand
    {
        public UpdatePaymentToCompanyCommand(int idPaymentToCompany, int idCompany, decimal value, DateTime datePayment, string description)
        {
            this.IdPaymentToCompany = idPaymentToCompany;           
            this.IdCompany = idCompany;
            this.Description = description;
            this.Value = value;
            this.DatePayment = datePayment;
        }
        public int IdPaymentToCompany { get; set; }        
        public int IdCompany { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime DatePayment { get; set; }
    }
}
