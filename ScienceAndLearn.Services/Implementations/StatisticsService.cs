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

	public async Task Add(Statistics statistics)
	{
		if (String.IsNullOrWhiteSpace(statistics.Id))
			statistics.Id = Guid.NewGuid().ToString();

		await statisticsRepository.Add(statistics);
	}

	public async Task Update(Statistics statistics)
	{
		await statisticsRepository.Update(statistics);
	}

	public async Task Delete(string id)
	{
		await statisticsRepository.Delete(id);
	}

	public async Task<IEnumerable<Statistics>> GetStatisticsByGame(string game)
	{
		return await statisticsRepository.GetStatisticsByGame(game);
	}

	public async Task<Statistics> GetById(string id)
	{
		return await statisticsRepository.GetById(id);
	}
}
