 
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO.Ports;

//namespace WindowsFormsApplication2
//{
//    class Program
//    {
//        static SerialPort THCPortal = new SerialPort("COM1");
//        static byte[] checkForBytes = new byte[50];
//        static int bytesFromBuffer = 23;

//        static void Main(string[] args)
//        {
//            try
//            {
//                THCPortal.ReadTimeout = 0;
//                THCPortal.Open();
//                if (THCPortal.IsOpen)
//                {
//                    THCPortal.DiscardInBuffer();

//                    /*
//                    THIS NEXT LINE IS VERY INTERESTING !!!!!!!!!!
//                    IT SEEMS IF THERE ARE NO BYTES TO READ THEN THIS COMMAND DOES NOT EXECUTE !!!!!!
//                    I.E. I INITIALISED bytesFromBuffer TO 23 YET THE VALUE REMAINED AT 23 AFTER
//                    THIS COMMAND WAS RUN.
//                    SO I'D SAY THIS COMMAND ONLY COUNTS AND RETURNS THE NUMBER OF BYTES READ IF
//                    THERE WERE AT LEAST ONE BYTE TO READ. IF NOT IT JUST JUMPS TO THE TIMEOUT 
//                    EXCEPTION WHICH MEANS "THERE WERE NO BYTES TO READ" AND THEREFORE THE CATCH
//                    BLOCK SHOULD SET bytesFromBuffer to ZERO !!!!!!!!!! 
//                    */
//                    bytesFromBuffer = THCPortal.Read(checkForBytes, 0, 50);

//                    Console.WriteLine("Bytes read from Read Buffer = " + bytesFromBuffer);
//                }
//            }

//            catch (TimeoutException)
//            {
//                Console.WriteLine("Timeout Exception - therefore there were ZERO bytes in the buffer");
//                bytesFromBuffer = 0;
//            }

//            Console.WriteLine("Successfully moved on after catch block");

//        }
//    }
//}