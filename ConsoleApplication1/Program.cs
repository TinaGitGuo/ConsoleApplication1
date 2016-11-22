using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process oProcess = new Process();
            //oProcess.StartInfo.FileName = Config.ADOBEREADER + "acrord32.exe";

            //oProcess.StartInfo.Arguments = "/n /t \"" + sPDFOutfile + "\" \"" +
            //     Config.PSPRINTER + "\" \"" + Config.PSPRINTER + "\" \"" + sPostFile + "\"";

            //oProcess.StartInfo.UseShellExecute = false;


            //oProcess.Start();

            Process oProcess = new Process();
            oProcess.StartInfo.FileName =  "acrord32.exe";

            oProcess.StartInfo.Arguments = "/n /t \"" + 1 + "\" \"" +
                 2 + "\" \"" + 3 + "\" \"" + 4 + "\"";

            oProcess.StartInfo.UseShellExecute = false;


            oProcess.Start();
            Console.ReadKey();


                //获得当前程序中所有正在运行的进程
                //Process[] pros = Process.GetProcesses();
                //foreach (var item in pros)
                //{

            //    Console.WriteLine(item);
            //}

            //通过进程打开一些应用程序
            //Process.Start("calc");
            //Process.Start("mspaint");
            //Process.Start("notepad");
            //Process.Start("iexplore", "http://www.baidu.com");

            //通过一个进程打开指定的文件
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Users\Administrator\AppData\Local\Google\Chrome\Application\chrome.exe", "http://www.baidu.com");
            //创建进程对象
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();

            Console.ReadKey();

        }
    }
}
