using Cars.BLL.Helpers;
using Cars.Domains.Enums;
using Xunit;

namespace Cars.Tests
{
    public class QueryHelpersTests
    {
        [Fact]
        public void ParseFuelQuery_ShouldReturnAll_WhenQueryIsNullOrEmpty()
        {
            // Arrange
            string? fuelQuery = null;

            // Act
            var result = QueryHelpers.ParseFuelQuery(fuelQuery);

            // Assert
            Assert.Single(result);
            Assert.Contains(FuelType.All, result);
        }


        [Fact]
        public void ParseBudgetRange_ShouldReturnDefault_WhenQueryIsNullOrEmpty()
        {
            // Arrange
            string? budget = null;

            // Act
            var result = QueryHelpers.ParseBudgetRange(budget);

            // Assert
            Assert.Equal(0, result.MinBudget);
            Assert.Equal(int.MaxValue, result.MaxBudget);
        }

        [Fact]
        public void ParseBudgetRange_ShouldReturnParsedRange_WhenValidQueryIsGiven()
        {
            // Arrange
            string budget = "10000-20000";

            // Act
            var result = QueryHelpers.ParseBudgetRange(budget);

            // Assert
            Assert.Equal(10000, result.MinBudget);
            Assert.Equal(20000, result.MaxBudget);
        }

        [Fact]
        public void ParseBudgetRange_ShouldReturnDefault_WhenInvalidRangeIsGiven()
        {
            // Arrange
            string budget = "invalid-range";

            // Act
            var result = QueryHelpers.ParseBudgetRange(budget);

            // Assert
            Assert.Equal(0, result.MinBudget);
            Assert.Equal(int.MaxValue, result.MaxBudget);
        }

        [Fact]
        public void ParseBudgetRange_ShouldReturnDefault_WhenMinIsGreaterThanMax()
        {
            // Arrange
            string budget = "30000-10000";

            // Act
            var result = QueryHelpers.ParseBudgetRange(budget);

            // Assert
            Assert.Equal(0, result.MinBudget);
            Assert.Equal(int.MaxValue, result.MaxBudget);
        }
    }
}
