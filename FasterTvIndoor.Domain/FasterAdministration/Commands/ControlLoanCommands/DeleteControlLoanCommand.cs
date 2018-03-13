using FasterTvIndoor.Domain.FasterAdministration.Enum;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.ControlLoanCommands
{
    public class DeleteControlLoanCommand
    {
        public DeleteControlLoanCommand(int idControlLoan)
        {
            this.IdControlLoan = idControlLoan;
            this.StatusControlLoan = EStatusControlLoan.Encerrado;
        }

        public int IdControlLoan { get; set; }
        public EStatusControlLoan StatusControlLoan { get; set; }
    }
}
