using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJobProcessor
    {
        Task RecurringJobForClientIntegration();
    }
}
