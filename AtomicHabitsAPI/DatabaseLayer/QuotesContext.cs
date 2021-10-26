using AtomicHabitsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicHabitsAPI.DatabaseLayer
{
	public class QuotesContext : DbContext
	{
		public QuotesContext(DbContextOptions<QuotesContext> options) : base(options)
		{
		}

		public DbSet<Quote> Quotes { get; set; }
	}
}
