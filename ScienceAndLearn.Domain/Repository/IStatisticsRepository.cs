using ScienceAndLearn.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScienceAndLearn.Domain.Repository;

public interface IStatisticsRepository
{
	Task Add(AuthContext? authContext, Statistics statistics);
	Task Update(AuthContext? authContext, Statistics statistics);
	Task Delete(string id);
	Task<IEnumerable<Statistics>> GetStatisticsByGame(AuthContext? authContext, string game);
	Task<Statistics> GetById(string id);
}
