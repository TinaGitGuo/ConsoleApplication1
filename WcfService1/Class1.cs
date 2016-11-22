using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.ServiceReference1;

namespace WcfService1
{
    
   static class Test
    {
        static void Main()
        {
            Service1Client client = new Service1Client();

            // Use the 'client' variable to call operations on the service.

            // Always close the client.

           Console.WriteLine(  client.ToGetJSon());
            client.Close();

            Console.ReadKey();
        }
    }

}