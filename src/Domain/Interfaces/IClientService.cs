using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientService
    {
        Task<int> CreateClient(Client client);

        Task<bool> GetByDocumentAsync(string document);

        Task<IEnumerable<Client>> GetAllClients();

        Task<Client> GetClientById(int id);

        Task<bool> UpdateClient(Client client);

        Task<bool> DeleteClient(int id);
    }
}
