using Domain.Interfaces;

namespace Infrastructure.Messaging
{
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
