using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;
using CarsTARge22.Data;
using CarsTARge22.Models.Cars;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarsTARge22.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarContext _context;
        private readonly ICarsServices _carsServices;

        public CarsController(CarContext context, ICarsServices cars)
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
                    Price = (int)x.Price,
                    Transmission = x.Transmission,
                    Fuel = x.Fuel,
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

            var vm = new CarDetailsViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Price = (int)car.Price,
                Transmission = car.Transmission,
                Fuel = car.Fuel,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CarCreateUpdateViewModel();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new CarDto
                {
                    Brand = vm.Brand,
                    Model = vm.Model,
                    Year = vm.Year,
                    Price = vm.Price,
                    Transmission = vm.Transmission,
                    Fuel = vm.Fuel,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                };

                var result = await _carsServices.Create(dto);

                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View("CreateUpdate", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarCreateUpdateViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Price = (int)car.Price,
                Transmission = car.Transmission,
                Fuel = car.Fuel,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new CarDto
                {
                    Id = vm.Id,
                    Brand = vm.Brand,
                    Model = vm.Model,
                    Year = vm.Year,
                    Price = vm.Price,
                    Transmission = vm.Transmission,
                    Fuel = vm.Fuel,
                    CreatedAt = vm.CreatedAt,
                    ModifiedAt = DateTime.Now,
                };

                var result = await _carsServices.Update(dto);

                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View("CreateUpdate", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Price = (int)car.Price,
                Transmission = car.Transmission,
                Fuel = car.Fuel,
                CreatedAt = car.CreatedAt,
                ModifiedAt = car.ModifiedAt
            };

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
