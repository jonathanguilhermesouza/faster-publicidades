using FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class PaymentToCompany
    {
        public PaymentToCompany() { }
        public PaymentToCompany(int idCompany, decimal value, DateTime datePayment, string description)
        {
            this.IdCompany = idCompany;
            this.Description = description;
            this.Value = value;
            this.DatePayment = datePayment;
        }
        public int IdPaymentToCompany { get; set; }        
        public int IdCompany { get; set; }
        public string Description { get; set; }
        public DateTime DatePayment { get; set; }
        public decimal Value { get; set; }       
        public Company Company { get; set; }

        public void Create()
        {

        }

        public void Update(UpdatePaymentToCompanyCommand command)
        {
            this.DatePayment = command.DatePayment;
            this.Description = command.Description;
            this.Value = command.Value;
        }
    }
}
