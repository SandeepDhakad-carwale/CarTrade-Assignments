
using Cars.Domains;

namespace Cars.DAL.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetStocksByFilter(Filters filter);
        Stock GetById(int id);
        void DeleteById(int id);
        void AddStock(Stock stock);
    }
}
