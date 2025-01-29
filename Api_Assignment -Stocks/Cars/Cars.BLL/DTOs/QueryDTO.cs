


using System.ComponentModel.DataAnnotations;

namespace Cars.BLL.DTOs{

public class QueryDTO
{
    
    [RegularExpression(@"^([1-7](\+[1-7])*)?$", ErrorMessage = "Invalid Query formate -Fuel and Fuel values must be between 0 and 7.")]
    public string? Fuel { get; set; }

    
    [RegularExpression(@"^\d+-\d+$", ErrorMessage = "Invalid Query format - budget should be in the format 'int-int' (e.g. 1-5).")]
    public string? Budget { get; set; }
}


}