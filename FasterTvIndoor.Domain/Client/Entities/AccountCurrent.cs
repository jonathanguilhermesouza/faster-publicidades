using FasterTvIndoor.Domain.Account.Entities;

namespace FasterTvIndoor.Domain.Client.Entities
{
    public class AccountCurrent
    {
        public AccountCurrent(){}
        public AccountCurrent(string agency, string account, int idUser)
        {
            this.Agency = agency;
            this.Account = account;
            this.IdUser = idUser;
        }
        public int IdAccountCurrent { get; set; }
        public int IdUser { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public virtual User User { get; set; }
    }
}
