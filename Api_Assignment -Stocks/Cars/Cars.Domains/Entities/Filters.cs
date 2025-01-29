

using Cars.Domains.Enums;

namespace  Cars.Domains
{
    public class Filters{
        public int? MinBudget{get; set;}
          public int? MaxBudget{get; set;}

          public List<FuelType> FuelTypes{get; set;}=new List<FuelType>();
    }


    
}