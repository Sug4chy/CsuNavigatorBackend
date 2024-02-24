namespace CsuNavigatorBackend.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastlyEditedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}