using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.Services.Interfaces;
using System.Security.Claims;

namespace Shop.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        private readonly ApplicationDbContext _context;

        public CarsController(ICarService _carService)
        {
            carService = _carService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await carService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string search)
        {
            if (search == null)
            {
                return RedirectToAction(nameof(All));
            }
              var models = await carService.Search(search);

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCarViewModel()
            {
                Registrations = await carService.GetRegistrationsAsync()
            };
            return View(model);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Add(AddCarViewModel models)
        {
            if (!ModelState.IsValid)
            {
                return View(models);
            }

            try
            {
                await carService.AddCar(models);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Somthing went wrong");

                return View(models);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var models = await carService.GetForEditAsync(id);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel models)
        {
            if (!ModelState.IsValid)
            {
                return View(models);
            }

            await  carService.EditAsync(models);

            return RedirectToAction(nameof(All));
        }

        //[HttpPost]
        public async Task<IActionResult> AddToCollection(int carId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await carService.AddCarToCollectionAsync(carId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Watched()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await carService.GetWatchedAsync(userId);

            return View("Watched", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await carService.DeleteCarsAsync(id);

            return RedirectToAction(nameof(All));
        }

    }
}
