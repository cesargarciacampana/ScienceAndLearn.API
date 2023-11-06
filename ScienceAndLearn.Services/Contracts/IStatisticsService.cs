using ScienceAndLearn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Services.Contracts;

public interface IStatisticsService
{
	Task Add(Statistics statistics);
	Task Update(Statistics statistics);
	Task Delete(string id);
	Task<IEnumerable<Statistics>> GetStatisticsByGame(string game);
	Task<Statistics> GetById(string id);
}
