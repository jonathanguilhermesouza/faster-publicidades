using FasterTvIndoor.Domain.BackOffice.Commands.EmployeeCompany;
using FasterTvIndoor.Domain.BackOffice.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.BackOffice.Scopes
{
    public static class EmployeeCompanyScopes
    {
        public static bool CreateEmployeeCompanyScopeIsValid(this EmployeeCompany employee)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(employee.Cpf, "O CPF é obrigatório"),
                    AssertionConcern.AssertNotEmpty(employee.User.Email, "O Email é obrigatório"),
                    AssertionConcern.AssertNotEmpty(employee.User.Password, "A senha é obrigatória"),
                    AssertionConcern.AssertNotEmpty(employee.User.Name, "O nome é obrigatório"),
                    AssertionConcern.AssertNotEmpty(employee.User.LastName, "O Sobrenome é obrigatório")
                );
        }

        public static bool UpdateEmployeeCompanyScopeIsValid(this EmployeeCompany employee,UpdateEmployeeCompanyCommand employeeCompany)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(employeeCompany.Cpf, "O CPF é obrigatório")
                );
        }
        
    }
}
