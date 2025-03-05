using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Addres _address; 
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("02031835505", EDocumentType.CPF);
        _email = new Email("bruce@wayne.com");
        _student = new Student(_name, _document, _email);
        _address = 
            new Addres("Rua afonso soares", "106", "Vila Rica", "Barreiras", "BA", "BR", "47813122");
        _subscription = new Subscription(null);
        
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = 
            new PayPalPayment
                (DateTime.Now, DateTime.Now.AddDays(1), 100, 100, _student.Name.FirstName, _document, _address, _email,"45545445");
        
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);
        
        Assert.IsTrue(!_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);
        
        Assert.IsTrue(!_student.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenAddSubscription()
    {
        var payment = 
            new PayPalPayment
                (DateTime.Now, DateTime.Now.AddDays(1), 100, 100, _student.Name.FirstName, _document, _address, _email,"45545445");
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        Assert.IsTrue(_student.IsValid);
    }
    
}