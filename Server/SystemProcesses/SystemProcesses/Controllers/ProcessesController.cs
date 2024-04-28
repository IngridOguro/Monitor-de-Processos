using System;
using System.Diagnostics;
using System.ComponentModel;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using System.Collections.Generic;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessosController : ControllerBase
    {

        private readonly ILogger<ProcessosController> _logger;

        public ProcessosController(ILogger<ProcessosController> logger)
        {
            _logger = logger;
        }

        public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> Processos = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();

        public string nomeProcesso { get; private set; }

        [HttpGet(Name = "GetProcessos")]

        public string Get()
        {
            Process[] allProcesses = Process.GetProcesses();
            
            for (int processo = 0; processo < allProcesses.Length; processo++)
            {
                string nomeProcesso = allProcesses[processo].ProcessName;
                Console.WriteLine(allProcesses[processo]);
                try { 
                    if (!Processos.ContainsKey(nomeProcesso))
                    {
                        Processos[nomeProcesso] = new Dictionary<string, Dictionary<string, double>>();
                    }

                    Processos[nomeProcesso][$"{processo}"] = new Dictionary<string, double>();
                    
                    double cpu = allProcesses[processo].TotalProcessorTime.TotalMinutes;
                    double memory = allProcesses[processo].PrivateMemorySize64 / 1024.0;

                    Processos[nomeProcesso][$"{processo}"]["cpu"] = cpu;
                    Processos[nomeProcesso][$"{processo}"]["memo"] = memory;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Ocorreu uma InvalidOperationException: " + ex.Message);
                }
                ////////////////
                if (OperatingSystem.IsWindows())
                {
                    try
                    {
                        using (PerformanceCounter diskCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", allProcesses[processo].ProcessName))
                        {
                            diskCounter.NextValue();
                            float diskUsage = diskCounter.NextValue() / (1024 * 1024);
                            Processos[nomeProcesso][$"{processo}"]["disc"] = diskUsage;
                        }
                        using (PerformanceCounter networkCounter = new PerformanceCounter("Process", "IO Other Bytes/sec", allProcesses[processo].ProcessName))
                        {
                            networkCounter.NextValue();
                            float networkUsage = networkCounter.NextValue() / (1024 * 1024);
                            Processos[nomeProcesso][$"{processo}"]["network"] = networkUsage;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocorreu uma InvalidOperationException: " + ex.Message);
                    }

                }
            }

            string json = JsonConvert.SerializeObject(Processos, Formatting.Indented);
            return json;

        }
    }
}