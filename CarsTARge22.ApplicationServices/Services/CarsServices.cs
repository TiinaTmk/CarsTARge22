using CarsTARge22.Core.Domain;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;  // Add this using statement
using CarsTARge22.Data;  // Add this using statement


namespace CarsTARge22.ApplicationServices.Services
{
	public class CarsServices : ICarsServices
	{
		private readonly CarContext _context;

		public CarsServices(CarContext context)
			{
				_context = context;
			}


			public async Task<Car> Create(CarDto dto)
			{
			
				Car car = new Car
				{

					Id = Guid.NewGuid(),
					Brand = dto.Brand,
					Model = dto.Model,
					Year = dto.Year,
					Price = dto.Price,
					CreatedAt = DateTime.Now,
					ModifiedAt = DateTime.Now,
				};

			
				_context.Cars.Add(car);
				await _context.SaveChangesAsync();

				return car;
			}


			public async Task<Car> Update(CarDto dto)
			{
				
				Car car = await _context.Cars.FindAsync(dto.Id);

				if (car == null)
				{
					return null; 
				}

				car.Brand = dto.Brand;
				car.Model = dto.Model;
				car.Year = dto.Year;
				car.Price = dto.Price;
				car.CreatedAt = dto.CreatedAt;
				car.ModifiedAt = DateTime.Now;

				_context.Cars.Update(car);
				await _context.SaveChangesAsync();
				return car;
			}




			public async Task<Car> DetailsAsync(Guid id)
		    { 
			
				var result = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
				return result;
			}

			public async Task<Car> Delete(Guid id)
			{
				
				var car = await _context.Cars.FindAsync(id);

				if (car == null)
				{
					return null; 
				}

		
				_context.Cars.Remove(car);
				await _context.SaveChangesAsync();

				return car;
			}
		}
	}
