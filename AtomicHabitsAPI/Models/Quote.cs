using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtomicHabitsAPI.Models
{
	public class Quote
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int Page { get; set; }
		public string Category { get; set; }
	}
}
