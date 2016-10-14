using System.Runtime.Serialization;

namespace Stocks
{
    [DataContract]
    public class QuoteInfo
    {
        public string symbol;
        public double LastPrice;
        public string LastPriceDate;
        public string LastPriceTime;

        public QuoteInfo (string nSymbol, double nLP, string nLPD, string nLPT)
        {
            symbol = nSymbol;
            LastPrice = nLP;
            LastPriceDate = nLPD;
            LastPriceTime = nLPT;
        }
    }

}