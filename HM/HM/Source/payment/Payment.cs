using System;
namespace HM.Source.payment
{
    public class Payment : Java.Lang.Object, IPaymentTitle, Java.IO.ISerializable
    {
        public String name;
        public double amount;
        public String date;
        public String BSBNumber;
        public String account;
        public String title;

        public string getTitle()
        {
            return title;
        }

        public Payment() {

        }
    }
}
