using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Enum;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.FasterAdministration.Specs
{
    public class ControlLoanSpecs
    {
        public static Expression<Func<ControlLoan, bool>> GetSearchControlLoan(string word, EStatusControlLoan status)
        {
            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdControlLoan.Equals(null) && x.StatusControlLoan == status;

            return x => (x.Company.CompanyName.Contains(word) || x.Company.FantasyName.Contains(word) || x.Equipment.Patrimony.Contains(word) || x.Equipment.SerialNumber.Contains(word) || x.Equipment.Model.Contains(word)) && x.StatusControlLoan == status;
        }

        public static Expression<Func<ControlLoan, bool>> GetSearchControlLoan(int idCompany, string word, EStatusControlLoan status)
        {

            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => !x.IdControlLoan.Equals(null) && x.IdCompany == idCompany && x.StatusControlLoan == status;

            return x => (x.Company.CompanyName.Contains(word) || x.Company.FantasyName.Contains(word) || x.Equipment.Patrimony.Contains(word) || x.Equipment.SerialNumber.Contains(word) || x.Equipment.Model.Contains(word)) && x.IdCompany == idCompany && x.StatusControlLoan == status;
        }

        public static Expression<Func<ControlLoan, bool>> GetControlLoan(EStatusControlLoan status)
        {
            return x => x.StatusControlLoan == status;
        }

        public static Expression<Func<ControlLoan, bool>> GetEquipmentControlLoan(int idTypeEquipment, EStatusControlLoan status)
        {
            return x => x.StatusControlLoan == status && x.Equipment.IdTypeEquipment == idTypeEquipment;
        }

        public static Expression<Func<ControlLoan, bool>> GetEquipmentControlLoan(int idTypeEquipment, int idVideo, EStatusControlLoan status)
        {
            return x => x.StatusControlLoan == status && x.Equipment.IdTypeEquipment == idTypeEquipment && x.IdEquipment != idVideo;
        }

        private static bool GetTeste(int idVideo)
        {
            return true;
        }

        public static Expression<Func<VideoEquipment, bool>> GetVideoEquipment(int idVideo)
        {
            return x => x.IdVideo == idVideo;
        }
    }
}
