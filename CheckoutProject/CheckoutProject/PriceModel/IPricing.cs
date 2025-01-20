namespace CheckoutProject.PriceModel
{
    public interface IPricing
    {
        public int CalculatePrice(int quantity, PricingRule pricingRule);
    }
}
