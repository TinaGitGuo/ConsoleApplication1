using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!EventLog.SourceExists("SourceName"))
                {
                    //creating 
                    EventLog.CreateEventSource("SourceName", "Logname");

                }
                EventLog.WriteEntry("SourceName", "Test Log", EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            Console.ReadKey();
        }
    }
}
