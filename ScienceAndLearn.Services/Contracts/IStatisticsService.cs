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
	Task Add(AuthContext? authContext, Statistics statistics);
	Task Update(AuthContext? authContext, Statistics statistics);
	Task Delete(string id);
	Task<IEnumerable<Statistics>> GetStatisticsByGame(AuthContext? authContext, string game);
	Task<Statistics> GetById(string id);
}
