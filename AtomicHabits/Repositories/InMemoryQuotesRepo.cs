using AtomicHabits.Models;
using System.Collections.Generic;
using System.Linq;

namespace AtomicHabits.Repositories
{
  public class InMemoryQuotesRepo : IRepo<ViewQuote, int>
  {
    private readonly IMapper<ViewQuote, Quote> _mapper;
    # region Quotes
    private readonly List<Quote> quotes = new()
    {
      new Quote
      {
        Id = 1,
        Text = "1.01<sup>365</sup> = 37.8<br>0.99<sup>365</sup> = 0.03",
        Page = 15
      },
      new Quote
      {
        Id = 2,
        Text = "You do not rise to the level of your goals. You fall to the level of your systems.",
        Page = 27
      },
      new Quote
      {
        Id = 3,
        Text = "True behavior change is identity change.",
        Page = 34
      },
      new Quote
      {
        Id = 4,
        Text = "Every action you take is a vote for the type of person you wish to become.",
        Page = 38
      },
      new Quote
      {
        Id = 5,
        Text = "The people who don’t have their habits handled are often the ones with the least amount of freedom.",
        Page = 46
      },
      new Quote
      {
        Id = 6,
        Text = "The process of building a habit can be divided into four simple steps: cue, craving, response, and reward.",
        Page = 47
      },
      new Quote
      {
        Id = 7,
        Text = "What you crave is not the habit itself but the change in state it delivers.",
        Page = 48
      },
      new Quote
      {
        Id = 8,
        Text = "Want to start a good habit? Make it obvious.",
        Page = 57,
        Category = "Make it obvious"
      },
      new Quote
      {
        Id = 9,
        Text = "Become aware of your habits. Identify which habits are good, and which are bad.",
        Page = 62,
        Category = "Make it obvious"
      },
      new Quote
      {
        Id = 10,
        Text = "Check out The Habits Scorecard! It can be used to determine good and bad habits.",
        Page = 62,
        Category = "Make it obvious"
      }
    };
    #endregion
    public InMemoryQuotesRepo(IMapper<ViewQuote, Quote> mapper)
    {
      _mapper = mapper;
    }

    public ViewQuote Add(ViewQuote quote)
    {
      ViewQuote existingQuote = Get(quote.Id);
      if (existingQuote != null)
        return null;
      Quote newQuote = _mapper.ViewModelToModel(quote);
      quotes.Add(newQuote);
      //Verify that the quote is added
      return Get(quote.Id);
    }

    public IEnumerable<ViewQuote> Get()
    {
      return _mapper.ModelToViewModel(quotes);
    }

    public ViewQuote Get(int id)
    {
      Quote quote = quotes.Where(quote => quote.Id == id).SingleOrDefault();
      if (quote == null)
        return null;
      return _mapper.ModelToViewModel(quote);
    }

    public ViewQuote Update(ViewQuote quote)
    {
      var index = quotes.FindIndex(existingQuote => existingQuote.Id == quote.Id);
      quotes[index] = _mapper.ViewModelToModel(quote);
      return Get(quote.Id);
    }

    public void Delete(int id)
    {
      var index = quotes.FindIndex(quote => quote.Id == id);
      quotes.RemoveAt(index);
    }
  }//EoC
}//EoN