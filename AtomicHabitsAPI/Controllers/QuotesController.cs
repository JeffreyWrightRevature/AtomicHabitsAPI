using AtomicHabitsAPI.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicHabitsAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class QuotesController : Controller
	{
		private readonly QuotesRepo _repo;
		public QuotesController(QuotesRepo qr) {
			_repo = qr;
		}

		// GET: QuotesController
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Quote>>> Get(int id)
		{
			ViewQuote quote = await _quotesRepo.Read(id);
			return Ok(quote);
		}

		// GET: Quotes
	}
}
