using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExistsSuccess()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.BoletoNumber = "12345678";
        command.FirstName = "John";
        command.LastName = "Doe";
        command.Email = "john.doe@gmail.com";
        command.City = "London";
        command.Country = "USA";
        command.ZipCode = "12345678";
        command.Document = "12345678";
        command.Neighborhood = "London";
        command.PayerEmail = "john.doe@gmail.com";
        command.Payer = "John Doe";
        command.Street = "123 Main Street";
    }
}