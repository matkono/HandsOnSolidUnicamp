namespace AfterChanges
{
    public interface IValidatorService
    {
        public bool IsValidProductOperation(string productOperation);

        public bool IsValidCommandOption(string loopOption);

        public bool IsValidProductId(string productId);

        public bool IsValidProductName(string productName);

        public bool IsValidProductPrice(string productPrice);

        public bool IsValidProductPromotionalAmount(string productAmount);

        public bool IsValidProductPromotionalMonths(string productMonths);

        public bool IsValidProductPromotionalStartDate(string promotionalStartDate);
    }
}
