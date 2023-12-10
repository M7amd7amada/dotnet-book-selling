namespace BookSelling.Domain.Models;

public class Tag : EntityBase
{
    public ICollection<Book>? Books { get; set; }
}