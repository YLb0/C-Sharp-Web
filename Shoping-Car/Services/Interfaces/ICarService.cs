using Shop.Data.Models;
using Shop.Models;

namespace Shop.Services.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllAsync();
        Task<IEnumerable<CarViewModel>> Search(string search);

        Task AddCar(AddCarViewModel model);

        Task<IEnumerable<Registrations>> GetRegistrationsAsync();

        Task<IEnumerable<CarViewModel>> GetWatchedAsync(string userId);

        Task AddCarToCollectionAsync(int movieId, string userId);

        Task DeleteCarsAsync(int id);

        Task<EditCarViewModel> GetForEditAsync(int id);

        Task EditAsync(EditCarViewModel model);
    }
}
