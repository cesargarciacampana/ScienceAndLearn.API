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

namespace ScienceAndLearn.DynamoDB.Repository
{
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

		public async Task Add(Statistics statistics)
		{
			var statisticsDb = mapper.Map<StatisticsDataModel>(statistics);
			await context.SaveAsync<StatisticsDataModel>(statisticsDb);
		}

		public async Task Update(Statistics statistics)
		{
			var statisticsDb = mapper.Map<StatisticsDataModel>(statistics);
			await context.SaveAsync<StatisticsDataModel>(statisticsDb);
		}

		public async Task Delete(string id)
		{
			await context.DeleteAsync<StatisticsDataModel>(id);
		}

		public async Task<IEnumerable<Statistics>> GetStatisticsByGame(string game)
		{
			var statisticsDbList = await context.ScanAsync<StatisticsDataModel>(
				new List<ScanCondition>() { new ScanCondition(nameof(StatisticsDataModel.Game), ScanOperator.Equal, game) })
				.GetRemainingAsync();

			var result = statisticsDbList.Select(u => mapper.Map<Statistics>(u))
									  .ToList();
			return result;
		}

		public async Task<Statistics> GetById(string id)
		{
			var categoryDb = await context.LoadAsync<StatisticsDataModel>(id);
			var result = mapper.Map<Statistics>(categoryDb);
			return result;
		}
	}
}
