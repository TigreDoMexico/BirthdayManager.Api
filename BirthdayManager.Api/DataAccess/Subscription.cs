using BirthdayManager.Api.Models;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace BirthdayManager.Api.DataAccess
{
    /// <summary>
    /// Classe de Subscription do GraphQL
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventReceiver"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<BirthdayModel>> OnBirthdayCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, BirthdayModel>("Birthday Created", cancellationToken);
        }
    }
}
