 using System.ComponentModel.DataAnnotations;
 using Cars.Domains.Enums;

namespace Cars.BLL.DTOs{
 public class InputDTO
{
    [Required]
    public decimal? Price { get; set; }

    [Required]
     [Range(0, 6, ErrorMessage = "FuelType must be between 0 and 6.")]
    public int FuelType { get; set; } 

    public int? Kms { get; set; }
    public string? ModelName { get; set; }
    public string? MakeYear { get; set; }
    public string? MakeName { get; set; }
}

}