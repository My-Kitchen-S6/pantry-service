using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pantry_service.Models;

namespace pantry_service.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
         private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                }
                catch(Exception e)
                {
                    Console.WriteLine($"--> Could not run migrations: {e.Message}");
                }
            }

            if (!context.Ingredients.Any())
            {
                Console.WriteLine("--> seeding data");
                
                context.Users.AddRange(new User{UserName = "yorgo", ExternalId = 1, Auth0Id = "test"});
                
                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> we already have data");
            }
        }
    }
}