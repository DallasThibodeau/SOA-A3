using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace Loan
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public float LoanPayment(float principleAmmount, float interestRate, int numPayments)
        {
            float monthlyPay = 0;
            float denominator = (float)Math.Pow(1 + Convert.ToDouble(interestRate), Convert.ToDouble(numPayments)) - 1;

            monthlyPay = interestRate + (interestRate / denominator);
            monthlyPay *= principleAmmount;
            return monthlyPay;
        }
    }
}
