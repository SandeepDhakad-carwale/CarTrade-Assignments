
using Cars.BLL.DTOs;

namespace Cars.BLL.Helpers{
    public static class StockHelper{

             public static List<StockDTO> CheckIsValueForMoney(List<StockDTO> stks)
{
    foreach (var stock in stks)
    {
        if (stock == null)
        {
            continue; 
        }

        if (stock.Price < 20 && stock.Kms >= 0 && stock.Kms < 10000)
        {
            stock.IsValueForMoney = true;
        }
        else
        {
            stock.IsValueForMoney = false;
        }
    }

    return stks;
}


    }
}