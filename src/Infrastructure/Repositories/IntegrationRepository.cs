namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;

    public class IntegrationRepository : GenericRepository<Integration>, IIntegrationRepository
    {
        public IntegrationRepository(DbContextClass dbContext) : base(dbContext)
        {
        }
    }
}