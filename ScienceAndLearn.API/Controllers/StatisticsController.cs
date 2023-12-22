using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScienceAndLearn.API.Helpers;
using ScienceAndLearn.API.ViewModel;
using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.Services.Contracts;

namespace ScienceAndLearn.API.Controllers;

[Route("api/[controller]/{game?}")]
public class StatisticsController : Controller
{
	IStatisticsService statisticsService;
	IMapper mapper;
	AuthHelper authHelper;

	public StatisticsController(IStatisticsService statisticsService,
							 IMapper mapper,
							 AuthHelper authHelper)
	{
		this.statisticsService = statisticsService;
		this.mapper = mapper;
		this.authHelper = authHelper;
	}

	[HttpGet]
	public async Task<ActionResult> Index(string game)
	{
		if (!string.IsNullOrEmpty(game))
		{
			var statisticsList = await statisticsService.GetStatisticsByGame(authHelper.AuthContext, game);
			var result = statisticsList.Select(s => mapper.Map<StatisticsViewModel>(s));
			return Ok(result);
		}

		return BadRequest();
	}

	[HttpPost]
	public async Task<ActionResult> Create([FromBody] StatisticsViewModel statisticsViewModel)
	{
		var statistics = mapper.Map<Statistics>(statisticsViewModel);
		await statisticsService.Add(authHelper.AuthContext, statistics);

		return Ok();
	}
}
