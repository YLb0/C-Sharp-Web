using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Models;
using Shop.Models;
using Shop.Services.Interfaces;

namespace Shop.Services
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext _context)
        {
            context = _context;
        }


        public async Task<IEnumerable<CarViewModel>> Search(string search)
        {
            var cars = await context.Cars
                .Include(m => m.Registrations)
                .Where(x => x.CarName.ToLower().Contains(search.ToLower()))
                .ToListAsync();

            return
                cars
            .Select(m => new CarViewModel()
            {
                Id = m.Id,
                CarName = m.CarName,
                Model = m.Model,
                ImageUrl = m.ImageUrl,
                TheProductYear = m.TheYearOfProduction,
                StartRegistrationDate = m.RegistrationStartDate,
                EndRegistrationDate = m.RegistrationEndtDate,
                Cost = m.Cost,
                Registrations = m?.Registrations.Registration
            });
        }

        public async Task AddCar(AddCarViewModel model)
        {
            var entity = new Car()
            {
                CarName = model.CarName,
                Model = model.Model,
                RegistrationsId = model.RegistrationsId,
                TheYearOfProduction = model.TheProductYear,
                RegistrationStartDate = model.StartRegistrationDate,
                RegistrationEndtDate = model.EndRegistrationDate,
                ImageUrl = model.ImageUrl,
                Cost = model.Cost
            };
            await context.Cars.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Registrations>> GetRegistrationsAsync()
        {
            return await context.Registrations.ToListAsync();
        }

        public async Task AddCarToCollectionAsync(int carId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserCars)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid User ID");
            }

            var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == carId);

            if (car == null)
            {
                throw new ArgumentException("Invalid Car ID");
            }
            if (!user.UserCars.Any(m => m.CarId == carId))
            {
                user.UserCars.Add(new UserCar()
                {
                    CarId = car.Id,
                    UserId = user.Id,
                    Car = car,
                    User = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CarViewModel>> GetAllAsync()
        {
            var entities = await context.Cars
                .Include(m => m.Registrations)
                .ToListAsync();

            return
                entities
            .Select(m => new CarViewModel()
            {
                Id = m.Id,
                CarName = m.CarName,
                Model = m.Model,
                ImageUrl = m.ImageUrl,
                TheProductYear = m.TheYearOfProduction,
                StartRegistrationDate = m.RegistrationStartDate,
                EndRegistrationDate = m.RegistrationEndtDate,
                Cost = m.Cost,
                Registrations = m?.Registrations.Registration
            });
        }
        public async Task<IEnumerable<CarViewModel>> GetWatchedAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserCars)
                .ThenInclude(um => um.Car)
                .ThenInclude(m => m.Registrations)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UserCars
                .Select(m => new CarViewModel()
                {
                    CarName = m.Car.CarName,
                    Registrations = m.Car.Registrations?.Registration,
                    Id = m.CarId,
                    ImageUrl = m.Car.ImageUrl,
                    Model = m.Car.Model,
                    Cost = m.Car.Cost,
                    TheProductYear = m.Car.TheYearOfProduction,
                    StartRegistrationDate = m.Car.RegistrationStartDate,
                    EndRegistrationDate = m.Car.RegistrationEndtDate
                });
        }


        public async Task<EditCarViewModel> GetForEditAsync(int id)
        {
            var ca = await context.Cars.FindAsync(id);

            var model = new EditCarViewModel()
            {
                Id = id,
                CarName = ca.CarName,
                Model = ca.Model,
                RegistrationsId = ca.RegistrationsId,
                TheProductYear = ca.TheYearOfProduction,
                StartRegistrationDate = ca.RegistrationStartDate,
                EndRegistrationDate = ca.RegistrationEndtDate,
                ImageUrl = ca.ImageUrl,
                Cost = ca.Cost
            };

            model.Registrations = await GetRegistrationsAsync();

            return model;
        }

        public async Task EditAsync(EditCarViewModel model)
        {
            var entity = await context.Cars.FindAsync(model.Id);



            entity.CarName = model.CarName;
            entity.Model = model.Model;
            entity.RegistrationsId = model.RegistrationsId;
            entity.TheYearOfProduction = model.TheProductYear;
            entity.RegistrationStartDate = model.StartRegistrationDate;
            entity.RegistrationEndtDate = model.EndRegistrationDate;
            entity.ImageUrl = model.ImageUrl;
            entity.Cost = model.Cost;

            await context.SaveChangesAsync();

        }

        public async Task DeleteCarsAsync(int id)
        {
            var car = await context.Cars.FindAsync(id);

            context.Cars.Remove(car);
            await context.SaveChangesAsync();
        }
    }
}
