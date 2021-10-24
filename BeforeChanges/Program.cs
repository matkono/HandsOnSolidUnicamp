using BeforeChanges;
using System;
using System.Collections.Generic;

namespace HandsOnSolidUnicamp
{
    class Program
    {
        static void Main(string[] args)
        {
            var loopChecker = true;
            var productStock = new ProductStock();
            while (loopChecker) 
            {
                Console.WriteLine("Enter the operation product type: ");
                Console.WriteLine("1 - Add");
                Console.WriteLine("2 - Update");
                Console.WriteLine("3 - Delete");
                Console.WriteLine("4 - Get infos");
                var userOption = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the product id: ");
                var productId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the product name: ");
                var productName = Console.ReadLine();

                Console.WriteLine("Enter the product price: ");
                var productPrice = int.Parse(Console.ReadLine());

                Console.WriteLine("Does the product have a promotion? ");
                var promotionalChecker = Console.ReadLine().ToUpper().Equals("SIM");
                var promotionals = new List<Tuple<int, DateTime>>();
                if (promotionalChecker) 
                {
                    Console.WriteLine("How many promotionals?");
                    var promotionalsCount = int.Parse(Console.ReadLine());
                    for (var promotionalCounter = 1; promotionalCounter <= promotionalsCount; promotionalCounter++) 
                    {
                        Console.WriteLine($"How many months has the {promotionalCounter}° promotional?");
                        var promotionalMonths = int.Parse(Console.ReadLine());
                        Console.WriteLine($"When the {promotionalCounter}° promotional starts?");
                        var promotionalStartDate = DateTime.Parse(Console.ReadLine());
                        var promotional = new Tuple<int, DateTime>(promotionalMonths, promotionalStartDate);
                        promotionals.Add(promotional);
                    }
                }

                var product = new Product(productId, productName, productPrice, promotionals);
                productStock.ManageProduct(product, userOption);
           
                Console.WriteLine("Do you want to continue operations? ");
                var shouldStopLoop = Console.ReadLine().ToUpper().Equals("NAO");
                if (shouldStopLoop)
                    loopChecker = false;
            }
        }
    }
}
