using Application.Customers.Handlers;
using Application.Customers.Queries;
using Core.Interfaces;
using Core.Models;
using Moq;

namespace Application.UnitTests
{
    public class GetCustomerByIdCommandHandlerTests
    {
        [Fact]
        public async Task GetCustomerByIdQueryHandler_Should_Return_Customer()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var customerId = 1;
            mockUnitOfWork.Setup(r => r.CustomerRepository.FindById(customerId)).ReturnsAsync(new Customer { Id = customerId });

            var handler = new GetCustomerByIdQueryHandler(mockUnitOfWork.Object);
            var query = new GetCustomerByIdQuery { Id = customerId };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.Id);
        }
    }
}