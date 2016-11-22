     using System;
namespace ConsoleApplication7
{
    public class OrderDemo
    {
        public static void Main()
        {
            Order orderOne = new Order(1100, "Joe Storey", 10);
            Order orderTwo = new Order(1200, "Chris Bauswell", 5);
            Order orderThree = new Order(1100, "Steven Jeffers", 3);
            Console.WriteLine(orderOne.ToString());
            Console.WriteLine(orderTwo.ToString());
            Console.WriteLine(orderThree.ToString());
            CompareNumbers(orderOne, orderTwo);
            CompareNumbers(orderOne, orderThree);
            System.Console.ReadLine();
        }
          static void CompareNumbers(Order orderOne, Order orderTwo)
        {
            if (orderOne.Equals(orderTwo))
                Console.WriteLine("{0} for {1} has the same order " +
                    "number as " + "{2} for {3}",
                    orderOne.OrderNumer, orderOne.Customer,
                    orderTwo.OrderNumer, orderTwo.Customer);
        }

    }
}

