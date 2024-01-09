using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;
using CarsTARge22.Data;
using CarsTARge22.Models.Cars;



namespace CarsTARge22.Controllers
{
	public class CarsController : Controller
	{
		private readonly CarsTARge22Context _context;
		private readonly ICarsServices _carsServices;

		public CarsController
			(
				CarsTARge22Context context,
				ICarsServices cars
			)
		{
			_context = context;
			_carsServices = cars;
		}

		[HttpGet]


		public IActionResult Index()
		{
			var result = _context.Cars
				.OrderByDescending(y => y.CreatedAt)
				.Select(x => new CarIndexViewModel
				{
					Id = x.Id,
					Brand = x.Brand,
					Model = x.Model,
					Year = x.Year,
					Price = x.Price
				});

		


			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var car = await _carsServices.DetailsAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarDetailsViewModel();

			vm.Id = car.Id;
			vm.Brand = car.Brand;
			vm.Model = car.Model;
			vm.Year = car.Year;
			vm.Price = car.Price;
			vm.CreatedAt = car.CreatedAt;
			vm.ModifiedAt = car.ModifiedAt;

			return View(vm);
		}

		[HttpGet]
		public IActionResult Create()
		{
			CarCreateUpdateViewModel vm = new();

			return View("CreateUpdate", vm);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
		{
			var dto = new CarDto()
			{
				Id = vm.Id,
				Brand = vm.Brand,
				Model = vm.Model,
				Year = vm.Year,
				Price = vm.Price,
				CreatedAt = vm.CreatedAt,
				ModifiedAt = vm.ModifiedAt,
			};

			var result = await _carsServices.Create(dto);

			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}

		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var car = await _carsServices.DetailsAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarCreateUpdateViewModel();

			vm.Id = car.Id;
			vm.Brand = car.Brand;
			vm.Model = car.Model;
			vm.Year = car.Year;
			vm.Price = car.Price;
			vm.CreatedAt = car.CreatedAt;
			vm.ModifiedAt = car.ModifiedAt;


			return View("CreateUpdate", vm);
		}

		[HttpPost]
		public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
		{
			var dto = new CarDto();

			dto.Id = vm.Id;
			dto.Brand = vm.Brand;
			dto.Model = vm.Model;
			dto.Year = vm.Year;
			dto.Price = vm.Price;
			dto.CreatedAt = vm.CreatedAt;
			dto.ModifiedAt = vm.ModifiedAt;

			var result = await _carsServices.Update(dto);

			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var car = await _carsServices.DetailsAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			var vm = new CarDeleteViewModel();

			vm.Id = car.Id;
			vm.Brand = car.Brand;
			vm.Model = car.Model;
			vm.Year = car.Year;
			vm.Price = car.Price;
			vm.CreatedAt = car.CreatedAt;
			vm.ModifiedAt = car.ModifiedAt;

			return View(vm);
		}


		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var carId = await _carsServices.Delete(id);

			if (carId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}
	}
}

		

		
