using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Tina\OneDrive\New Text Document.txt"))
            {
                string line = reader.ReadLine();
                while (line != "" && line != null)
                {                  
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
            Console.ReadKey();
       }
    }
}
