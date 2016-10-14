using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Stocks
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Stocks" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Stocks.svc or Stocks.svc.cs at the Solution Explorer and start debugging.
    public class Stocks : IStocks
    {
        public QuoteInfo GetQuote(string tickerSymbol)
        {
            StockService.DelayedStockQuote serv = new StockService.DelayedStockQuote();

            StockService.QuoteData response = serv.GetQuote(tickerSymbol, 0.ToString());

            QuoteInfo respConverted = new QuoteInfo(response.StockSymbol, (double)response.LastTradeAmount, response.LastTradeDateTime.Date.ToString(), response.LastTradeDateTime.TimeOfDay.ToString());

            return respConverted;
        }
    }
}
