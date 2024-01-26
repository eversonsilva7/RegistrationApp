namespace Domain.Interfaces
{
    using Domain.Models;
    using System.Threading.Tasks;

    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<bool> GetByDocumentAsync(string document);
    }
}
