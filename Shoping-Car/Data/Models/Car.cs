using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CarName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Model { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime TheYearOfProduction { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationEndtDate { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; } = null!;

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }

        [ForeignKey(nameof(Registrations))]
        public int? RegistrationsId { get; set; }

        public Registrations Registrations { get; set; }


        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        public ICollection<UserCar> UserCars { get; set; } = new List<UserCar>();
    }
}
