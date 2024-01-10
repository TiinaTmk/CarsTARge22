using System;
using System.Linq;
using CarsTARge22.Core.Domain;  // Add this using statement

namespace CarsTARge22.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();

            // Look for any cars.
            if (context.Cars.Any())
            {
                return;   // DB has been seeded
            }

            var cars = new Car[]
            {
                new Car { Brand = "Carson", Model = "Alexander", Year = 2005 }
            };

            foreach (Car car in cars)
            {
                context.Cars.Add(car);
            }

            context.SaveChanges();
        }
    }
}
