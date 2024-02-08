using AutoFixture;
using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Moq;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Tests
{
    [ExcludeFromCodeCoverage]
    public class ClientServiceTest
    {
        protected readonly Fixture fixture;
        private readonly ClientService clientServices;
        private readonly Mock<IUnitOfWork> unitOfWorkMock;

        public ClientServiceTest()
        {
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            unitOfWorkMock = new Mock<IUnitOfWork>();
            clientServices = new ClientService(unitOfWorkMock.Object);
        }

        [Theory]
        [Trait("Stock", "ClientService")]
        [InlineData(false, "Value cannot be null. (Parameter 'unitOfWork')")]
        public Task ClientService_ConstructorValidations_Exception(bool createUnitOfWork, string message)
        {
            // Arrange
            var unitOfWork = default(IUnitOfWork);

            if (createUnitOfWork)
            {
                unitOfWork = unitOfWorkMock.Object;
            }

            // Act
            var exceptionResult = Assert.Throws<ArgumentNullException>(
                () => new ClientService(unitOfWork));

            // Assert
            Assert.IsType<ArgumentNullException>(exceptionResult);
            Assert.Equal(message, exceptionResult.Message);
            return Task.CompletedTask;
        }

        [Fact]
        [Trait("Stock", "StockSentinelConfigurationsManagerServices")]
        public async Task ClientService_GetAllClients_Success()
        {
            // Arrange
            var clients = fixture.CreateMany<Client>();

            unitOfWorkMock
                .Setup(unit => unit.Clients.GetAll()).ReturnsAsync(clients);

            // Act
            var result = await clientServices.GetAllClients();

            // Assert
            Assert.Equal(clients, result);

            unitOfWorkMock
                .Verify(unit => unit.Clients.GetAll(), Times.Once);
        }
    }
}