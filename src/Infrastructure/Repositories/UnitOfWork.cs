namespace Infrastructure.Repositories
{
    using Domain.Interfaces;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;

        public IClientRepository Clients { get; }

        public IIntegrationRepository Integrations { get; }

        public UnitOfWork(DbContextClass dbContext,
                          IClientRepository clientRepository,
                          IIntegrationRepository integrations)
        {
            _dbContext = dbContext;
            Clients = clientRepository;
            Integrations = integrations;
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
