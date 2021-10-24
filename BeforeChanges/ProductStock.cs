using System;
using System.Collections.Generic;

namespace BeforeChanges
{
    public class ProductStock
    {
        public List<Product> Products { get; set; }

        public ProductStock() 
        {
            Products = new List<Product>();
        }

        public void ManageProduct(Product product, int operationType) 
        {
            var productInMemory = Products.Find(pim => pim.Id == product.Id);

            if (operationType == 4) 
            {
                Console.WriteLine(productInMemory.GetInfos());
                return;
            }
            
            if (operationType == 3)
            {
                Console.WriteLine($"Products count in stock before delete: {Products.Count}");
                Console.WriteLine($"Product with Id {productInMemory.Id} will be deleted.");
                Products.Remove(productInMemory);
                Console.WriteLine($"Products count in stock after delete: {Products.Count}");
                return;
            }

            if (productInMemory == null) 
            {
                Console.WriteLine($"Products count in stock before add: {Products.Count}");
                Console.WriteLine($"Product with Id {product.Id} was added.");
                Products.Add(product);
                productInMemory = product;
                Console.WriteLine($"Products count in stock after add: {Products.Count}");
            }
            
            Console.WriteLine($"Product before being updated: {productInMemory.GetInfos()}");
            Products.Remove(productInMemory);
            Products.Add(product);
            Console.WriteLine($"Product after being updated: {product.GetInfos()}");
        }
    }
}
