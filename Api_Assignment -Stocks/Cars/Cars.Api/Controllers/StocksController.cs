

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
         public ActionResult<List<StockDTO>> GetStocksByFilter([FromQuery] QueryDTO queryDto)
{
    Console.WriteLine("hello.............");
    
    var stockDtos = _stockService.GetStocksByFilter(queryDto);
    return Ok(stockDtos);
}


      [HttpGet("{id}")]
        public ActionResult<StockDTO> GetStockById(int id)
        {
            var stock = _stockService.GetStockById(id);
            if (stock == null)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return Ok(stock);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStock(int id)
        {
            try
            {
                _stockService.DeleteStock(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting stock with ID {id}: {ex.Message}");
            }
        }

        [HttpPost("addStock")]
        public ActionResult AddStock([FromBody] InputDTO inptDto)
        {
            if (inptDto == null)
            {
                return BadRequest("Stock data cannot be null.");
            }

            try
            {
                _stockService.AddStock(inptDto);
                return Ok(new { message = "Stock added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding stock: {ex.Message}");
            }
        }
}
}