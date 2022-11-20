using Amazon.DynamoDBv2;
using ScienceAndLearn.API.Helpers;
using ScienceAndLearn.Domain.Repository;
using ScienceAndLearn.DynamoDB.Repository;
using ScienceAndLearn.Services.Contracts;
using ScienceAndLearn.Services.Implementations;

namespace ScienceAndLearn.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

		services.AddSingleton(AutoMapperHelper.CreateMapper());

		services.AddAWSService<IAmazonDynamoDB>();

		services.AddSingleton<IStatisticsService, StatisticsService>();
		services.AddSingleton<IStatisticsRepository, StatisticsRepository>();
	}

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}