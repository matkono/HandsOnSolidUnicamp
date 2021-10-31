using AfterChanges.Models;
using AfterChanges.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AfterChanges
{
    public class Program
    {
        public static IValidatorService ValidatorService { get; set; }

        public Program(IValidatorService validatorService) 
        {
            ValidatorService = validatorService;
        }

        static void Main(string[] args)
        {
            SetUpDI();
            var loopChecker = true;
            var productStock = new ProductStock();
            while (loopChecker)
            {
                var productOperationUserOption = GetProductOperationOption();
                ExecuteProductOperation(productStock, productOperationUserOption);

                loopChecker = UpdateLooperChecker();
            }
        }

        private static void SetUpDI() 
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IValidatorService, ValidatorService>()
                .BuildServiceProvider();

            ValidatorService = serviceProvider.GetService<IValidatorService>();
        }

        private static int GetProductOperationOption() 
        {
            var isOptionValid = false;
            var productOperationUserOption = 0;
            while (!isOptionValid) 
            {
                Console.WriteLine("Enter the product operation option: ");
                Console.WriteLine("1 - Add");
                Console.WriteLine("2 - Update");
                Console.WriteLine("3 - Delete");
                Console.WriteLine("4 - Get infos");

                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductOperation(option))
                {
                    isOptionValid = true;
                    productOperationUserOption = int.Parse(option);
                }
            }

            return productOperationUserOption;
        }

        private static void ExecuteProductOperation(ProductStock productStock, int productOperationUserOption) 
        {
            switch (productOperationUserOption)
            {
                case (int)ProductOperationEnum.Add:
                    var productToAdd = BuildProduct();
                    productStock.AddProduct(productToAdd);
                    return;
                case (int)ProductOperationEnum.Update:
                    var productToUpdate = BuildProduct();
                    productStock.UpdateProduct(productToUpdate);
                    return;
                case (int)ProductOperationEnum.Delete:
                    var productIdToDelete = GetProductId();
                    productStock.DeleteProduct(productIdToDelete);
                    return;
                case (int)ProductOperationEnum.GetInformation:
                    var productIdToGetInfo = GetProductId();
                    productStock.GetProductInfo(productIdToGetInfo);
                    return;
            }
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        private static Product BuildProduct() 
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            var productId = GetProductId();
            var productName = GetProductName();
            var productPrice = GetProductPrice();

            var product = new Product(productId, productName, productPrice);

            if (CheckIfProductHasPromotional())
                product.Promotionals = GetProductPromotionals();

            Console.WriteLine("--------------------------------------------------------------------------");
            return product;
        }

        private static int GetProductId() 
        {
            var isOptionValid = false;
            var productId = 0;
            while (!isOptionValid) 
            {
                Console.WriteLine("Enter the product id: ");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductId(option))
                {
                    isOptionValid = true;
                    productId = int.Parse(option);
                }
            }

            return productId;
        }

        private static string GetProductName() 
        {
            var isOptionValid = false;
            var productName = string.Empty;
            while (!isOptionValid) 
            {
                Console.WriteLine("Enter the product name: ");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductName(option)) 
                {
                    isOptionValid = true;
                    productName = option;
                }
            }

            return productName;
        }

        private static int GetProductPrice()
        {
            var isOptionValid = false;
            var productPrice = 0;
            while (!isOptionValid)
            {
                Console.WriteLine("Enter the product price: ");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductPrice(option))
                {
                    isOptionValid = true;
                    productPrice = int.Parse(option);
                }
            }

            return productPrice;
        }

        public static List<Promotional> GetProductPromotionals() 
        {
            var promotionals = new List<Promotional>();
            var promotionalsAmount = GetPromotionalsAmount();
            for (var promotionalCounter = 1; promotionalCounter <= promotionalsAmount; promotionalCounter++)
            {
                var promotional = BuildPromotional(promotionalCounter);
                promotionals.Add(promotional);
            }

            return promotionals;
        }

        private static int GetPromotionalsAmount() 
        {
            var isOptionValid = false;
            var promotionalAmount = 0;
            while (!isOptionValid)
            {
                Console.WriteLine("How many promotionals?");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductPromotionalAmount(option))
                {
                    isOptionValid = true;
                    promotionalAmount = int.Parse(option);
                }
            }

            return promotionalAmount;
        }

        private static Promotional BuildPromotional(int promotionalCounter) 
        {
            var promotionalMonths = GetPromotionalMonths(promotionalCounter);
            var promotionalStartDate = GetPromotionalStartDate(promotionalCounter);
            var promotional = new Promotional(promotionalMonths, promotionalStartDate);

            return promotional;
        }

        private static int GetPromotionalMonths(int promotionalCounter) 
        {
            var isOptionValid = false;
            var promotionalMonths = 0;
            while (!isOptionValid)
            {
                Console.WriteLine($"How many months has the {promotionalCounter}° promotional?");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductPromotionalMonths(option))
                {
                    isOptionValid = true;
                    promotionalMonths = int.Parse(option);
                }
            }

            return promotionalMonths;
        }

        private static DateTime GetPromotionalStartDate(int promotionalCounter)
        {
            var isOptionValid = false;
            var promotionalStartDate = DateTime.UtcNow;
            while (!isOptionValid)
            {
                Console.WriteLine($"When the {promotionalCounter}° promotional starts?");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidProductPromotionalStartDate(option))
                {
                    isOptionValid = true;
                    promotionalStartDate = DateTime.Parse(option);
                }
            }

            return promotionalStartDate;
        }

        private static bool CheckIfProductHasPromotional() 
        {
            var isOptionValid = false;
            var hasProductPromotional = false;
            while (!isOptionValid)
            {
                Console.WriteLine("Does the product have a promotion? ");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidCommandOption(option))
                {
                    isOptionValid = true;
                    hasProductPromotional = int.Parse(option) == (int)CommandOptionEnum.Yes;
                }
            }

            return hasProductPromotional;
        }

        private static bool UpdateLooperChecker() 
        {
            var isOptionValid = false;
            var shouldStopLoop = false;
            while (!isOptionValid) 
            {
                Console.WriteLine("--------------------------------------------------------------------------");
                Console.WriteLine("Do you want to continue operations? ");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                var option = Console.ReadLine();
                if (ValidatorService.IsValidCommandOption(option))
                {
                    isOptionValid = true;
                    shouldStopLoop = int.Parse(option) == (int)CommandOptionEnum.Yes;
                    Console.WriteLine("--------------------------------------------------------------------------");
                }
            }

            return shouldStopLoop;
        }
    }
}
