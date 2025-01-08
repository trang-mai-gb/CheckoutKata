using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutProject
{
    public interface IPricing
    {
        public int CalculatePrice(int quantity, PricingRule pricingRule);
    }
}
