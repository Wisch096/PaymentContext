namespace PaymentContext.Domain.Services;

public interface IEmailService
{
    void Send(string to, string subject, string body);
}