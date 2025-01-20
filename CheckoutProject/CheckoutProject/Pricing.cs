namespace CheckoutProject
{
    public class Pricing : IPricing
    {
        public int CalculatePrice(int quantity, PricingRule pricingRule)
        {
            if (pricingRule.SpecialPrice.HasValue && pricingRule.SpecialPriceQuantity.HasValue)
            {
                var specialPrice = pricingRule.SpecialPrice.Value;
                var specialPriceQuantity = pricingRule.SpecialPriceQuantity.Value;

              
                return (quantity / specialPriceQuantity) * specialPrice + (quantity % specialPriceQuantity) * pricingRule.Price;
            }
            else
            {
                return quantity * pricingRule.Price;
            }

        }
    }
}
