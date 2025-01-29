 using System.ComponentModel.DataAnnotations;

namespace Cars.BLL.DTOs{
 public class InputDTO
    {

        [Required]
        public decimal? Price { get; set; }  // Price in lakhs, you can adjust the validation if needed.

        [Required]
        public string? FuelType { get; set; }

        public int? Kms { get; set; }

        public string? ModelName { get; set; }

        public string? MakeYear { get; set; }

        public string? MakeName { get; set; }
    }
}