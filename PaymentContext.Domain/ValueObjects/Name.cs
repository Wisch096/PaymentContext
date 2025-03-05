using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        
        AddNotifications(new Contract<Name>()
            .Requires()
            .IsGreaterThan(firstName, 3, "FirstName", "Name should have at least 3 chars")
            .IsGreaterThan(lastName, 3, "LastName", "Last Name should have at least 3 chars")
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}