using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Stocks
{
    /// <summary>
    /// Summary description for Stocks
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    [WebService(Namespace = "http://localhost:65516//Stocks")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Stocks : System.Web.Services.WebService
    {
        private const string logFile = "C:\\SOA_A3\\Stocks.txt";

        [WebMethod]
        public QuoteInfo GetQuote(string tickerSymbol)
        {
            myLogging.Write(logFile, "GetQuote() was called. Parameter value(s): " + tickerSymbol);
            //tickerSymbol = "gg";
            SerfiveReference.DelayedStockQuote serv = new SerfiveReference.DelayedStockQuote();

            SerfiveReference.QuoteData response = serv.GetQuote(tickerSymbol, 0.ToString());

            QuoteInfo respConverted = new QuoteInfo(response.StockSymbol, (double)response.LastTradeAmount, response.LastTradeDateTime.Date.ToString(), response.LastTradeDateTime.TimeOfDay.ToString());
            
            return respConverted;
        }
    }
}
