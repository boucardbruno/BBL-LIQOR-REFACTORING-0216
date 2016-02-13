using System.Collections.Generic;
using System.Linq;
using DojoRefactoring.ThirdParties;
using NSubstitute;
using NUnit.Framework;

namespace DojoRefactoring
{
    class MassPricerPublisherTests
    {
        private IEnumerable<string> _products;

        [SetUp]
        public void Init()
        {
            _products = new List<string> { "Cacao", "Sucre", "Petrole", "Carcasses de porc", "Or", "Cuivre"}.Where(p => p.StartsWith("C"));
        }

        [Test]
        public void Should_return_underlying_start_with_C_letter()
        {
            var allUnderlyings = MockAllUnderlyings();
            var pricePublicher = MockPricePublicher();

            var marketDataRetriever = Substitute.For<IMarketDataRetriever>();
        
            var productCount = _products.Count(n => n.StartsWith("C"));
           
            var massPricerPublisher = new MassPricerPublisher(allUnderlyings);
            massPricerPublisher.PriceAndPublishEverything(pricePublicher, marketDataRetriever);
            marketDataRetriever.Received(productCount).GetClose(Arg.Any<string>());
        }

        [Test]
        public void Should_publish_products_and_add_of_two_for_each_price()
        {
            var allUnderlyings = MockAllUnderlyings();
            var pricePublicher = MockPricePublicher();
            const int basePrice = 1;
            var marketDataRetriever = MockMarketDataRetriever(basePrice);

            const int addPrice = 2;
            var massPricerPublisher = new MassPricerPublisher(allUnderlyings);
            massPricerPublisher.PriceAndPublishEverything(pricePublicher, marketDataRetriever);
            pricePublicher.Received().Publish(basePrice + addPrice);
        }

        private static IMarketDataRetriever MockMarketDataRetriever(int basePrice)
        {
            var marketDataRetriever = Substitute.For<IMarketDataRetriever>();
            marketDataRetriever.GetClose(Arg.Any<string>()).Returns(basePrice);
            return marketDataRetriever;
        }

        private static IPricePublicher MockPricePublicher()
        {
            var pricePublicher = Substitute.For<IPricePublicher>();
            pricePublicher.Publish(Arg.Any<int>());
            return pricePublicher;
        }

        private AllUnderlyings MockAllUnderlyings()
        {
            var allUnderlyings = Substitute.For<AllUnderlyings>();
            allUnderlyings.GetProducts().Returns(_products);
            return allUnderlyings;
        }
    }
}
