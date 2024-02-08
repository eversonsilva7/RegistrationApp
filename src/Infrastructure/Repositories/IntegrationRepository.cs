namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using Domain.Models;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class IntegrationRepository : GenericRepository<Integration>, IIntegrationRepository
    {
        public IntegrationRepository(DbContextClass dbContext) : base(dbContext)
        {
        }
    }
}