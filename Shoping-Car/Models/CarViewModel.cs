using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        
        public string CarName { get; set; } = null!;

        public string Model { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime TheProductYear { get; set; }

        public string ImageUrl { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime StartRegistrationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndRegistrationDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        public string? Registrations { get; set; }
    }
}
