using System;
using System.Collections.Generic;

namespace HM.Source.payment
{
    public class PaymentFactory
    {
        public static List<Payment> producePayments() {
            List<Payment> payments = new List<Payment>();
            Payment a = new Payment
            {
                title = "Electricity Bill",
                name = "Origin Electricity Company",
                amount = 234.56,
                date = "08-09-2018",
                BSBNumber = "123456",
                account = "12313211"
            };
            payments.Add(a);
            return payments;
        }
    }
}
