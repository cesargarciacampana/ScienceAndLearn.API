using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.DynamoDB.DataModel;

[DynamoDBTable("scienceandlearn-statistics")]
internal class StatisticsDataModel
{
	public string Id { get; init; } = string.Empty;
	public string Game { get; init; } = string.Empty;
	public string? GroupId { get; set; } = null;
	public string User { get; init; } = string.Empty;
	public int Points { get; init; }
	public int Seconds { get; init; }
	public string Info { get; init; } = string.Empty;
}
