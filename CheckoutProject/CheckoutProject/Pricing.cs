using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

              
                return (int)((quantity / specialPriceQuantity) * specialPrice + (quantity % specialPriceQuantity) * pricingRule.Price);
            }
            else
            {
                return quantity * pricingRule.Price;
            }

        }
    }
}
