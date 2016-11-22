using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        
        static void Method(ref int i)
        {
            // Rest the mouse pointer over i to verify that it is an int.
            // The following statement would cause a compiler error if i
            // were boxed as an object.
            i = i + 44;
        }

        static void Main()
        {
            int val = 1;
           // Method(  val);
            Console.WriteLine(val);

            // Output: 45
        }
    }
}
