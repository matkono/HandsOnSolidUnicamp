using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace BeforeChanges
{
    public class ProductStockTest
    {
        [Fact]
        public void ManageProductShouldGetInfo() 
        {
            //Arrange
            var operation = 4;

            var promotionals = new List<Tuple<int, DateTime>>();
            var promotional = new Tuple<int, DateTime>(1, DateTime.UtcNow);
            promotionals.Add(promotional);

            var product = new Product(1, "Test", 100, promotionals);
            var products = new List<Product>();
            products.Add(product);

            var productStock = new ProductStock();
            productStock.Products = products;

            //Action
            var tupleReturned = productStock.ManageProduct(product, operation);

            //Asserts
            tupleReturned.Item2.Should().Be(operation);
            tupleReturned.Item1.Id.Should().Be(product.Id);
            tupleReturned.Item1.Name.Should().Be(product.Name);
            tupleReturned.Item1.Price.Should().Be(product.Price);
            tupleReturned.Item1.Promotionals.Count.Should().Be(product.Promotionals.Count);
        }

        [Fact]
        public void ManageProductShouldDelete()
        {
            //Arrange
            var operation = 3;

            var promotionals = new List<Tuple<int, DateTime>>();
            var promotional = new Tuple<int, DateTime>(1, DateTime.UtcNow);
            promotionals.Add(promotional);

            var product = new Product(1, "Test", 100, promotionals);
            var products = new List<Product>();
            products.Add(product);

            var productStock = new ProductStock();
            productStock.Products = products;

            //Action
            var tupleReturned = productStock.ManageProduct(product, operation);

            //Asserts
            tupleReturned.Item2.Should().Be(operation);
            tupleReturned.Item1.Id.Should().Be(product.Id);
            tupleReturned.Item1.Name.Should().Be(product.Name);
            tupleReturned.Item1.Price.Should().Be(product.Price);
            tupleReturned.Item1.Promotionals.Count.Should().Be(product.Promotionals.Count);
        }

        [Fact]
        public void ManageProductShouldUpdate()
        {
            //Arrange
            var operation = 2;

            var promotionals = new List<Tuple<int, DateTime>>();
            var promotional = new Tuple<int, DateTime>(1, DateTime.UtcNow);
            promotionals.Add(promotional);

            var product = new Product(1, "Test", 100, promotionals);
            var products = new List<Product>();
            products.Add(product);

            var productStock = new ProductStock();
            productStock.Products = products;

            //Action
            var tupleReturned = productStock.ManageProduct(product, operation);

            //Asserts
            tupleReturned.Item2.Should().Be(operation);
            tupleReturned.Item1.Id.Should().Be(product.Id);
            tupleReturned.Item1.Name.Should().Be(product.Name);
            tupleReturned.Item1.Price.Should().Be(product.Price);
            tupleReturned.Item1.Promotionals.Count.Should().Be(product.Promotionals.Count);
        }

        [Fact]
        public void ManageProductShouldAdd()
        {
            //Arrange
            var operation = 1;

            var promotionals = new List<Tuple<int, DateTime>>();
            var promotional = new Tuple<int, DateTime>(1, DateTime.UtcNow);
            promotionals.Add(promotional);

            var product = new Product(1, "Test", 100, promotionals);
            var products = new List<Product>();

            var productStock = new ProductStock();
            productStock.Products = products;

            //Action
            var tupleReturned = productStock.ManageProduct(product, operation);

            //Asserts
            tupleReturned.Item2.Should().Be(operation);
            tupleReturned.Item1.Id.Should().Be(product.Id);
            tupleReturned.Item1.Name.Should().Be(product.Name);
            tupleReturned.Item1.Price.Should().Be(product.Price);
            tupleReturned.Item1.Promotionals.Count.Should().Be(product.Promotionals.Count);
        }
    }
}
