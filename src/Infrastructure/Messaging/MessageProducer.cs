using Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Messaging
{
    [ExcludeFromCodeCoverage]
    public class MessageProducer : IMessageProducer
    {
        public MessageProducer() 
        {

        }

        public Task SendClientToExternalService()
        {
            throw new NotImplementedException();
        }
    }
}
