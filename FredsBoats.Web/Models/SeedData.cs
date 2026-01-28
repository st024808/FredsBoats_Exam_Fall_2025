using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Data;

namespace FredsBoats.Web.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FredsBoatsContext(
                serviceProvider.GetRequiredService<DbContextOptions<FredsBoatsContext>>()))
            {
                // If DB has boats, exit (so we don't double-add)
                if (context.Boats.Any()) return;

                // 1. Categories
                var cats = new List<Category> {
                    new Category { Name = "Sailing" },
                    new Category { Name = "Motor" },
                    new Category { Name = "Inflatable" },
                    new Category { Name = "Yacht" }
                };
                context.Categories.AddRange(cats);

                // 2. Colours
                var cols = new List<BoatColour> {
                    new BoatColour { Name = "White" },
                    new BoatColour { Name = "Blue" },
                    new BoatColour { Name = "Red" },
                    new BoatColour { Name = "Black" },
                    new BoatColour { Name = "Yellow" }
                };
                context.BoatColours.AddRange(cols);
                context.SaveChanges();

                // 3. Generate 50 Boats
                var rnd = new Random();
                var boatNames = new[] { "Sea", "Ocean", "Wave", "Star", "Sun", "Moon", "Spirit", "Runner", "Chaser" };
                var boatTypes = new[] { "Breeze", "Flyer", "Rocket", "Cruiser", "Raider", "Storm", "Walker" };

                for (int i = 0; i < 50; i++)
                {
                    var name = $"{boatNames[rnd.Next(boatNames.Length)]} {boatTypes[rnd.Next(boatTypes.Length)]} {i+1}";
                    context.Boats.Add(new Boat
                    {
                        Name = name,
                        HourRate = rnd.Next(20, 150),
                        DailyRate = rnd.Next(100, 1000),
                        Category = cats[rnd.Next(cats.Count)],
                        BoatColour = cols[rnd.Next(cols.Count)]
                    });
                }
                context.SaveChanges();
            }
        }
    }
}