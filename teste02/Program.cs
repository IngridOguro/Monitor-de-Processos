using System;
using System.Diagnostics;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Get information about the current process
            Process currentProcess = Process.GetCurrentProcess();

            // Print out some information about the process
            Console.WriteLine("Process Name: " + currentProcess.ProcessName);
            Console.WriteLine("Memory Usage: " + currentProcess.PrivateMemorySize64 / 1024 + " KB");
            Console.WriteLine("CPU Usage: " + currentProcess.TotalProcessorTime);

            // You can also get information about other processes running on the system
            // For example, to get all processes running on the system:
            Process[] allProcesses = Process.GetProcesses();

            foreach (Process proc in allProcesses)
            {
                try
                {
                    Console.WriteLine("Process Name: " + proc.ProcessName);
                    Console.WriteLine("Memory Usage: " + proc.PrivateMemorySize64 / 1024 + " KB");
                    Console.WriteLine("CPU Usage: " + proc.TotalProcessorTime);
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine($"Error accessing process: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
