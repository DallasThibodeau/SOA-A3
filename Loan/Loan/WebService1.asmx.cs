using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace Loan
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    
    //If you want to run it from VS:
    //[WebService(Namespace = "http://localhost:64879//Loan")]
    //If you want to publish it:
    [WebService(Namespace = "http://localhost//VinniesLoanService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : System.Web.Services.WebService
    {
        private const string logFile = "C:\\SOA_A3\\Loan.txt";

        [WebMethod]
        public float LoanPayment(float principleAmmount, float interestRate, int numPayments)
        {
            myLogging.Write(logFile, "LoanPayment() was called. Parameter value(s): " + principleAmmount + ", " + interestRate + ", " + numPayments);
            float monthlyPay = 0;
            float rate = interestRate / 1200;
            float denominator = (float)Math.Pow(1 + Convert.ToDouble(rate), Convert.ToDouble(numPayments)) - 1;

            if(principleAmmount < 0)
            {
                //throw soap fault: Invalid value for parameter: principleAmmount. Must be positive
                myLogging.Write(logFile, "**ERROR**: Invalid value for parameter 'principleAmmount'");
                throw new SoapException("**ERROR**: Invalid value for parameter 'principleAmmount'", SoapException.ClientFaultCode);

            }
            if(numPayments <= 0)
            {
                //throw soap fault: Invalid value for parameter: numPayments. Must be greater than 0
                myLogging.Write(logFile, "**ERROR**: Invalid value for parameter 'numPayments'");
                throw new SoapException("**ERROR**: Invalid value for parameter 'numPayments'", SoapException.ClientFaultCode);

            }

            try
            {
                monthlyPay = rate + (rate / denominator);
                monthlyPay *= principleAmmount;
            }
            catch(Exception ex)
            {
                myLogging.Write(logFile, "**ERROR**: Unhandeled exception. Message: " + ex.Message);
                throw new SoapException("**ERROR**: Unhandeled exception. Message: " + ex.Message, SoapException.ClientFaultCode);
            }

            return monthlyPay;
        }
    }
}
