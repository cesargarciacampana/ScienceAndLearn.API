using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ScienceAndLearn.DynamoDB.Mapping;

namespace ScienceAndLearn.API.Helpers
{
	public class AutoMapperHelper
	{
		public static IMapper CreateMapper()
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new DataModelMappingProfile());
				mc.AddProfile(new ViewModelMappingProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			return mapper;
		}
	}
}
