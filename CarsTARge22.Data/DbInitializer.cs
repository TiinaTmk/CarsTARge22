using System;
using System.Linq;
using CarsTARge22.Core.Domain; 

namespace CarsTARge22.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CarContext context)
        {
            context.Database.EnsureCreated();

            
            if (context.Cars.Any())
            {
                return;   
            }

            var cars = new Car[]
            {
                new Car { }
            };

            foreach (Car car in cars)
            {
                context.Cars.Add(car);
            }

            context.SaveChanges();
        }
    }
}
