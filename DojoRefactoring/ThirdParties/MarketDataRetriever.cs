using System;
using System.Configuration;
using System.Windows.Forms;

namespace DojoRefactoring.ThirdParties
{
    public interface IMarketDataRetriever
    {
        double GetClose(string underlying);
    }

    public class MarketDataRetrieverWrapper : IMarketDataRetriever
    {
        readonly MarketDataRetriever _marketDataRetriever = new MarketDataRetriever();

        public double GetClose(string underlying)
        {
            return _marketDataRetriever.GetClose(underlying);
        }
    }
    class MarketDataRetriever
    {
        public double GetClose(string underlying)
        {
            if (ConfigurationManager.AppSettings["licence"] == null)
            {
                MessageBox.Show("Pas de licence !", "Licence pénible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ConfigurationException();
            }
            return ((double) underlying.GetHashCode() * (new Random()).NextDouble());
        }
    }
}
