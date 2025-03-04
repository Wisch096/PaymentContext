namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public CreditCardPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email, string cardHolderName, string cardHolderNumber, string lastTransactionNumber) : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
    {
        CardHolderName = cardHolderName;
        CardHolderNumber = cardHolderNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; private set; } 
    public string CardHolderNumber { get; private set; } 
    public string LastTransactionNumber { get; private set; } 
}