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
        public void Scan_AllItems_ReturnCorrectPrice()
        {
            var checkout = new Checkout(_pricingRules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("C");
            checkout.Scan("D");

            Assert.Equal(115, checkout.GetTotalPrice());
        }

        [Fact]
        public void Scan_ItemManyTime_ReturnCorrectPrice()
        {
            var checkout = new Checkout(_pricingRules);
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");
            checkout.Scan("B");
            checkout.Scan("A");

            Assert.Equal(175, checkout.GetTotalPrice());
        }

        [Fact]
        public void Scan_EmptyItem_ReturnZeroPrice()
        {
            var checkout = new Checkout(_pricingRules);

            Assert.Equal(0, checkout.GetTotalPrice());
        }

        [Fact]
        public void Scan_UnknowItem_ReturnCorrectMessage()
        {
            //Arrage
            var item = "T";
            var checkout = new Checkout(_pricingRules);
            var output = new StringWriter();
            Console.SetOut(output);

            //Act 
            checkout.Scan(item);

            //Assert
            Assert.Equal($"Item {item} does not found\r\n", output.ToString());
         
        }
    }
}