using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Registrations
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Registration { get; set; } = null!;

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
