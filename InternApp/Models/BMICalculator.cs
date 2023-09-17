using System.ComponentModel.DataAnnotations;

namespace InternApp.Models
{
    public class BMICalculator
    {
        [Required]
        public double Height { get; set; }
        [Required]
        public double Weight { get; set; }
        public double Result { get; set; }
    }
}
