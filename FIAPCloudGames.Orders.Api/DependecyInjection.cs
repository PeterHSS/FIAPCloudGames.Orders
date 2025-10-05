using Carter;
using FIAPCloudGames.Orders.Api.Commom.Interfaces;
using FIAPCloudGames.Orders.Api.Commom.Middlewares;
using FIAPCloudGames.Orders.Api.Features.Commands.Create;
using FIAPCloudGames.Orders.Api.Features.Commands.Delete;
using FIAPCloudGames.Orders.Api.Features.Commands.Update;
using FIAPCloudGames.Orders.Api.Features.Models;
using FIAPCloudGames.Orders.Api.Features.Queries.GetById;
using FIAPCloudGames.Orders.Api.Features.Queries.GetByUserId;
using FIAPCloudGames.Orders.Api.Features.Repositories;
using FIAPCloudGames.Orders.Api.Infrastructure.ExternalServices;
using FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Context;
using FIAPCloudGames.Orders.Api.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FIAPCloudGames.Orders.Api;

public static class DependecyInjection
{
    public static IServiceCollection AddDependecyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPresentation(configuration)
            .AddInfrastructure(configuration)
            .AddApplication(configuration);

        return services;
    }

    private static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProblemDetails(configure =>
        {
            configure.CustomizeProblemDetails = (context) =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
            };
        });

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddExceptionHandler<ValidationExceptionHandlerMiddleware>();

        services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();

        services.AddCarter();

        return services;
    }


    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddExternalServices(configuration)
            .AddRepositories(configuration);

        return services;
    }

    private static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddUseCases();

        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderUseCase>();

        services.AddScoped<DeleteOrderUseCase>();

        services.AddScoped<UpdateOrderStatusUseCase>();

        services.AddScoped<GetOrderByIdUseCase>();

        services.AddScoped<GetOrdersByUserIdUseCase>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderDbContext>(options => options.UseNpgsql(configuration.GetConnectionString(nameof(Order))));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }

    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

        dbContext.Database.Migrate();
    }

    private static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IGameService, GameService>(client =>
        {
            var baseUrl = configuration.GetValue<string>("ExternalServices:GameService")!;

            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}
