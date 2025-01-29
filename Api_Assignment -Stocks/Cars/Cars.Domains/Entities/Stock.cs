

using System.ComponentModel.DataAnnotations;

namespace Cars.Domains
{
    public class Stock
    {
        [Required]
        public int? Id { get; set; }

         [Required]
        public decimal? Price { get; set; }    // I store prices in lakhs
 
           [Required]
        public string? FuelType { get; set; }

        public int? Kms { get; set; }

        public string? ModelName { get; set; }

        public string? MakeYear { get; set; }

        public string? MakeName { get; set; }
    }
}