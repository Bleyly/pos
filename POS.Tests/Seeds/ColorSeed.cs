using System.Collections.Generic;
using POS.Data;

namespace POS.Tests
{
    public static class ColorSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            int totalRecords = 5;
            var colors = new List<Color>();

            for (int index = 0; index < totalRecords; index++)
            {
                colors.Add(new Color
                {
                    Description = $"Color #{index + 1}",
                    Hexadecimal = $"#00{index}",
                    Id = index + 1,
                    Name = $"Color #{index + 1}",
                });
            }

            context.Set<Color>().AddRange(colors);
            context.SaveChanges();
        }
    }
}