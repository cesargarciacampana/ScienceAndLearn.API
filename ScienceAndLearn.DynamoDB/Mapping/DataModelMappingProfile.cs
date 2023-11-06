using AutoMapper;
using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.DynamoDB.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.DynamoDB.Mapping;

public class DataModelMappingProfile : Profile
{
	public DataModelMappingProfile()
	{
		CreateMap<Statistics, StatisticsDataModel>();
		CreateMap<StatisticsDataModel, Statistics>();

		CreateMap<User, UserDataModel>();
		CreateMap<UserDataModel, User>();
	}
}
