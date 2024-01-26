using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIntegrationService
    {
        Task<int> CreateIntegration(int clientId);

        Task ProcessIntegration(int integrationId);

        Task<IEnumerable<Integration>> GetAllIntegrationsPending();
    }
}
