using System;
using System.ComponentModel.DataAnnotations;

namespace Cars.BLL.DTOs{
    public class StockDTO{
         [Required]
          public int? Id{get;set;}
           
            [Required]
         public decimal? Price{get; set;}     // I store prices in lakhs

           [Required]
         public string? FuelType {get;set;}

          public int? Kms{get;set;}
          
          public string? FormattedPrice{get; set;}   

          public string? CarName {get; set;}

         public bool? IsValueForMoney{get; set;}
    }
}