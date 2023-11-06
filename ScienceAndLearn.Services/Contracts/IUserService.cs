using ScienceAndLearn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Services.Contracts;

public interface IUsersService
{
	Task Add(User user);
	Task Update(User user);
	Task Delete(string id);
	Task<User?> GetByEmail(string email);
	Task<User> GetById(string id);
}
