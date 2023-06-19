using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    public class AddCarViewModel
    {
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

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }

        [Display(Name = "Registration Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartRegistrationDate { get; set; }
        
        
        [Display(Name = "Registration End Date")]
        [DataType(DataType.Date)]
        public DateTime EndRegistrationDate { get; set; }

        [Required(ErrorMessage = "Please enter Price")]
        [Range(typeof(decimal), "-1", "79228162514264337593543950335", ConvertValueInInvariantCulture = true)]
        [Display(Name = "The Price Of The Car")]
        //[DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        public int RegistrationsId { get; set; }

        public IEnumerable<Registrations> Registrations { get; set; } = new List<Registrations>();
    }
}
