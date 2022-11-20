using AutoMapper;
using ScienceAndLearn.API.ViewModel;
using ScienceAndLearn.Domain.Model;
using ScienceAndLearn.DynamoDB.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.DynamoDB.Mapping
{
	public class ViewModelMappingProfile : Profile
	{
		public ViewModelMappingProfile()
		{
			CreateMap<Statistics, StatisticsViewModel>();
			CreateMap<StatisticsViewModel, Statistics>();
		}
	}
}
