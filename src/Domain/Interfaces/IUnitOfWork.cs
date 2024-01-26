namespace Domain.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }

        IIntegrationRepository Integrations { get; }

        int Save();
    }
}
