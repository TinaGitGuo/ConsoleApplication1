using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
 

class PlatformInvokeTest
{
  

    
}
namespace ConsoleApplication11
{
    class Program
    {
        private static readonly DirectoryInfo ApplicationSupportDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        // private static readonly DirectoryInfo ApplicationSupportDirectory = new DirectoryInfo(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Apple Inc.\Apple Application Support", "InstallDir", Environment.CurrentDirectory).ToString());
        private const string DLLPath = "iTunesMobileDevice.dll";
        //        private static readonly FileInfo iTunesMobileDeviceFile = new FileInfo(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Apple Inc.\Apple Mobile Device Support\Shared", "iTunesMobileDeviceDLL", "iTunesMobileDevice.dll").ToString());
        private static readonly FileInfo iTunesMobileDeviceFile = new FileInfo(Environment.CurrentDirectory + "\\iTunesMobileDevice.dll");

 
        // Use DllImport to import the Win32 MessageBox function.
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

         
        
  
    [DllImport("iTunesMobileDevice.dll")]
        public static extern int puts(string c);
        [DllImport("iTunesMobileDevice.dll")]
        internal static extern int _flushall();
        static void Main(string[] args)
        {

          
            //MessageBox(new IntPtr(0), "Hello World!", "Hello Dialog", 0);

            string directoryName = iTunesMobileDeviceFile.DirectoryName;
            if (!iTunesMobileDeviceFile.Exists)
            {
                directoryName = Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles) + @"\Apple\Mobile Device Support\bin";
            }
            Environment.SetEnvironmentVariable("Path", string.Join(";", new string[] { Environment.GetEnvironmentVariable("Path"), directoryName, ApplicationSupportDirectory.FullName }));


            puts("Test");
            //_flushall();

            //string filePath = @"F:\iTunesMobileDevice.dll";
            //try
            //{
            //    Assembly assem = Assembly.LoadFile(filePath);
            //}
            //catch (BadImageFormatException e)
            //{
            //    Console.WriteLine(e.Message);
            //    //Console.WriteLine("Unable to load {0}.", filePath);
            //    //Console.WriteLine(e.Message.Substring(0,
            //    //                  e.Message.IndexOf(".") + 1));
            //}
            Console.WriteLine("///");
            Console.ReadKey();
        }
     
    }
    
}
