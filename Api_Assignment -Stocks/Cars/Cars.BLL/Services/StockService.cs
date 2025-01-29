using Cars.DAL.Repositories;
using Cars.Domains;
using AutoMapper;
using System.Collections.Generic;
using Cars.BLL.DTOs;
using Cars.BLL.Helpers;

namespace Cars.BLL.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public List<StockDTO> GetStocksByFilter(QueryDTO queryDto)
{
    try
    {
        var filter = _mapper.Map<Filters>(queryDto);

        var stocks = _stockRepository.GetStocksByFilter(filter);

        var stockDtos = _mapper.Map<List<StockDTO>>(stocks);
            
                stockDtos=StockHelper.CheckIsValueForMoney(stockDtos);

        return stockDtos;
    }
    catch (ArgumentException ex)
    {
        throw new ApplicationException("Invalid input provided while fetching stocks.", ex);
    }
    catch (Exception ex)
    {
        throw new ApplicationException("An error occurred while fetching the stocks.", ex);
    }
}


 public StockDTO GetStockById(int id)
        {
            try
            {
                var stock = _stockRepository.GetById(id);

                if (stock == null)
                {
                    throw new KeyNotFoundException("Stock not found.");
                }

                return _mapper.Map<StockDTO>(stock);
            }
            catch (KeyNotFoundException ex)
            {
                throw new ApplicationException("The stock with the specified ID was not found.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the stock.", ex);
            }
        }

        public void DeleteStock(int id)
        {
            try
            {
                _stockRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the stock.", ex);
            }
        }

        public void AddStock(InputDTO stk)
        {
            try
            {
                var stock = _mapper.Map<Stock>(stk);

                _stockRepository.AddStock(stock);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the new stock.", ex);
            }
        }

      
    }
}