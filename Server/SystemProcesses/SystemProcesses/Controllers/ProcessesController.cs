using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Formatting = Newtonsoft.Json.Formatting;




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

        //public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> Processos = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();
        
        ///LISTA DE DICIONARIOS
        public static List<Dictionary<string, string>> listaDeDicionarios = new List<Dictionary<string, string>>();
        public string nomeProcesso { get; private set; }

        [HttpGet(Name = "GetProcessos")]

        public string Get()
        {
            //TODOS OS PROCESSOS
            Process[] allProcesses = Process.GetProcesses();
            
            for (int processo = 0; processo < allProcesses.Length; processo++)
            {
                string nomeProcesso = allProcesses[processo].ProcessName;

                // Cria um novo dicionário para cada iteração
                Dictionary<string, string> novoDicionario = new Dictionary<string, string>();

                try
                { 
                    double cpu = allProcesses[processo].TotalProcessorTime.TotalMinutes;
                    double memory = allProcesses[processo].PrivateMemorySize64 / 1024.0;

                    // Adiciona pares de informações ao dicionário
                    novoDicionario.Add("nome", $"{nomeProcesso}");
                    novoDicionario.Add("cpu", $"{cpu}");
                    novoDicionario.Add("memory", $"{memory}");

                    if (OperatingSystem.IsWindows()) //previne erro 
                    {
                        using (PerformanceCounter diskCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", allProcesses[processo].ProcessName))
                        {
                            diskCounter.NextValue();
                            float diskUsage = diskCounter.NextValue() / (1024 * 1024);
                            novoDicionario.Add("disk", $"{diskUsage}");
                        }
                        using (PerformanceCounter networkCounter = new PerformanceCounter("Process", "IO Other Bytes/sec", allProcesses[processo].ProcessName))
                        {
                            networkCounter.NextValue();
                            float networkUsage = networkCounter.NextValue() / (1024 * 1024);
                            novoDicionario.Add("net", $"{networkUsage}");
                        }
                        //ADD TO LIST
                        listaDeDicionarios.Add(novoDicionario);
                    }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocorreu uma InvalidOperationException: " + ex.Message);
                    }
                
            }

            string json = JsonConvert.SerializeObject(listaDeDicionarios, Formatting.Indented);
            return json;

        }
    }
}