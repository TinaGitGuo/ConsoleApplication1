using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Class1
    {
        public static void Main()

        {
            //Create an array of five ShippedOrder objects. 
            Order[] myShippedOrder = new Order[2];


            //Prompt the user for values for each Orders object; do NOT allow duplicate order numbers and force the user to reenter 
            //    the order when a duplicate order number is entered.

            //Input
            ToInput(myShippedOrder);

            //Output
            ToOutput(myShippedOrder);

            //Total
            double total=0;
            total=Sum(myShippedOrder);
            Console.WriteLine(myShippedOrder.Length+" orders ' total is "+total);

            Console.ReadKey();
        }
        static void ToOutput(Order[] order)
        {
             for (int x = 0; x< order.Length; x++)
            {
                Console.WriteLine("order number:" + order[x].OrderNumer + "   customer name:" + order[x].Customer + "   quantity:" + order[x].Quanity);
            }
        }       
        static void ToInput(Order[] order)
        {
            bool wronginput = false;
            for (int x = 0; x < order.Length; x++)
            {
                order[x] = new Order();
                int OrderNumer;
                Console.WriteLine("Please enter the order number for order {0}:  ", x + 1);
                while (!int.TryParse(Console.ReadLine(), out OrderNumer)) {
                    Console.WriteLine("Please enter an integer");
                }
                
                wronginput = ToCompare(order, OrderNumer);
                while (wronginput)
                {
                    Console.WriteLine("Please enter the order number for order {0}:  ", x + 1);
                    OrderNumer = Convert.ToInt32(Console.ReadLine());
                    wronginput = ToCompare(order, OrderNumer);
                }
                order[x].OrderNumer = OrderNumer;

                Console.WriteLine("Please enter the customer name for order {0}:  ", x + 1);
                order[x].Customer = Console.ReadLine();

                Console.WriteLine("Please enter the quantity that was ordered for order {0}:  ", x + 1);
                order[x].Quanity = Convert.ToInt32(Console.ReadLine());
            }
        }
        static bool ToCompare(Order[] order,int OrderNumer)
        {
            bool wronginput = false;
            if (order != null && OrderNumer > 0)
            {
                for (int y = 0; y < order.Length; y++)
                {
                    if (order[y] != null && order[y].OrderNumer == OrderNumer)
                    {
                        Console.WriteLine("Sorry, this order number has already been entered, please try again");
                        wronginput = true;
                        break;
                    }
                }
            }           
            return wronginput;
        }
        static double Sum(Order[] order)
        {
            double total = 0;
            for (int x = 0; x < order.Length; x++)
            {
                total += order[x].Total;
            }
            return total;
        }
    }
}
