using Cars.BLL.DTOs;
using System.Collections.Generic;

namespace Cars.BLL.Services
{
    public interface IStockService
    {
        Task<List<StockDTO>> GetStocksByFilter(QueryDTO queryDto);

        Task<StockDTO> GetStockById(int id);

        Task DeleteStock(int id);

        Task AddStock(InputDTO stk);
    }
}
