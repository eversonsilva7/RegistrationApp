namespace Infrastructure.Repositories
{
    using Domain.Interfaces;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;

        public IClientRepository Clients { get; }

        public IIntegrationRepository Integrations { get; }

        public UnitOfWork(DbContextClass dbContext)
        {
            if (dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbContext = dbContext;
            //Clients = clientRepository;
            //Integrations = integrations;
            Clients = new ClientRepository(_dbContext);
            Integrations = new IntegrationRepository(_dbContext);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
