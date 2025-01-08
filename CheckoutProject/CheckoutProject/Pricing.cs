using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutProject
{
    public class Pricing : IPricing
    {
        public int CalculatePrice(int quantity, PricingRule rule)
        {
            if (pricingRule.SpecialPrice.HasValue && pricingRule.SpecialPriceQuantity.HasValue)
            {
                totalPrice += (int)((item.Value / pricingRule.SpecialPriceQuantity) * pricingRule.SpecialPrice + (item.Value % pricingRule.SpecialPriceQuantity) * pricingRule.Price);
            }
            else
            {
                totalPrice += item.Value * pricingRule.Price;
            }

        }
    }
}
