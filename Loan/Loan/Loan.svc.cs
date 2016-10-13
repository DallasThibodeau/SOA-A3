using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Loan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Loan" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Loan.svc or Loan.svc.cs at the Solution Explorer and start debugging.
    public class Loan : ILoan
    {
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
