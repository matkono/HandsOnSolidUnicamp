using System;
using System.Collections.Generic;

namespace AfterChanges
{
    public class ProductStock
    {
        public List<Product> Products { get; set; }

        public ProductStock()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product) 
        {
            var productAlreadyExists = Products.Exists(productInMemory => productInMemory.Id == product.Id);
            if (productAlreadyExists)
                throw new Exception($"The product with Id {product.Id} already exists");

            Console.WriteLine($"Products count in stock before add: {Products.Count}");
            Products.Add(product);
            Console.WriteLine($"Product with Id {product.Id} was added.");
            Console.WriteLine($"Products count in stock after add: {Products.Count}");
        }

        public void UpdateProduct(Product product)
        {
            var productExists = Products.Exists(productInMemory => productInMemory.Id == product.Id);
            if (!productExists)
                throw new Exception($"The product with Id {product.Id} does not exist");

            var productInMemory = Products.Find(pim => pim.Id == product.Id);
            Console.WriteLine($"Product before being updated: {productInMemory.GetInfos()}");
            Products.Remove(productInMemory);
            Products.Add(product);
            Console.WriteLine($"Product after being updated: {product.GetInfos()}");
        }

        public void DeleteProduct(int productId) 
        {
            var productExists = Products.Exists(productInMemory => productInMemory.Id == productId);
            if (!productExists)
                throw new Exception($"The product with Id {productId} does not exist");

            Console.WriteLine($"Products count in stock before delete: {Products.Count}");
            Console.WriteLine($"Product with Id {productId} will be deleted.");
            var productInMemory = Products.Find(pim => pim.Id == productId);
            Products.Remove(productInMemory);
            Console.WriteLine($"Products count in stock after delete: {Products.Count}");
        }

        public void GetProductInfo(int productId) 
        {
            var productExists = Products.Exists(productInMemory => productInMemory.Id == productId);
            if (!productExists)
                throw new Exception($"The product with Id {productId} does not exist");

            var productInMemory = Products.Find(pim => pim.Id == productId);
            Console.WriteLine(productInMemory.GetInfos());
        }
    }
}
