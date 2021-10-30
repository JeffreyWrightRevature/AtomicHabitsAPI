using System.Collections.Generic;
using AtomicHabits.Models;

namespace AtomicHabits.Repositories
{
  public class QuoteMapper : IMapper<ViewQuote, Quote>
  {
    public ViewQuote ModelToViewModel(Quote quote)
    {
      ViewQuote v = new ViewQuote()
      {
        Id = quote.Id,
        Text = quote.Text,
        Page = quote.Page,
        Category = quote.Category
      };
      return v;
    }

    public List<ViewQuote> ModelToViewModel(List<Quote> quotes)
    {
      List<ViewQuote> v = new();
      foreach (Quote quote in quotes)
      {
        ViewQuote q = new ViewQuote()
        {
          Id = quote.Id,
          Text = quote.Text,
          Page = quote.Page,
          Category = quote.Category
        };
        v.Add(q);
      }
      return v;
    }

    public Quote ViewModelToModel(ViewQuote quote)
    {
      Quote m = new Quote()
      {
        Id = quote.Id,
        Text = quote.Text,
        Page = quote.Page,
        Category = quote.Category
      };
      return m;
    }

    public List<Quote> ViewModelToModel(List<ViewQuote> quotes)
    {
      List<Quote> m = new();
      foreach (ViewQuote quote in quotes)
      {
        Quote q = new Quote()
        {
          Id = quote.Id,
          Text = quote.Text,
          Page = quote.Page,
          Category = quote.Category
        };
        m.Add(q);
      }
      return m;
    }
  }
}