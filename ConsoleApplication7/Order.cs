using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Order
    {
        public int _quanity;
        public double _total;
        public const double ItemPrice = 19.95;
        public Order()
        {

        }
        public Order(int ordNum, string cusName, int numOrdered)
        {
            OrderNumer = ordNum;
            Customer = cusName;
            Quanity = numOrdered;
        }

        public int OrderNumer { get; set; }
        public string Customer{get;set;}
        public int Quanity
        {
            get {                
                return _quanity; }
            set
            {
                _quanity = value;
                _total = _quanity * ItemPrice;
              
            }
        }
        public double Total { get { return _total; } }
        public override string ToString()
        {
            return (GetType() + " " + OrderNumer + " " + Customer + " " + Quanity +
                " @" + ItemPrice.ToString("C2") + Total.ToString("C2"));
        }

        public override bool Equals(Object e)
        {
            bool equal;
            Order temp = (Order)e;
            if (OrderNumer == temp.OrderNumer)
                equal = true;
            else
                equal = false;
            return equal;
        }
        public override int GetHashCode()
        {
            return OrderNumer;
        }
    }
}
