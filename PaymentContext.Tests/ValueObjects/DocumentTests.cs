using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{   
    [TestMethod]
    public void ShouldReturnErrorWhenCnpjIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSuccesWhenCnpjIsValid()
    {
        var doc = new Document("34110468000150", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnErrorWhenCpfIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }
    
    [TestMethod]
    public void ShouldReturnSuccesWhenCpfIsValid()
    {
        var doc = new Document("02031835505", EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}