namespace ScienceAndLearn.API.ViewModel;

public class StatisticsViewModel
{
	public string Id { get; init; } = string.Empty;
	public string Game { get; init; } = string.Empty;
	public string User { get; init; } = string.Empty;
	public int Points { get; init; }
	public int Seconds { get; init; }
	public string Info { get; init; } = string.Empty;
}
