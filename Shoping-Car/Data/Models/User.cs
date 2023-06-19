using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class User : IdentityUser
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        public ICollection<UserCar> UserCars { get; set; } = new List<UserCar>();
    }
}
