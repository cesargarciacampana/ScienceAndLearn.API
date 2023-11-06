using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScienceAndLearn.API.ViewModel;
using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.Services.Contracts;

namespace ScienceAndLearn.API.Controllers;

[Route("api/[controller]/{id?}")]
public class UsersController : Controller
{
	IUsersService usersService;
	IMapper mapper;

	public UsersController(IUsersService usersService,
							 IMapper mapper)
	{
		this.usersService = usersService;
		this.mapper = mapper;
	}

	[HttpPost]
	public async Task<ActionResult> Register([FromBody] UserViewModel userViewModel)
	{
		if (string.IsNullOrWhiteSpace(userViewModel?.Email))
			return BadRequest();

		var user = mapper.Map<User>(userViewModel);
		await usersService.Add(user);

		return Ok();
	}
}
