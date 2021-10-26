using AtomicHabitsAPI.DatabaseLayer;
using AtomicHabitsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicHabitsAPI.BusinessLayer
{
	public class QuotesRepo
	{
		private readonly QuotesContext _context;
		public async Task<ActionResult<IEnumerable<Quote>>> ReadAll() {
			return await _context.Quotes.ToListAsync();
		}
	}
}
