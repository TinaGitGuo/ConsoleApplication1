using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog el = new EventLog();

            try

            {

                // Create the source, if it does not already exist.

                if (!EventLog.SourceExists("SourceName"))

                {

                    if (EventLog.Exists("logName"))

                    {

                        el.Log = "logName";

                    }

                    else

                    {

                        EventLog.CreateEventSource("SourceName"," logName");

                    }

                }

                el.Source =" SourceName";

                EventLog.WriteEntry("LogText"," string");

            }

            catch (Exception ex)

            {

                el.WriteEntry(ex.Message, EventLogEntryType.Error);

            }

        }
    }
}
