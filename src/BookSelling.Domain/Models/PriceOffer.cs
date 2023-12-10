using System.ComponentModel.DataAnnotations;

namespace BookSelling.Domain.Models;

public class PriceOffer
{
    public decimal NewPrice { get; set; }

    [Required]
    public required string PromotionalText { get; set; }

    // Relationships
    public Guid BoodId { get; set; }
}