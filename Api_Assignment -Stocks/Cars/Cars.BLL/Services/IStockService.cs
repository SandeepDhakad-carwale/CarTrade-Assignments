using Cars.BLL.DTOs;
using System.Collections.Generic;

namespace Cars.BLL.Services
{
    public interface IStockService
    {
        List<StockDTO> GetStocksByFilter(QueryDTO queryDto);

        StockDTO GetStockById(int id);

        void DeleteStock(int id);

        void AddStock(InputDTO stk);
    }
}
