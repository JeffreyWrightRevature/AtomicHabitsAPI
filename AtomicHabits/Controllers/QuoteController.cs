using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtomicHabits.Models;
using AtomicHabits.Repositories;

namespace AtomicHabits.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class QuoteController : ControllerBase
  {
    private readonly IRepo<ViewQuote, int> _repository;

    private readonly ILogger<QuoteController> _logger;

    public QuoteController(IRepo<ViewQuote, int> repository, ILogger<QuoteController> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    // GET /Quote
    [HttpGet]
    public IEnumerable<ViewQuote> Get()
    {
      return _repository.Get();
    }

    // GET /Quote/5
    [HttpGet("{id}")]
    public ActionResult<ViewQuote> GetQuote(int id)
    {
      var quote = _repository.Get(id);
      if (quote is null)
      {
        return NotFound();
      }
      return quote;
    }

    // POST /Quote
    [HttpPost]
    public ActionResult<ViewQuote> AddItem(ViewQuote quote)
    {
      ViewQuote newQuote = _repository.Add(quote);
      return newQuote;
    }

    // PUT /Quote/5
    [HttpPut("{id}")]
    public ActionResult<ViewQuote> UpdateItem(ViewQuote quote)
    {
      ViewQuote existingQuote = _repository.Get(quote.Id);
      if (existingQuote is null)
        return NotFound();
      return _repository.Update(quote);
    }

    // DELETE //Quote/5
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
      ViewQuote existingQuote = _repository.Get(id);
      if (existingQuote is null)
        return NotFound();
      _repository.Delete(id);
      return NoContent();
    }
  }
}
