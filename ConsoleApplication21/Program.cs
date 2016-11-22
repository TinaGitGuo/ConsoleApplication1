using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {

          

        ////Calendar.GetWeekOfYear(DateTime time, CalendarWeekRule rule, DayOfWeek firstDayOfWeek);

        
          Calendar cal = new GregorianCalendar();
        CultureInfo myCIruRU = new CultureInfo("cs-CZ", true);



        Calendar myCal = new GregorianCalendar();

        // Sets the DateTimeFormatInfo.Calendar property to a Localized GregorianCalendar.
        // Localized GregorianCalendar is the default calendar for de-DE, en-US, and fr-FR,
        myCIruRU.DateTimeFormat.Calendar = myCal;

            // Creates a DateTime.
            //DateTime myDT = new DateTime(2002, 1, 3, 13, 30, 45);

        // Displays the DateTime.
        //Console.WriteLine("de-DE: {0}", myDT.ToString("F", myCIruRU));                  
              DayOfWeek firstDay = DayOfWeek.Sunday;
        CalendarWeekRule rule;
        rule = CalendarWeekRule.FirstFullWeek;
            //Console.WriteLine( cal.GetWeekOfYear(myDT, rule, firstDay));           


            //var culture = new System.Globalization.CultureInfo("cs-CZ");
             var culture = new System.Globalization.CultureInfo("zh-CN");

            //culture.DateTimeFormat.CalendarWeekRule= CalendarWeekRule.FirstDay;
            DateTime myDT = new DateTime(2002, 1, 3, 13, 30, 45);
             
            Console.WriteLine(culture.DateTimeFormat.CalendarWeekRule.ToString());
            Console.WriteLine("cs-CZ: {0}", culture.UseUserOverride);

            Console.ReadKey();
        }
    }
}
