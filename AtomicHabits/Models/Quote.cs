using System;

namespace AtomicHabits.Models
{
  //The record datatype is good for immutable objects
  public record Quote
  {
    //init is the perfect middle ground between set and private set. It automatically sets the value among initialization, and after that, it can't be changed.
    public int Id { get; init; }

    public string Text { get; init; }

    public int Page { get; init; }

    public string Category { get; init; }
  }
}
