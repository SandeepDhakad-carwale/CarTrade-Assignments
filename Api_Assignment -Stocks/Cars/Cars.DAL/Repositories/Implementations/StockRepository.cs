using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Cars.Domains.Enums;
using Cars.DAL.Data;
using Cars.Domains;

namespace Cars.DAL.Repositories
{
   public class StockRepository : IStockRepository
{
    private readonly DatabaseContext _dbContext;

    public StockRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Stock>> GetStocksByFilterAsync(Filters filter)
    {
        ArgumentNullException.ThrowIfNull(filter);

        try
        {
            using (IDbConnection connection = _dbContext.Connection)
            {
                var sql = new StringBuilder("SELECT * FROM Stocks WHERE Price >= @MinBudget AND Price <= @MaxBudget");

                if (filter.FuelTypes != null && filter.FuelTypes.Count != 0 && !filter.FuelTypes.Contains(FuelType.All))
                {
                    string fuelTypesString = string.Join("','", filter.FuelTypes.Select(ft => ft.ToString()));
                    sql.Append($" AND FuelType IN ('{fuelTypesString}')");
                }

                return (await connection.QueryAsync<Stock>(
                    sql.ToString(),
                    new
                    {
                        MinBudget = filter.MinBudget ?? 0,
                        MaxBudget = filter.MaxBudget ?? int.MaxValue,
                        FuelTypes = filter.FuelTypes != null && filter.FuelTypes.Contains(FuelType.All)
                            ? "All"
                            : string.Join(",", filter.FuelTypes.Select(ft => ft.ToString()))
                    }
                )).ToList();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving stocks from the database.", ex);
        }
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        try
        {
            using (IDbConnection connection = _dbContext.Connection)
            {
                var sql = "SELECT * FROM Stocks WHERE Id = @Id";
                return await connection.QuerySingleOrDefaultAsync<Stock>(sql, new { Id = id });
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while retrieving the stock with ID {id}.", ex);
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        try
        {
            using (IDbConnection connection = _dbContext.Connection)
            {
                var sql = "DELETE FROM Stocks WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while deleting the stock with ID {id}.", ex);
        }
    }

    public async Task AddStockAsync(Stock stock)
    {
        try
        {
            using (IDbConnection connection = _dbContext.Connection)
            {
                var sql = @"
                    INSERT INTO Stocks (MakeYear, MakeName, ModelName, FuelType, Price) 
                    VALUES (@MakeYear, @MakeName, @ModelName, @FuelType, @Price)";
                await connection.ExecuteAsync(sql, stock);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while adding a new stock.", ex);
        }
    }
}

}


