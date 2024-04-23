using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Process[] processes = Process.GetProcesses();

        foreach (var process in processes)
        {
            Console.WriteLine("Processo: " + process.ProcessName);

            using (PerformanceCounter diskCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", process.ProcessName))
            {
                diskCounter.NextValue(); 
                System.Threading.Thread.Sleep(10000); 
                float diskUsage = diskCounter.NextValue() / (1024 * 1024); 
                Console.WriteLine("Uso de disco: " + diskUsage + " MB/s");
            }

            using (PerformanceCounter networkCounter = new PerformanceCounter("Process", "IO Other Bytes/sec", process.ProcessName))
            {
                networkCounter.NextValue(); 
                System.Threading.Thread.Sleep(10000); 
                float networkUsage = networkCounter.NextValue() / (1024 * 1024); 
                Console.WriteLine("Uso de rede: " + networkUsage + " MB/s");
            }

            Console.WriteLine(); // Nova linha entre os processos
        }
    }
}
