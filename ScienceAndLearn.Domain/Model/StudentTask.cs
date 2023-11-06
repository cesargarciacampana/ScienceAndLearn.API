using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Domain.Model;

public class StudentTask
{
	public string Id { get; init; } = string.Empty;
	public DateTime? StartDate { get; init; }
	public DateTime? EndDate { get; init; }
	public string GameConfig { get; init; } = string.Empty;
}
