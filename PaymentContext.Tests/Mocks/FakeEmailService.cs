using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks;

public class FakeEmailService : IEmailService
{
    public void Send(string to, string subject, string body)
    {
        
    }
}