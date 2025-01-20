namespace CheckoutProject
{
    public interface IPricing
    {
        public int CalculatePrice(int quantity, PricingRule pricingRule);
    }
}
