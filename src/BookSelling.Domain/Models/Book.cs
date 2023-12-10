namespace BookSelling.Domain.Models;

public class Book : EntityBase
{
    public required string Title { get; set; }

    public string Description { get; set; } = default!;

    public DateTime PublishedOn { get; set; }

    public string Publisher { get; set; } = default!;

    public decimal Price { get; set; }

    // Relationships
    public ICollection<BookAuthor>? AuthorsLink { get; set; }
    public ICollection<PriceOffer>? PriceOffers { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Tag>? Tags { get; set; }
}