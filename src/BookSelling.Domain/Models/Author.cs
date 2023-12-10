namespace BookSelling.Domain.Models;

public class Author : EntityBase
{
    public required string Name { get; set; }

    // Relationships
    public ICollection<BookAuthor>? BooksLink { get; set; }
}