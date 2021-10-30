using System.ComponentModel.DataAnnotations;

namespace AtomicHabits.Models
{
  public class ViewQuote
  {
    //init is the perfect middle ground between set and private set. It automatically sets the value among initialization, and after that, it can't be changed.
    [Required]
    public int Id { get; init; }
    [Required]
    public string Text { get; init; }
    [Range(1, 1000)]
    public int Page { get; init; }
    public string Category { get; init; }
  }
}