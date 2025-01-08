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

        public Checkout(List<PricingRule> pricingRules)
        {
            _pricingRules = pricingRules.ToDictionary(p => p.Sku, p => p);
            _scannedItems = new Dictionary<string, int>();
        }

        void Scan(string item)
        {
            if (!_pricingRules.ContainsKey(item)) 
            {
                throw new Exception($"Item {item} not found.");
            }
            if (_scannedItems.ContainsKey(item)) 
            { 
                // Increase number of scannedItem
                _scannedItems[item]++;
            }
            else 
            {
                //Start new scannedItem
                _scannedItems[item] = 1;
            }

        }
        int GetTotalPrice()
        {

        }
    }
}
