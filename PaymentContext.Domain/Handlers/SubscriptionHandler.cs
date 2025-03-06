using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEmailService _emailService;

    public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
    {
        _studentRepository = studentRepository;
        _emailService = emailService;
    }
    
    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        
        if (!command.IsValid)
            return new CommandResult(false, "");
        
        AddNotifications(new Contract<SubscriptionHandler>());
        
        if(_studentRepository.DocumentExists(command.Document))
            AddNotification("Document", "");
        
        if(_studentRepository.EmailExists(command.Email))
            AddNotification("Email", "");
        
        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Addres(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

        var student = new Student(name, document, email);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid,  command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email, command.BarCode, command.BarCode);
        
        subscription.AddPayment(payment);
        student.AddSubscription(subscription);
        
        _studentRepository.CreateSubscription(student);
        _emailService.Send(command.Email, "Relou", $"{name.FirstName} {name.LastName}");
        
        return new CommandResult(true, "Subscription Created");
    }
}