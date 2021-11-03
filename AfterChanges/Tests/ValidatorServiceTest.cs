using AfterChanges.Services;
using FluentAssertions;
using System;
using Xunit;

namespace AfterChanges.Tests
{
    public class ValidatorServiceTest
    {
        [Fact]
        public static void IsValidProductOperationShouldReturnsFalse() 
        {
            //Arrange
            var productOperation = "5";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductOperation = validatorServiceStub.IsValidProductOperation(productOperation);

            //Assert
            isValidProductOperation.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductOperationShouldReturnsTrue()
        {
            //Arrange
            var productOperation = "1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductOperation = validatorServiceStub.IsValidProductOperation(productOperation);

            //Assert
            isValidProductOperation.Should().BeTrue();
        }

        [Fact]
        public static void IsValidCommandOptionShouldReturnsFalse()
        {
            //Arrange
            var commandOption = "3";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidCommandOption = validatorServiceStub.IsValidCommandOption(commandOption);

            //Assert
            isValidCommandOption.Should().BeFalse();
        }

        [Fact]
        public static void IsValidCommandOptionShouldReturnsTrue()
        {
            //Arrange
            var commandOption = "1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidCommandOption = validatorServiceStub.IsValidCommandOption(commandOption);

            //Assert
            isValidCommandOption.Should().BeTrue();
        }

        [Fact]
        public static void IsValidProductIdShouldReturnsFalse()
        {
            //Arrange
            var productId = "-1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductId = validatorServiceStub.IsValidProductId(productId);

            //Assert
            isValidProductId.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductIdShouldReturnsTrue()
        {
            //Arrange
            var productId = "1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductId = validatorServiceStub.IsValidProductId(productId);

            //Assert
            isValidProductId.Should().BeTrue();
        }

        [Fact]
        public static void IsValidProductNameShouldReturnsFalse()
        {
            //Arrange
            var productName = "Product name test should returns false because lenght is greater than allowed.";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductName = validatorServiceStub.IsValidProductName(productName);

            //Assert
            isValidProductName.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductNameShouldReturnsTrue()
        {
            //Arrange
            var productName = "Prodct name allowed";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductName = validatorServiceStub.IsValidProductName(productName);

            //Assert
            isValidProductName.Should().BeTrue();
        }

        [Fact]
        public static void IsValidProductPriceShouldReturnsFalse()
        {
            //Arrange
            var oroductPrice = "-1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProdcutPrice = validatorServiceStub.IsValidProductPrice(oroductPrice);

            //Assert
            isValidProdcutPrice.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductPriceShouldReturnsTrue()
        {
            //Arrange
            var productPrice = "100";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProducPrice = validatorServiceStub.IsValidProductPrice(productPrice);

            //Assert
            isValidProducPrice.Should().BeTrue();
        }

        [Fact]
        public static void IsValidProductPromotionalAmountShouldReturnsFalse()
        {
            //Arrange
            var productPromotionalAmount = "4";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductPromotionalAmount = validatorServiceStub.IsValidProductPromotionalAmount(productPromotionalAmount);

            //Assert
            isValidProductPromotionalAmount.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductPromotionalAmountShouldReturnsTrue()
        {
            //Arrange
            var productPromotionalAmount = "1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductPromotionalAmount = validatorServiceStub.IsValidProductPromotionalAmount(productPromotionalAmount);

            //Assert
            isValidProductPromotionalAmount.Should().BeTrue();
        }

        [Fact]
        public static void IsValidProductPromotionalMonthsShouldReturnsFalse()
        {
            //Arrange
            var productPromotionalMonths = "25";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductPromotionalMonths = validatorServiceStub.IsValidProductPromotionalMonths(productPromotionalMonths);

            //Assert
            isValidProductPromotionalMonths.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductPromotionalMonthsShouldReturnsTrue()
        {
            //Arrange
            var productPromotionalMonths = "1";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductPromotionalMonths = validatorServiceStub.IsValidProductPromotionalMonths(productPromotionalMonths);

            //Assert
            isValidProductPromotionalMonths.Should().BeTrue();
        }

        [Fact]
        public static void IsValidProductPromotionalStartDateShouldReturnsFalse()
        {
            //Arrange
            var productPromotionalStartDate = "10/10/2021";
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductPromotionalStartDate = validatorServiceStub.IsValidProductPromotionalStartDate(productPromotionalStartDate);

            //Assert
            isValidProductPromotionalStartDate.Should().BeFalse();
        }

        [Fact]
        public static void IsValidProductPromotionalStartDateShouldReturnsTrue()
        {
            //Arrange
            var productPromotionalStartDate = DateTime.UtcNow.ToString();
            var validatorServiceStub = new ValidatorService();

            //Action
            var isValidProductPromotionalStartDate = validatorServiceStub.IsValidProductPromotionalStartDate(productPromotionalStartDate);

            //Assert
            isValidProductPromotionalStartDate.Should().BeTrue();
        }
    }
}
