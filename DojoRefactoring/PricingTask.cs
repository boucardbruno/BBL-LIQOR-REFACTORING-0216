using DojoRefactoring.ThirdParties;

namespace DojoRefactoring
{
    class PricingTask
    {
        private readonly IMarketDataRetriever _marketMarketDataRetriever;
        private readonly IPricePublicher _pricePublicher;

        public PricingTask(IMarketDataRetriever marketMarketDataRetriever)
        {
            _marketMarketDataRetriever = marketMarketDataRetriever;
        }

        public PricingTask():this(new MarketDataRetrieverWrapper(), new PricePublisherWapper())
        {
        }

        public PricingTask(IMarketDataRetriever marketMarketDataRetriever, IPricePublicher pricePublicher) : this(marketMarketDataRetriever)
        {
             _marketMarketDataRetriever = marketMarketDataRetriever;
            _pricePublicher = pricePublicher;
        }

        public void PriceAndPublish(string underlying)
        {
            double yesterdayPrice = _marketMarketDataRetriever.GetClose(underlying);
            //FIXME en fait, ça devrait être + 2 et non pas + 1
            //double todayPrice = yesterdayPrice + 1;     
            double todayPrice = yesterdayPrice + 2;     
            _pricePublicher.Publish(todayPrice);
        }
    }
}
