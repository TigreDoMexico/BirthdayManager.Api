using BirthdayManager.Api.Factory;
using BirthdayManager.Api.Models;
using BirthdayManager.Domain;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace BirthdayManager.Api.DataAccess
{
    /// <summary>
    /// Classes de Queries POST, PUT e DELETE do GraphQL
    /// </summary>
    public class Mutation
    {
        /// <summary>
        /// Criar um Aniversário Novo
        /// </summary>
        /// <param name="birthdayDomain"></param>
        /// <param name="eventSender"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public async Task<CreateBirthdayModel> CreateBirthday([Service] BirthdayDomain birthdayDomain, [Service] ITopicEventSender eventSender, CreateBirthdayModel birthday)
        {
            birthdayDomain.AddBirthday(birthday.ToDTO());
            await eventSender.SendAsync("Aniversário criado com sucesso", birthday);

            return birthday;
        }
    }
}
