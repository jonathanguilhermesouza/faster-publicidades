using FasterTvIndoor.Domain.FasterAdministration.Entities;

namespace FasterTvIndoor.Domain.BackOffice.Entities
{
    public class LogotipoCompany
    {
        public LogotipoCompany(){}
        public LogotipoCompany(string pathImage, int idCompany)
        {
            this.PathImage = pathImage;
            this.IdCompany = idCompany;
        }
        public int IdLogotipoCompany { get; private set; }
        public int IdCompany { get; set; }
        public string PathImage { get; private set; }
        public virtual Company Company { get; private set; }
    }
}
