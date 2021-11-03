using System;

namespace AfterChanges.Services
{
    public class ValidatorService : IValidatorService
    {
        public ValidatorService()
        {
        }

        public bool IsValidProductOperation(string productOperation)
        {
            var isProductOperationNumber = int.TryParse(productOperation, out var productOperationAsNumber);
            if (!isProductOperationNumber)
            {
                Console.WriteLine("Product operation option must be an intenger");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            var isOperationSupported = Enum.IsDefined(typeof(ProductOperationEnum), productOperationAsNumber);
            if (!isOperationSupported)
            {
                Console.WriteLine("Product operation option must be between 1 and 4");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }

        public bool IsValidCommandOption(string commandOption)
        {
            var isCommandOptionNumber = int.TryParse(commandOption, out var commandOptionAsNumber);
            if (!isCommandOptionNumber)
            {
                Console.WriteLine("Command option must be an integer");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }
            
            var isValidLoopOption = Enum.IsDefined(typeof(CommandOptionEnum), commandOptionAsNumber);
            if (!isValidLoopOption) 
            {
                Console.WriteLine("Command option must be 1 or 2");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }
            
            return true;
        }

        public bool IsValidProductId(string productId)
        {
            var isProductIdNumber = int.TryParse(productId, out var productIdAsNumber);
            if (!isProductIdNumber)
            {
                Console.WriteLine("Product id must be an integer");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            if (productIdAsNumber <= 0)
            {
                Console.WriteLine("Product id must be greater than 0");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }

        public bool IsValidProductName(string productName)
        {
            if (productName.Length > 30) 
            {
                Console.WriteLine("Product name length must be smaller than 30 caracteres");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }

        public bool IsValidProductPrice(string productPrice)
        {
            var isProductIdNumber = int.TryParse(productPrice, out var productPriceAsNumber);
            if (!isProductIdNumber)
            {
                Console.WriteLine("Product price must be an integer");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            if (productPriceAsNumber <= 0)
            {
                Console.WriteLine("Product price must be greater than 0");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }

        public bool IsValidProductPromotionalAmount(string promotionalAmount)
        {
            var isPromotionalAmountNumber = int.TryParse(promotionalAmount, out var promotionalAmountAsNumber);
            if (!isPromotionalAmountNumber)
            {
                Console.WriteLine("Promotional amount must be an integer");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            if (promotionalAmountAsNumber <= 0 || promotionalAmountAsNumber > 3)
            {
                Console.WriteLine("Promotional amount must be greater than 0 and smaller than 3");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }

        public bool IsValidProductPromotionalMonths(string promotionalMonths)
        {
            var isPromotionalMonthsNumber = int.TryParse(promotionalMonths, out var promotionalMonthsAsNumber);
            if (!isPromotionalMonthsNumber)
            {
                Console.WriteLine("Promotional amount must be an integer");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            if (promotionalMonthsAsNumber <= 0 || promotionalMonthsAsNumber > 24)
            {
                Console.WriteLine("Promotional amount must be greater than 0 and smaller than 24");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }

        public bool IsValidProductPromotionalStartDate(string promotionalStartDate)
        {
            var isPromotionalStartDateDateTime = DateTime.TryParse(promotionalStartDate, out var promotionalStartDateAsDateTime);
            if (!isPromotionalStartDateDateTime)
            {
                Console.WriteLine("Promotional start date must be an DateTime");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            if (DateTime.Compare(promotionalStartDateAsDateTime, DateTime.UtcNow.Date) < 0)
            {
                Console.WriteLine("Promotional start date must be greater than today");
                Console.WriteLine("--------------------------------------------------------------------------");
                return false;
            }

            return true;
        }
    }
}
