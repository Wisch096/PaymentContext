using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void AdicionarAssinatura()
    {
        var subscription = new Subscription(null);
        var student = 
            new Student("Matheus", "Wisch", "02031835505", "matheus@gmail.com");
        student.AddSubscription(subscription);
    }
}