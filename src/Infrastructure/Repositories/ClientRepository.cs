namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DbContextClass dbContext) : base(dbContext)
        {
        }

        public async Task<bool> GetByDocumentAsync(string document)
        {
            return await this._dbContext.Clients.AnyAsync(x => x.Document == document);
        }
    }
}
