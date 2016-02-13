using DojoRefactoring.ThirdParties;

namespace DojoRefactoring
{
    /// <summary>
    /// Cette classe est utilisée par d'autres. Il ne faut pas casser la compatibilité
    /// </summary>
    public class MassPricerPublisher
    {
        private readonly AllUnderlyings _allUnderlyings;
        // Parametrized Constructor
        public MassPricerPublisher():this(new AllUnderlyings())
        {
        }

        public MassPricerPublisher(AllUnderlyings allUnderlyings)
        {
            _allUnderlyings = allUnderlyings;
        }
        // Parametrized Method
        public void PriceAndPublishEverything()
        {
            PriceAndPublishEverything(new PricePublisherWapper(), new MarketDataRetrieverWrapper());
        }
        public void PriceAndPublishEverything(IPricePublicher pricePublicher, IMarketDataRetriever marketDataRetriever)
        {
            var underlyings = Perimeter.GetPerimeter(_allUnderlyings);
            foreach (var underlying in underlyings)
            {
                var pricingTask = new PricingTask(marketDataRetriever, pricePublicher);
                pricingTask.PriceAndPublish(underlying);
            }
        }
    }
}
