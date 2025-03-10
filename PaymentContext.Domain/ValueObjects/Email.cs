﻿using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address;
        
        AddNotifications(new Contract<Email>()
            .Requires()
            .IsEmail(Address, "Email.Address", "Address is invalid")
        );
    }

    public string Address { get; set; }
}