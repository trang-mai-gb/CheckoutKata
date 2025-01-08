using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutProject
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, PricingRule> _pricingRules;
        private Dictionary<string, int> _scannedItems;

        public Checkout(Dictionary<string, PricingRule> pricingRules)
        {
            _pricingRules = pricingRules;
            _scannedItems = new Dictionary<string, int>();
        }

        void Scan(string item)
        {

        }
        int GetTotalPrice()
        {

        }
    }
}
