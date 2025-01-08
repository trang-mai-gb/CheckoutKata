using CheckoutProject;
namespace CheckoutTestProject
{
    public class CheckoutTests
    {
        private List<PricingRule> _pricingRules;

        public CheckoutTests() 
        {
            _pricingRules = new List<PricingRule>()
            {
                new PricingRule("A", 50, 130, 3),
                new PricingRule("B", 30, 45, 2),
                new PricingRule("C", 20),
                new PricingRule("D", 15)
            };
        }


        [Fact]
        public void Test1()
        {
            var checkout = new Checkout(_pricingRules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            Assert.Equal(115, checkout.GetTotalPrice());
        }
    }
}