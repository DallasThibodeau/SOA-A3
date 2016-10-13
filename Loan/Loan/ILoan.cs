using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Loan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoan" in both code and config file together.
    [ServiceContract]
    public interface ILoan
    {
        [OperationContract]
        float LoanPayment(float principleAmmount, float interestRate, int numPayments);
    }
}
