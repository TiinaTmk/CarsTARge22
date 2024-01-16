using Microsoft.EntityFrameworkCore;
using CarsTARge22.Core.Domain;


namespace CarsTARge22.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options) { }

        public DbSet<Car> Cars { get; set; }
       

    }
}