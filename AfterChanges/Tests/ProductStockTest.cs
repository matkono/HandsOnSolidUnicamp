using FluentAssertions;
using System;
using Xunit;
using Promotional = AfterChanges.Models.Promotional;

namespace AfterChanges.Tests
{
    public class ProductStockTest
    {
        [Fact]
        public static void AddProductShouldThrowAnException() 
        {
            //Arrange
            var product = new Product(1, "Test", 100);
            var productStock = new ProductStock();
            productStock.AddProduct(product);

            //Action
            Action action = () => productStock.AddProduct(product);

            //Assert
            action.Should().ThrowExactly<Exception>().WithMessage($"The product with Id {product.Id} already exists");
        }

        [Fact]
        public static void AddProductShouldBeSuccessful()
        {
            //Arrange
            var product = new Product(1, "Test", 100);
            product.AddPromotional(new Promotional(1, DateTime.UtcNow));
            var productStock = new ProductStock();

            //Action
            var productAdded = productStock.AddProduct(product);

            //Assert
            productAdded.Id.Should().Be(product.Id);
            productAdded.Name.Should().Be(product.Name);
            productAdded.Price.Should().Be(product.Price);
        }

        [Fact]
        public void UpdateProductShouldThrowAnException() 
        {
            //Arrange
            var product = new Product(1, "Test", 100);
            var productStock = new ProductStock();

            //Action
            Action action = () => productStock.UpdateProduct(product);

            //Assert
            action.Should().ThrowExactly<Exception>().WithMessage($"The product with Id {product.Id} does not exist");
        }

        [Fact]
        public static void UpdateProductShouldBeSuccessful()
        {
            //Arrange
            var product = new Product(1, "Test", 100);
            var productStock = new ProductStock();
            productStock.AddProduct(product);
            product.ChangeName("Test 2");

            //Action
            var productUpdated = productStock.UpdateProduct(product);

            //Assert
            productUpdated.Name.Should().Be(product.Name);
        }

        [Fact]
        public static void DeleteProductShouldThrowAnException() 
        {
            //Arrange
            var productId = 1;
            var productStock = new ProductStock();

            //Action
            Action action = () => productStock.DeleteProduct(productId);

            //Assert
            action.Should().ThrowExactly<Exception>().WithMessage($"The product with Id {productId} does not exist");
        }

        [Fact]
        public static void DeleteProductShouldBeSuccessful()
        {
            //Arrange
            var productId = 1;
            var product = new Product(productId, "Test", 100);
            var productStock = new ProductStock();
            productStock.AddProduct(product);

            //Action
            var isSuccessful = productStock.DeleteProduct(product.Id);

            //Assert
            isSuccessful.Should().BeTrue();
        }

        [Fact]
        public static void GetProductInfoShouldThrowAnException()
        {
            //Arrange
            var productId = 1;
            var productStock = new ProductStock();

            //Action
            Action action = () => productStock.GetProductInfo(productId);

            //Assert
            action.Should().ThrowExactly<Exception>().WithMessage($"The product with Id {productId} does not exist");
        }

        [Fact]
        public static void GetProductInfoShouldBeSuccessful()
        {
            //Arrange
            var product = new Product(1, "Test", 100);
            product.AddPromotional(new Promotional(1, DateTime.UtcNow));
            var productStock = new ProductStock();
            productStock.AddProduct(product);

            //Action
            var productInfo = productStock.GetProductInfo(product.Id);

            //Assert
            productInfo.Should().NotBeNullOrWhiteSpace();
        }
    }
}
