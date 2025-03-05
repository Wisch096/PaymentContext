using Flunt.Notifications;

namespace PaymentContext.Shared;

public abstract class Entity : Notifiable<Notification> 
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}