using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ScienceAndLearn.DynamoDB.DataModel;
using Amazon.DynamoDBv2.DocumentModel;

namespace ScienceAndLearn.DynamoDB.Repository;

public class StatisticsRepository : IStatisticsRepository
{
	IMapper mapper;
	DynamoDBContext context;

	public StatisticsRepository(IAmazonDynamoDB dynamoDbClient,
							 IMapper mapper)
	{
		this.mapper = mapper;
		context = new DynamoDBContext(dynamoDbClient);
	}

	public async Task Add(AuthContext? authContext, Statistics statistics)
	{
		var statisticsDb = mapper.Map<StatisticsDataModel>(statistics);
		statisticsDb.GroupId = authContext?.GroupCode;
		await context.SaveAsync<StatisticsDataModel>(statisticsDb);
	}

	public async Task Update(AuthContext? authContext, Statistics statistics)
	{
		var statisticsDb = mapper.Map<StatisticsDataModel>(statistics);
		statisticsDb.GroupId = authContext?.GroupCode;
		await context.SaveAsync<StatisticsDataModel>(statisticsDb);
	}

	public async Task Delete(string id)
	{
		await context.DeleteAsync<StatisticsDataModel>(id);
	}

	public async Task<IEnumerable<Statistics>> GetStatisticsByGame(AuthContext? authContext, string game)
	{
		List<ScanCondition> scanConditions = new()
		{
			new ScanCondition(nameof(StatisticsDataModel.Game), ScanOperator.Equal, game)
		};

		if (!string.IsNullOrWhiteSpace(authContext?.GroupCode))
		{
			scanConditions.Add(new ScanCondition(nameof(StatisticsDataModel.GroupId), ScanOperator.Equal, authContext.GroupCode));
		}
		else
		{
			scanConditions.Add(new ScanCondition(nameof(StatisticsDataModel.GroupId), ScanOperator.IsNull));
		}

		var statisticsDbList = await context.ScanAsync<StatisticsDataModel>(scanConditions)
			.GetRemainingAsync();

		var result = statisticsDbList.Select(u => mapper.Map<Statistics>(u))
								  .ToList();
		return result.OrderByDescending(x => x.Points).ThenBy(x => x.Seconds);
	}

	public async Task<Statistics> GetById(string id)
	{
		var statisticsDb = await context.LoadAsync<StatisticsDataModel>(id);
		var result = mapper.Map<Statistics>(statisticsDb);
		return result;
	}
}
