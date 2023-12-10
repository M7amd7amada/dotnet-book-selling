namespace BookSelling.Domain.Models;

public class Review : EntityBase
{
    public required string VoterName { get; set; }
    public int NumStars { get; set; }
    public required string Comment { get; set; }

    // Relationships
    public Guid BookId { get; set; }
}