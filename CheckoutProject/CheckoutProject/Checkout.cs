using System.Collections.Concurrent;

namespace CheckoutProject
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, PricingRule> _pricingRules;
        private ConcurrentDictionary<string, int> _scannedItems;
        private IPricing _pricing;

        public Checkout(List<PricingRule> pricingRules, IPricing? pricing = null)
        {
            _pricingRules = pricingRules.ToDictionary(p => p.Sku, p => p);
            _scannedItems = new ConcurrentDictionary<string, int>();
            _pricing = pricing?? new Pricing(); //Option permit change rule for pricing
        }

        public void Scan(string item)
        {
            if (!_pricingRules.ContainsKey(item)) 
            {
                Console.WriteLine($"Item {item} does not found");
                return;
            }
            _scannedItems.AddOrUpdate(item, 1, (item, oldValue) => oldValue + 1);

        }
        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var item in _scannedItems)
            {
                var pricingRule = _pricingRules[item.Key];
                var quantity = item.Value;
                totalPrice += _pricing.CalculatePrice(quantity, pricingRule);
            }

            return totalPrice;

        }
    }
}
