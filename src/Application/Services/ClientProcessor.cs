namespace Application.Services
{
    using Application.DTOs.Request;
    using Application.Interfaces;
    using Application.Mappers;
    using Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClientProcessor : IClientProcessor
    {
        private readonly IClientService _clientService;
        private readonly IIntegrationService _integrationService;

        public ClientProcessor(IClientService clientService, IIntegrationService integrationService)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _integrationService = integrationService ?? throw new ArgumentNullException(nameof(integrationService));
        }

        public async Task<int> CreateClientAndIntegration(ClientRequest clientRequest)
        {
            int clientId = await _clientService.CreateClient(clientRequest.ToDomain());
            await _integrationService.CreateIntegration(clientId);
            return clientId;
        }

        public Task<bool> GetByDocumentAsync(string Document)
        {
            return _clientService.GetByDocumentAsync(Document);
        }

        public async Task<bool> DeleteClient(int id)
        {
            return await _clientService.DeleteClient(id);
        }

        public async Task<IEnumerable<Application.DTOs.Client>> GetAllClients()
        {
            var result = await _clientService.GetAllClients();

            return result.ToDTO();
        }

        public async Task<Application.DTOs.Client> GetClientById(int id)
        {
            var result = await _clientService.GetClientById(id);

            return result.ToDTO();
        }

        public async Task<bool> UpdateClient(int id, ClientUpdateRequest clientUpdateRequest)
        {
            clientUpdateRequest.Id = id;
            return await _clientService.UpdateClient(clientUpdateRequest.ToDomain());
        }
    }
}
