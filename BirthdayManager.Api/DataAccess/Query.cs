using BirthdayManager.Api.Factory;
using BirthdayManager.Api.Models;
using BirthdayManager.Domain;
using HotChocolate;
using System.Collections.Generic;

namespace BirthdayManager.Api.DataAccess
{
    /// <summary>
    /// Classe de Queries GET do GraphQL
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Obter todos os aniversários
        /// </summary>
        /// <param name="birthdayDomain">Domain de Aniversários</param>
        /// <returns></returns>
        public List<BirthdayModel> AllBirthdaysOnly([Service] BirthdayDomain birthdayDomain) =>
            birthdayDomain.GetAllBirthdays().ToModel();
    }
}
