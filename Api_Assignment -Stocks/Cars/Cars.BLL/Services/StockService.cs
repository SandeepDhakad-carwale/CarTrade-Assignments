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

        public  StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<List<StockDTO>> GetStocksByFilter(QueryDTO queryDto)
{
    try
    {
        var filter = _mapper.Map<Filters>(queryDto);

        var stocks =await  _stockRepository.GetStocksByFilterAsync(filter);

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


 public async Task<StockDTO> GetStockById(int id)
        {
            try
            {
                var stock = await _stockRepository.GetByIdAsync(id);

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

        public async Task DeleteStock(int id)
        {
            try
            {
               await _stockRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting the stock.", ex);
            }
        }

        public async Task AddStock(InputDTO stk)
        {
            try
            {
                var stock = _mapper.Map<Stock>(stk);

               await _stockRepository.AddStockAsync(stock);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the new stock.", ex);
            }
        }

      
    }
}