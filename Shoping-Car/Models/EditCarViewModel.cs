using Shop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class EditCarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Mark")]
        [StringLength(50)]
        [Display(Name = "Make")]
        public string CarName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter Model"), StringLength(50), Display(Name = "Model")]
        //[StringLength(50)]
        //[Display(Name = "Model")]
        public string Model { get; set; } = null!;

        //[Required(ErrorMessage = "Please enter Year Of Manufacture")]
        [DataType(DataType.Date)]
        [Display(Name = "Year Of Manufacture")]
        public DateTime TheProductYear { get; set; }

        [Required(ErrorMessage = "Please enter Url")]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Registration Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartRegistrationDate { get; set; }


        [Display(Name = "Registration End Date")]
        [DataType(DataType.Date)]
        public DateTime EndRegistrationDate { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        [Range(typeof(decimal), "0.0", "10000000.00", ConvertValueInInvariantCulture = true)]
        [Display(Name = "The Price Of The Car")]
        //[DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        public int? RegistrationsId { get; set; }

        public IEnumerable<Registrations> Registrations { get; set; } = new List<Registrations>();
    }
}
