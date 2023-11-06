using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Domain.Model;

public class User
{
	public enum EUserRole
	{
		Teacher = 0,
		Student = 1,
		Admin = 2
	}

	public string Id { get; set; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Password { get; init; } = string.Empty;
	public EUserRole Role { get; init; }
}
