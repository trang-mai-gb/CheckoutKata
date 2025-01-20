namespace CheckoutProject
{
    public class PricingRule
    {
        public string Sku { get; set; }
        public int Price { get; set; }
        public int? SpecialPrice { get; set; }
        public int? SpecialPriceQuantity { get; set; }

        public PricingRule(string sku, int price, int? specialPrice = null, int? specialPriceQuantity = null) 
        {
            Sku = sku;
            Price = price;
            SpecialPrice = specialPrice;
            SpecialPriceQuantity = specialPriceQuantity;
        }
    }
}
