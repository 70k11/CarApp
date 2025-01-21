using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }
        [Required]
        public string CarManufacturer { get; set; } = string.Empty;
        [Required]
        public string CarModel { get; set; } = string.Empty;
        [Required]
        public int CarYom { get; set; } = 0;
    }
}
