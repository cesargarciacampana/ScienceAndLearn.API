using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.Domain.Repository;
using ScienceAndLearn.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Services.Implementations;

public class StatisticsService : IStatisticsService
{
	IStatisticsRepository statisticsRepository;

	public StatisticsService(IStatisticsRepository statisticsRepository)
	{
		this.statisticsRepository = statisticsRepository;
	}

	public async Task Add(AuthContext? authContext, Statistics statistics)
	{
		if (String.IsNullOrWhiteSpace(statistics.Id))
			statistics.Id = Guid.NewGuid().ToString();

		await statisticsRepository.Add(authContext, statistics);
	}

	public async Task Update(AuthContext? authContext, Statistics statistics)
	{
		await statisticsRepository.Update(authContext, statistics);
	}

	public async Task Delete(string id)
	{
		await statisticsRepository.Delete(id);
	}

	public async Task<IEnumerable<Statistics>> GetStatisticsByGame(AuthContext? authContext, string game)
	{
		return await statisticsRepository.GetStatisticsByGame(authContext, game);
	}

	public async Task<Statistics> GetById(string id)
	{
		return await statisticsRepository.GetById(id);
	}
}
