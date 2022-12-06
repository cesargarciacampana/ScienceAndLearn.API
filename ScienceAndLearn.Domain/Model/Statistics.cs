using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Domain.Model
{
	public class Statistics
	{
		public string Id { get; set; }
		public string Game { get; set; }
		public string User { get; set; }
		public int Points { get; set; }
		public int Seconds { get; set; }
		public string Info { get; set; }
	}
}
