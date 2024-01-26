namespace Domain.Interfaces
{
    using System.Threading.Tasks;

    public interface IMessageProducer
    {
        Task SendClientToExternalService();
    }
}
