namespace Application.Mappers
{
    using Application.DTOs.Request;
    using Domain.Models;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    [ExcludeFromCodeCoverage]
    public static class ClientMapper
    {
        public static Application.DTOs.Client ToDTO(this Client client)
        {
            if (client is null)
            {
                return null;
            }

            var response = new Application.DTOs.Client
            {
                Id = client.Id,
                Document = client.Document,
                Name = client.Name,
                Cellphone = client.Cellphone,
                Email = client.Email,
                CreatedAt = client.CreatedAt,
                UpdatedAt = client.UpdatedAt,
                IsIntegrated = client.IsIntegrated,
            };

            return response;
        }

        public static IEnumerable<Application.DTOs.Client> ToDTO(this IEnumerable<Client> clients)
        {
            return clients.Select(st => st?.ToDTO());
        }

        public static Client ToDomain(this ClientRequest clientResponse)
        {
            if (clientResponse is null)
            {
                return null;
            }

            var response = new Client
            {
                Document = clientResponse.Document,
                Name = clientResponse.Name,
                Cellphone = clientResponse.Cellphone,
                Email = clientResponse.Email,
            };

            return response;
        }

        public static Client ToDomain(this ClientUpdateRequest clientResponse)
        {
            if (clientResponse is null)
            {
                return null;
            }

            var response = new Client
            {
                Id = clientResponse.Id,
                Name = clientResponse.Name,
                Cellphone = clientResponse.Cellphone,
                Email = clientResponse.Email,
            };

            return response;
        }
    }
}