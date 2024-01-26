namespace CreditEvaluation.Controllers
{
    using Application.DTOs;
    using Application.DTOs.Request;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("v1/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientProcessor _clientProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="clientService">Client Service.</param>
        public ClientsController(IClientProcessor clientService)
        {
            this._clientProcessor = clientService;
        }

        /// <summary>
        /// Get All clients.
        /// </summary>
        /// <returns>List of clients.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Client>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientList()
        {
            var clientDetailsList = await this._clientProcessor.GetAllClients();

            return clientDetailsList is not null
                ? this.Ok(clientDetailsList)
                : this.NotFound();
        }

        /// <summary>
        /// Get client by identifier.
        /// </summary>
        /// <param name="id">Id of the client.</param>
        /// <returns>Client.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetClientById(int id)
        {
            var clientDetails = await this._clientProcessor.GetClientById(id);

            return clientDetails is not null
                ? this.Ok(clientDetails)
                : this.BadRequest();
        }

        /// <summary>
        /// Create a new client.
        /// </summary>
        /// <param name="clientDetails">Client parameters (Document, Name, Email, Cellphone).</param>
        /// <returns>bool.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClient(ClientRequest clientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientExists = await this._clientProcessor.GetByDocumentAsync(clientDetails.Document);

            if (clientExists)
            {
                return this.BadRequest("Document already exists in the database.");
            }

            var createdClientId = await this._clientProcessor.CreateClientAndIntegration(clientDetails);

            if (createdClientId > 0)
            {
                return CreatedAtAction(nameof(GetClientById), new { id = createdClientId }, null);
            }
            else
            {
                return BadRequest("Failed to create the client.");
            }
        }

        /// <summary>
        /// Update client information.
        /// </summary>
        /// <param name="id">Id of the client</param>
        /// <param name="clientDetails">Client parameters (Name, Email, Cellphone).</param>
        /// <returns>bool.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateClient(int id, ClientUpdateRequest clientDetails)
        {
            var client = await _clientProcessor.GetClientById(id);

            if (client is null)
            {
                return NotFound();
            }

            if (clientDetails is not null && !string.IsNullOrEmpty(clientDetails.Name))
            {
                var isClientUpdated = await this._clientProcessor.UpdateClient(id, clientDetails);

                return isClientUpdated
                    ? this.NoContent()
                    : this.BadRequest("Client not updated.");
            }

            return this.BadRequest("Name is required!");
        }

        /// <summary>
        /// Delete client information.
        /// </summary>
        /// <param name="id">Identifier of the Client.</param>
        /// <returns>bool.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid client id");
            }

            var isClientDeleted = await this._clientProcessor.DeleteClient(id);

            return isClientDeleted
                ? this.NoContent()
                : this.BadRequest();
        }
    }
}