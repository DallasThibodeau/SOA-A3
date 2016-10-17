using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

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
            float denominator = (float)Math.Pow(1 + Convert.ToDouble(interestRate), Convert.ToDouble(numPayments)) - 1;

            monthlyPay = interestRate + (interestRate / denominator);
            monthlyPay *= principleAmmount;
            return monthlyPay;
        }
    }
}
