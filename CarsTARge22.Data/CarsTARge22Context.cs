using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarsTARge22.Core.Domain;


namespace CarsTARge22.Data
{
    public class CarsTARge22Context : DbContext
    {
        public CarsTARge22Context(DbContextOptions<CarsTARge22Context> options)
            : base(options) { }

        public DbSet<Car> Cars { get; set; }


    }
}
