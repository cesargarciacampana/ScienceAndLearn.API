using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.Domain.Repository;
using ScienceAndLearn.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Services.Implementations;

public class UsersService : IUsersService
{
	IUsersRepository usersRepository;

	public UsersService(IUsersRepository usersRepository)
	{
		this.usersRepository = usersRepository;
	}

	public async Task Add(User user)
	{
		if (String.IsNullOrWhiteSpace(user.Id))
			user.Id = Guid.NewGuid().ToString();

		await usersRepository.Add(user);
	}

	public async Task Update(User user)
	{
		await usersRepository.Update(user);
	}

	public async Task Delete(string id)
	{
		await usersRepository.Delete(id);
	}

	public async Task<User?> GetByEmail(string email)
	{
		return await usersRepository.GetByEmail(email);
	}

	public async Task<User> GetById(string id)
	{
		return await usersRepository.GetById(id);
	}
}
