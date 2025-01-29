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

        public IEnumerable<Stock> GetStocksByFilter(Filters filter)
        {
            ArgumentNullException.ThrowIfNull(filter);

  try{
         using (IDbConnection connection = _dbContext.Connection)
            {

                
               var sql = new StringBuilder("SELECT * FROM Stocks WHERE Price >= @MinBudget AND Price <= @MaxBudget");

    if (filter.FuelTypes != null && filter.FuelTypes.Count != 0 && !filter.FuelTypes.Contains(FuelType.All))
    {
        string fuelTypesString = string.Join("','", filter.FuelTypes.Select(ft => ft.ToString()));
        sql.Append($" AND FuelType IN ('{fuelTypesString}')");
    }



return connection.Query<Stock>(
    sql.ToString(),
    new
    {
        MinBudget = filter.MinBudget ?? 0,
        MaxBudget = filter.MaxBudget ?? int.MaxValue,
        FuelTypes = filter.FuelTypes != null && filter.FuelTypes.Contains(FuelType.All)
            ? "All"
            : string.Join(",", filter.FuelTypes.Select(ft => ft.ToString()))
    }).ToList();


            }
  }
   catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving stocks from the database.", ex);
            }
        }

      public Stock GetById(int id)
        {
            try
            {
                using (IDbConnection connection = _dbContext.Connection)
                {
                    var sql = "SELECT * FROM Stocks WHERE Id = @Id";
                    return connection.QuerySingleOrDefault<Stock>(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while retrieving the stock with ID {id}.", ex);
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                using (IDbConnection connection = _dbContext.Connection)
                {
                    var sql = "DELETE FROM Stocks WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the stock with ID {id}.", ex);
            }
        }

        public void AddStock(Stock stock)
        {
            try
            {
                using (IDbConnection connection = _dbContext.Connection)
                {
                    var sql = @"
                        INSERT INTO Stocks (MakeYear, MakeName, ModelName, FuelType, Price) 
                        VALUES (@MakeYear, @MakeName, @ModelName, @FuelType, @Price)";
                    connection.Execute(sql, stock);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding a new stock.", ex);
            }
        }

        

    }
}


