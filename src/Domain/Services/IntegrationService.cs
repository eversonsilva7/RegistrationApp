using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient _httpClient;

        public IntegrationService(IUnitOfWork unitOfWork,
                                  HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _httpClient = httpClient;
        }

        public async Task<int> CreateIntegration(int clientId)
        {
            var integration = new Integration
            {
                Status = "Pending",
                ClientId = clientId,
                CreatedAt = DateTime.Now,
            };

            await _unitOfWork.Integrations.Add(integration);
            _unitOfWork.Save();

            return integration.Id;
        }

        public async Task<IEnumerable<Integration>> GetAllIntegrationsPending()
        {
            var integrations = await _unitOfWork.Integrations.GetAll();

            return integrations.Where(p => p.Status == "Pending").ToList();
        }

        public async Task ProcessIntegration(int integrationId)
        {
            var integration = await _unitOfWork.Integrations.GetById(integrationId);

            if (integration is null)
            {
                throw new System.Exception($"This integration id is not valid! Id: {integrationId}");
            }

            // Logic for integration with partner
            var client = await _unitOfWork.Clients.GetById(integration.ClientId);

            // Send client to partner and after this, update the integration status
            var inserted = await InsertClientAsync(client);

            if (inserted)
            {         
                integration.Status = "Completed";
            }
            else
            {
                integration.Status = "Error";
                integration.Error = "Something is not worked.";
            }

            integration.UpdatedAt = DateTime.Now;
            _unitOfWork.Save();

            //update flag IsIntegrated for true (client)
        }

        private async Task<bool> InsertClientAsync(Client client)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("http://localhost:5239/api/clients", jsonContent);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
