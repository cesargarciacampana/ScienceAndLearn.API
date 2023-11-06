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

public class UsersRepository : IUsersRepository
{
	IMapper mapper;
	DynamoDBContext context;

	public UsersRepository(IAmazonDynamoDB dynamoDbClient,
							 IMapper mapper)
	{
		this.mapper = mapper;
		context = new DynamoDBContext(dynamoDbClient);
	}

	public async Task Add(User user)
	{
		var userDb = mapper.Map<UserDataModel>(user);
		await context.SaveAsync<UserDataModel>(userDb);
	}

	public async Task Update(User user)
	{
		var userDb = mapper.Map<UserDataModel>(user);
		await context.SaveAsync<UserDataModel>(userDb);
	}

	public async Task Delete(string id)
	{
		await context.DeleteAsync<UserDataModel>(id);
	}

	public async Task<User?> GetByEmail(string email)
	{
		var userDbList = await context.ScanAsync<UserDataModel>(
			new List<ScanCondition>() { new ScanCondition(nameof(UserDataModel.Email), ScanOperator.Equal, email) })
			.GetRemainingAsync();

		return userDbList.Select(u => mapper.Map<User>(u)).FirstOrDefault();
	}

	public async Task<User> GetById(string id)
	{
		var userDb = await context.LoadAsync<UserDataModel>(id);
		var result = mapper.Map<User>(userDb);
		return result;
	}
}
