using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Number = number;
        Type = type;
        
        AddNotifications(new Contract<Document>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", "Document invalid")
        );
    }

    public string Number { get; set; }
    public EDocumentType Type { get; set; }

    private bool Validate()
    {
        switch (Type)
        {
            case EDocumentType.CNPJ when Number.Length == 14:
            case EDocumentType.CPF when Number.Length == 11:
                return true;
            default:
                return false;
        }
    }
}