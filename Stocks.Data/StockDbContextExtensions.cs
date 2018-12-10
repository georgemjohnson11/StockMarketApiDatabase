using System;
namespace Stocks.Data.Models
{
    public static class StockDbContextExtensions
    {
        public static bool AllMigrationsApplied(this StockDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this StockDbContext context)
        {

            if (!context.Type.Any())
            {
                //var types = JsonConvert.DeserializeObject<List<ThreatType>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "types.json"));
                context.AddRange(types);
                context.SaveChanges();
            }

            //Ensure we have some status
            if (!context.Status.Any())
            {
                //var stati = JsonConvert.DeserializeObject<List<Status>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "status.json"));
                context.AddRange(stati);
                context.SaveChanges();

            }
            //Ensure we create initial Threat List
            if (!context.Threats.Any())
            {
                var threats = JsonConvert.DeserializeObject<List<Threat>>(File.ReadAllText(@"seed" + Path.DirectorySeparatorChar + "threats.json"));
                context.AddRange(threats);
                context.SaveChanges();
            }
        }
    }
}
