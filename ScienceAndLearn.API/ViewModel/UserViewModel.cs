using static ScienceAndLearn.Domain.Model.User;

namespace ScienceAndLearn.API.ViewModel;

public class UserViewModel
{
	public string Id { get; init; } = string.Empty;
	public string Email { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public string Password { get; init; } = string.Empty;
	public EUserRole Role { get; init; }
}
