using ControlDesk.Application.DTOs;
using ControlDesk.Application.Services;
using ControlDesk.Domain.Interfaces;
using Moq;

namespace TicketManagment.Test.Unit.Services
{
    public class TicketServiceTest
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnNewId()
        {
            // Arrange
            var repoMock = new Mock<ITicketRepository>();
            var uowMock = new Mock<IUnitOfWork>();

            var service = new TicketService(repoMock.Object, uowMock.Object);
            var dto = new CreateTicketDto("Mock Ticket 1", "Esta es una prueba de tickets Mock", 2, 3, 2);

            // Act
            int result = await service.CreateAsync(dto);

            // Assert
            Assert.NotEqual(0, result);
        }
    }
}
