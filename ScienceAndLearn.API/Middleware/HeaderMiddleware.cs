using Microsoft.Extensions.Primitives;
using ScienceAndLearn.API.Helpers;
using ScienceAndLearn.Domain.Model;

namespace ScienceAndLearn.API.Middleware
{
	public class HeaderMiddleware
	{
		private RequestDelegate next;
		private ILogger<HeaderMiddleware> logger;
		private IHostEnvironment env;

		public HeaderMiddleware(RequestDelegate next,
			ILogger<HeaderMiddleware> logger,
			IHostEnvironment env)
		{
			this.next = next;
			this.logger = logger;
			this.env = env;
		}

		public async Task InvokeAsync(HttpContext context, AuthHelper authHelper)
		{
			if (context.Request.Headers.TryGetValue("code", out StringValues values))
			{
				var code = values.First();
				if (!string.IsNullOrWhiteSpace(code) && code.Length > 5)
					authHelper.AuthContext = new AuthContext() { GroupCode = code };
			}

			await next(context);
		}
	}
}
