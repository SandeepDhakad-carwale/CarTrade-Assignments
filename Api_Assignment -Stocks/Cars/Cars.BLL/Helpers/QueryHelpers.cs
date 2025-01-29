
using Cars.Domains.Enums;

namespace Cars.BLL.Helpers{
public static class QueryHelpers
{
    public static List<FuelType> ParseFuelQuery(string? fuelQuery)
    {
        if (string.IsNullOrEmpty(fuelQuery))
            return new List<FuelType> { FuelType.All }; 

        
        var fuelValues = fuelQuery.Split('+')
                                   .Select(x => x.Trim())
                                   .Select(fuel =>
                                   {
                                       if (int.TryParse(fuel, out var fuelInt) && fuelInt >= 0 && fuelInt <= 7)
                                       {
                                           return (FuelType)fuelInt; 
                                       }
                                       return FuelType.All; 
                                   })
                                   .ToList();

        return fuelValues;
    }

        public static (int MinBudget, int MaxBudget) ParseBudgetRange(string? budget)
        {
            if (string.IsNullOrEmpty(budget))
            {
                return (0, int.MaxValue); 
            }

            var rangeParts = budget.Split('-');
            if (rangeParts.Length == 2 &&
                int.TryParse(rangeParts[0], out int min) &&
                int.TryParse(rangeParts[1], out int max) &&
                min <= max) 
            {
                return (min, max);
            }

            return (0, int.MaxValue);
        }


    }


}