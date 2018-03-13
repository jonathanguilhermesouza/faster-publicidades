namespace FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands
{
    public class DeletePaymentToCompanyCommand
    {
        public DeletePaymentToCompanyCommand(int idPaymentToCompany)
        {
            this.IdPaymentToCompany = idPaymentToCompany;
        }
        public int IdPaymentToCompany { get; set; }
    }
}
