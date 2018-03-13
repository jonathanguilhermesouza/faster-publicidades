using FasterTvIndoor.Domain.Account.Enum;
using FasterTvIndoor.Domain.BackOffice.Entities;
using System;
using System.Linq.Expressions;

namespace FasterTvIndoor.Domain.BackOffice.Specs
{
    public class EmployeeCompanySpecs
    {
        public static Expression<Func<EmployeeCompany, bool>> GetEmployeeCompany(string word,EStatusUser status)
        {
            if (string.IsNullOrEmpty(word) || word.Equals("null"))
                return x => x.User.StatusUser == status;

            return x => x.User.StatusUser == status && (x.User.Name.Contains(word) || x.User.LastName.Contains(word) || x.User.Email.Contains(word) || x.Cpf.Contains(word));
        }
    }
}
