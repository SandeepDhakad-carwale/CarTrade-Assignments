
using Cars.Domains;

namespace Cars.DAL.Repositories
{
  public interface IStockRepository
{
    Task<IEnumerable<Stock>> GetStocksByFilterAsync(Filters filter);
    Task<Stock?> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task AddStockAsync(Stock stock);
}

}
