namespace BookSelling.Domain.Models;

public class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
    public Status Status { get; set; } = Status.Active;
}

public enum Status : byte
{
    Inactive = 0,
    Active = 1
}