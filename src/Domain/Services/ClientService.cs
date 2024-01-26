namespace Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Domain.Models;

    internal class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> CreateClient(Client client)
        {
            if (client != null)
            {
                client.CreatedAt = DateTime.Now;
                client.IsIntegrated = false;
                await _unitOfWork.Clients.Add(client);

                _unitOfWork.Save();
                return client.Id;
            }

            return 0;
        }

        public Task<bool> GetByDocumentAsync(string Document)
        {
            return _unitOfWork.Clients.GetByDocumentAsync(Document);
        }

        public async Task<bool> DeleteClient(int clientId)
        {
            var client = await _unitOfWork.Clients.GetById(clientId);

            if (client != null)
            {
                _unitOfWork.Clients.Delete(client);
                var result = _unitOfWork.Save();

                return result > 0;
            }

            return false;
        }

        public Task<IEnumerable<Client>> GetAllClients()
        {
            return _unitOfWork.Clients.GetAll();
        }

        public async Task<Client> GetClientById(int clientId)
        {
            var client = await _unitOfWork.Clients.GetById(clientId);

            if (client != null)
            {
                return client;
            }

            return null;
        }

        public async Task<bool> UpdateClient(Client clientUpdated)
        {
            if (clientUpdated != null)
            {
                var client = await _unitOfWork.Clients.GetById(clientUpdated.Id);
                if (client != null)
                {
                    client.Name = clientUpdated.Name;
                    client.Cellphone = clientUpdated.Cellphone;
                    client.UpdatedAt = DateTime.Now;

                    _unitOfWork.Clients.Update(client);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }
    }
}
