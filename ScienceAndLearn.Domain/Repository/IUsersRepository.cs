using ScienceAndLearn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Domain.Repository;

public interface IUsersRepository
{
	Task Add(User user);
	Task Update(User user);
	Task Delete(string id);
	Task<User?> GetByEmail(string email);
	Task<User> GetById(string id);
}
