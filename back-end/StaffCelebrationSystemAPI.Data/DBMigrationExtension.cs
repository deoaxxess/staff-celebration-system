using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffCelebrationSystemAPI.Data
{
    /// <summary>
    /// This class ensures that the db is created and auto applies DB migrations on application start
    /// </summary>
    public static class DBMigrationExtension
    {
        public static IApplicationBuilder ApplyDBMigrations<TContext>(
            this IApplicationBuilder app, ILogger<TContext> logger) where TContext : DbContext
        {
            try
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<TContext>();

                    logger.LogInformation("Checking for pending migrations...");
                    var pendingMigrations = context.Database.GetPendingMigrations();

                    if (pendingMigrations.Any())
                    {
                        logger.LogInformation($"Found {pendingMigrations.Count()} pending migrations. Applying...");
                        context.Database.Migrate();
                        logger.LogInformation("Successfully applied all pending migrations");
                    }
                    else
                    {
                        logger.LogInformation("No pending migrations found");
                    }
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "An error occured while applying migrations");
                throw;
            }

            return app;
        }
    }
}
