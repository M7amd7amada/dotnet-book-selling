namespace BookSelling.Domain.Models;

public class BookAuthor
{
    // This is the order of the authors in the book
    public byte Order { get; set; }

    // Relationships
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }

    public Book? Book { get; set; }
    public Author? Author { get; set; }
}