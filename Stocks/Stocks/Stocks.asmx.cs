using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Stocks
{
    /// <summary>
    /// Summary description for Stocks
    /// </summary>
    
    //If you want to run it from VS:
    //[WebService(Namespace = "http://localhost:65516//Stocks")]
    //If you want to publish it:
    [WebService(Namespace = "http://localhost//TickerTape")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Stocks : System.Web.Services.WebService
    {
        private const string logFile = "C:\\SOA_A3\\Stocks.txt";

        [WebMethod]
        public QuoteInfo GetQuote(string tickerSymbol)
        {
            myLogging.Write(logFile, "GetQuote() was called. Parameter value(s): " + tickerSymbol);
            QuoteInfo respConverted = new QuoteInfo();

            try
            {
                SerfiveReference.DelayedStockQuote serv = new SerfiveReference.DelayedStockQuote();

                SerfiveReference.QuoteData response = serv.GetQuote(tickerSymbol, 0.ToString());

                respConverted = new QuoteInfo(response.StockSymbol, (double)response.LastTradeAmount, response.LastTradeDateTime.Date.ToString(), response.LastTradeDateTime.TimeOfDay.ToString());

            }
            catch (SoapException ex)
            {
                //throw soap fault: SOAP exception. Message: ex.Message
                myLogging.Write(logFile, "**ERROR**: SOAP exception. Message: " + ex.Message);

            }
            catch (Exception ex)
            {
                //throw soap fault: Unhandeled exception. Message: ex.Message
                myLogging.Write(logFile, "**ERROR**: Unhandeled exception. Message: " + ex.Message);

            }

            return respConverted;
        }
    }
}
