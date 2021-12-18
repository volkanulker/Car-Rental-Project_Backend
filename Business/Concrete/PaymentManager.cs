using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult isPaymentInfoCorrect(CreditCard creditCard)
        {
            return new SuccessResult(">> Credit Card info is correct.");
        }
    }
}
