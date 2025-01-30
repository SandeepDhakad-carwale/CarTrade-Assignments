

using Cars.BLL.Services;
using Cars.BLL.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace Cars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

       
        [HttpGet("getStocks")]
         public async Task<ActionResult<List<StockDTO>>> GetStocksByFilter([FromQuery] QueryDTO queryDto)
{
    Console.WriteLine("hello.............");
    
    var stockDtos =await _stockService.GetStocksByFilter(queryDto);
    return Ok(stockDtos);
}


      [HttpGet("{id}")]
        public async Task<ActionResult<StockDTO>> GetStockById(int id)
        {
            var stock = await _stockService.GetStockById(id);
            if (stock == null)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return Ok(stock);
        }

       [HttpDelete("{id}")]
public async Task<ActionResult> DeleteStock(int id)
{
    try
    {
       await _stockService.DeleteStock(id);
        return Ok(new { message = "Deleted successfully" });
    }
    catch (Exception ex)
    {
        return BadRequest($"Error deleting stock with ID {id}: {ex.Message}");
    }
}


        [HttpPost("addStock")]
        public async Task<ActionResult> AddStock([FromBody] InputDTO inptDto)
        {
            if (inptDto == null)
            {
                return BadRequest("Stock data cannot be null.");
            }

            try
            {
               await _stockService.AddStock(inptDto);
                return Ok(new { message = "Stock added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding stock: {ex.Message}");
            }
        }
}
}