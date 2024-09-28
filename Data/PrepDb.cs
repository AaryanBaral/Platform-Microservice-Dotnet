
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(this IApplicationBuilder app)
    {
        /* This is used to create a scope of application services 
        where all the services are listed using Dependency Injection */
        using var scopeService = app.ApplicationServices.CreateScope();

        /* This is used to get the instance og AppDbContext 
        from the scopeService where all the services are listed */
        var context = scopeService.ServiceProvider.GetService<AppDbContext>()
        ?? throw new InvalidOperationException("AppDbContext is not registered.");

        // Now we seed the data using the context(instance) of the dbContext
        SeedData(context);
    }

    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("------> Seeding Data");
            context.Platforms.AddRange(
                new Platform()
                {
                    Name = "Dot net",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "Sql Server Express",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "Go Lang",
                    Publisher = "Google",
                    Cost = "Free"
                }
            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("------> We already have Data");
        }
    }
}