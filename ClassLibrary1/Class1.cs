using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        void a()
        {
          string argument = " -ExecutionPolicy ByPass & {& \"D:\\TestingIIS\\Testingparallel\\Testingparallel\\Microsoft_Image\\loadjsontemplate0.ps1\" -ResourceGroupName testcloud2" + i + " -LocationName westus -AdPassword " + resourceGroup.AdPassword + " -AdUserName " + resourceGroup.AdUsername + " -SubscriptionId " + resourceGroup.SubscriptionId + "}";
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "powershell.exe";
        psi.Arguments = argument;
        psi.RedirectStandardOutput = true;
        psi.RedirectStandardError = true;
        psi.UseShellExecute = false;
        psi.CreateNoWindow = true;
        Process process = new Process();
        process.StartInfo = psi;
        process.Start();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
        Console.WriteLine(process.StandardError.ReadToEnd());
        }
    
    }
}
