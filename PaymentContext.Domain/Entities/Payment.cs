﻿using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Addres address, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;
        
        AddNotifications(new Contract<Payment>()
            .Requires()
            .IsLowerOrEqualsThan(0, Total, "Payment.Total", "The total paid must be greater than 0")
            .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.Total", "The total paid is less than the total")
        );
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public string Payer { get; private set; }
    public Document Document { get; private set; }
    public Addres Address { get; private set; }
    public Email Email { get; private set; }
}







