using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Services;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Data.Queries;
using TodoApp.Infrastructure.Email;
using TodoApp.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoApp.UseCases.TodoItem.Interfaces;
using TodoApp.Infrastructure.TodoItem;

namespace TodoApp.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("SqliteConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options => {
        options.UseSqlite(connectionString);
    });

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();
    services.AddScoped<ITodoItemService, TodoItemService>();


    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
