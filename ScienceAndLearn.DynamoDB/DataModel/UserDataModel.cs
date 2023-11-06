using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.DynamoDB.DataModel;

[DynamoDBTable("scienceandlearn-users")]
internal class UserDataModel
{
	public string Id { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Password { get; init; } = string.Empty;
	public int Role { get; init; }
}
