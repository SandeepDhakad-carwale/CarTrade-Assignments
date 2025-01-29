using Cars.BLL.DTOs;
using Cars.BLL.Helpers;
using Xunit;
using System.Collections.Generic;

namespace Cars.BLL.Tests.Helpers
{
    public class StockHelperTests
    {
        [Fact]
        public void CheckIsValueForMoney_ShouldMarkTrue_WhenPriceBelow20AndKmsLessThan10000()
        {
            // Arrange
            var stocks = new List<StockDTO>
            {
                new StockDTO { Price = 15, Kms = 5000 },
                new StockDTO { Price = 18, Kms = 8000 }
            };

            // Act
            var result = StockHelper.CheckIsValueForMoney(stocks);

            // Assert
            Assert.True(result[0].IsValueForMoney);
            Assert.True(result[1].IsValueForMoney);
        }

        [Fact]
        public void CheckIsValueForMoney_ShouldMarkFalse_WhenPriceBelow20AndKmsGreaterThanOrEqualTo10000()
        {
            // Arrange
            var stocks = new List<StockDTO>
            {
                new StockDTO { Price = 15, Kms = 10000 },
                new StockDTO { Price = 18, Kms = 15000 }
            };

            // Act
            var result = StockHelper.CheckIsValueForMoney(stocks);

            // Assert
            Assert.False(result[0].IsValueForMoney);
            Assert.False(result[1].IsValueForMoney);
        }

        [Fact]
        public void CheckIsValueForMoney_ShouldMarkFalse_WhenPriceIs20OrMore()
        {
            // Arrange
            var stocks = new List<StockDTO>
            {
                new StockDTO { Price = 20, Kms = 5000 },
                new StockDTO { Price = 30, Kms = 8000 }
            };

            // Act
            var result = StockHelper.CheckIsValueForMoney(stocks);

            // Assert
            Assert.False(result[0].IsValueForMoney);
            Assert.False(result[1].IsValueForMoney);
        }

        [Fact]
        public void CheckIsValueForMoney_ShouldMarkFalse_WhenKmsAreNegative()
        {
            // Arrange
            var stocks = new List<StockDTO>
            {
                new StockDTO { Price = 15, Kms = -5000 },
                new StockDTO { Price = 10, Kms = -100 }
            };

            // Act
            var result = StockHelper.CheckIsValueForMoney(stocks);

            // Assert
            Assert.False(result[0].IsValueForMoney);
            Assert.False(result[1].IsValueForMoney);
        }

        [Fact]
        public void CheckIsValueForMoney_ShouldSkipNullStocks()
        {
            // Arrange
            var stocks = new List<StockDTO>
            {
                new StockDTO { Price = 15, Kms = 5000 },
                null,  // Null stock
                new StockDTO { Price = 18, Kms = 8000 }
            };

            // Act
            var result = StockHelper.CheckIsValueForMoney(stocks);

            // Assert
            Assert.True(result[0].IsValueForMoney);
            Assert.Null(result[1]);
            Assert.True(result[2].IsValueForMoney);
        }

        [Fact]
        public void CheckIsValueForMoney_ShouldHandleEmptyList()
        {
            // Arrange
            var stocks = new List<StockDTO>();

            // Act
            var result = StockHelper.CheckIsValueForMoney(stocks);

            // Assert
            Assert.Empty(result); 
        }
    }
}
