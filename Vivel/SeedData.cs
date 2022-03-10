using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vivel.Database;
using Vivel.Helpers;
using Vivel.Model.Enums;

namespace Vivel
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();

            services.AddDbContext<VivelContext>(options => options.UseSqlServer(connectionString, o => o.UseNetTopologySuite()));

            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetService<VivelContext>();
            context.Database.Migrate();

            var bob = context.Users.Find("6e0884d7-c18f-4c8f-bce7-968e2cc33571");
            if (bob == null)
            {
                bob = new User
                {
                    UserId = "6e0884d7-c18f-4c8f-bce7-968e2cc33571",
                    UserName = "bob",
                    BloodType = BloodType.ABPositive,
                    Verified = true,
                };

                context.Add(bob);
                context.SaveChanges();
            }

            var alice = context.Users.Find("e093aaec-8cf0-4359-972a-0a62f0191083");
            if (alice == null)
            {
                alice = new User
                {
                    UserId = "e093aaec-8cf0-4359-972a-0a62f0191083",
                    UserName = "alice",
                    BloodType = BloodType.ONegative,
                    Verified = true,
                };

                context.Add(alice);
                context.SaveChanges();
            }

            var hospital = context.Hospitals.Find("c1f280c8-f8c7-4a50-9ee6-3acb906922d6");
            if (hospital == null)
            {
                hospital = new Hospital
                {
                    HospitalId = "c1f280c8-f8c7-4a50-9ee6-3acb906922d6",
                    Name = "Sveučilišna klinička bolnica Mostar",
                    Location = GeographyHelper.CreatePoint((decimal)43.344881230491005, (decimal)17.789455765426556),
                };

                context.Add(hospital);
                context.SaveChanges();
            }
        }
    }
}
