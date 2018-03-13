﻿using FasterTvIndoor.Domain.Account.Entities;
using FasterTvIndoor.SharedKernel.Validation;

namespace FasterTvIndoor.Domain.Account.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterUserScopeIsValid(this User user, bool searchEmail,bool searchNickname)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(user.Email, "O Email é obrigatório"),
                    AssertionConcern.AssertNotEmpty(user.Password, "A senha é obrigatória"),
                    AssertionConcern.AssertTrue(!searchEmail , "Email já existente"),
                    AssertionConcern.AssertTrue(!searchNickname, "Login já existente")
                );
        }

        public static bool AuthenticateUserScopeIsValid(this User user,string email, string encryptedPassword)
        {
            return AssertionConcern.IsSatisfiedBy
                (
                    AssertionConcern.AssertNotEmpty(email,"O Email é obrigatório"),
                    AssertionConcern.AssertNotEmpty(encryptedPassword,"A senha é obrigatória"),
                    AssertionConcern.AssertAreEquals(user.Email,email,"Usuário ou senha inválido"),
                    AssertionConcern.AssertAreEquals(user.Password,encryptedPassword,"Usuário ou senha inválido")
                );
        }

    }
}
