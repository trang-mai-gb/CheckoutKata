namespace CheckoutProject
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, PricingRule> _pricingRules;
        private Dictionary<string, int> _scannedItems;
        private IPricing _pricing;

        public Checkout(List<PricingRule> pricingRules, IPricing pricing = null)
        {
            _pricingRules = pricingRules.ToDictionary(p => p.Sku, p => p);
            _scannedItems = new Dictionary<string, int>();
            _pricing = pricing?? new Pricing(); //Option permit change rule for pricing
        }

        public void Scan(string item)
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
