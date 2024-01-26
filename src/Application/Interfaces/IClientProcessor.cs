namespace Application.Interfaces
{
    using Application.DTOs.Request;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClientProcessor
    {
        Task<int> CreateClientAndIntegration(ClientRequest clientRequest);

        Task<bool> GetByDocumentAsync(string Document);

        Task<IEnumerable<Application.DTOs.Client>> GetAllClients();

        Task<Application.DTOs.Client> GetClientById(int id);

        Task<bool> UpdateClient(int id, ClientUpdateRequest clientUpdateRequest);

        Task<bool> DeleteClient(int id);
    }
}
