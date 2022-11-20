using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.DynamoDB.DataModel
{
	[DynamoDBTable("scienceandlearn-statistics")]
	internal class StatisticsDataModel
	{
		public string Id { get; set; }
		public string Game { get; set; }
	}
}
