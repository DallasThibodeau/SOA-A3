using System;
using System.Collections.Generic;
using System.Web;

namespace Stocks
{
    public class QuoteInfo
    {
        public string symbol;
        public double LastPrice;
        public string LastPriceDate;
        public string LastPriceTime;

        public QuoteInfo()
        {
            symbol = null;
            LastPrice = 0;
            LastPriceDate = null;
            LastPriceTime = null;
        }

        public QuoteInfo(string nSymbol, double nLP, string nLPD, string nLPT)
        {
            symbol = nSymbol;
            LastPrice = nLP;
            LastPriceDate = nLPD;
            LastPriceTime = nLPT;
        }
    }
}