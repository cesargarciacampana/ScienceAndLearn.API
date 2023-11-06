using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Domain.Model;

public class Statistics
{
	public string Id { get; set; } = string.Empty;
	public string Game { get; init; } = string.Empty;
	public string User { get; init; } = string.Empty;
	public int Points { get; init; }
	public int Seconds { get; init; }
	public string Info { get; init; } = string.Empty;
}
