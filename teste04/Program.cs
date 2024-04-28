using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Processos;
    public class Program
    {
        // Criando um dicionário vazio
        public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> Processos = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();

        static void Main(string[] args)
        {
            // Todos os processos
            Process[] allProcesses = Process.GetProcesses();

            for (int processo = 0; processo < allProcesses.Length; processo++)
            {
                string nomeProcesso = allProcesses[processo].ProcessName;

                if (Processos.ContainsKey(nomeProcesso))
                {
                    
                    // Se a chave já existe, incrementa o valor da chave existente
                    double memory = allProcesses[processo].PrivateMemorySize64 / 1024.0;
                    double cpu = allProcesses[processo].TotalProcessorTime.TotalMinutes;
                    Processos[nomeProcesso][$"{processo}"] = new Dictionary<string, double>();
                    Processos[nomeProcesso][$"{processo}"]["memo"] = memory;
                    Processos[nomeProcesso][$"{processo}"]["cpu"] = cpu;
                    
                    if (OperatingSystem.IsWindows())
                    {
                        try{
                            using (PerformanceCounter diskCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", allProcesses[processo].ProcessName))
                        {
                            diskCounter.NextValue(); 
                            System.Threading.Thread.Sleep(50); 
                            float diskUsage = diskCounter.NextValue() / (1024 * 1024); 
                            Processos[nomeProcesso][$"{processo}"]["disc"] = diskUsage;
                            //Console.WriteLine($"{nomeProcesso} disco: " + diskUsage + " MB/s");
                        }
                            using (PerformanceCounter networkCounter = new PerformanceCounter("Process", "IO Other Bytes/sec", allProcesses[processo].ProcessName))
                        {
                            networkCounter.NextValue(); 
                            System.Threading.Thread.Sleep(1000); 
                            float networkUsage = networkCounter.NextValue() / (1024 * 1024); 
                            Processos[nomeProcesso][$"{processo}"]["network"] = networkUsage;
                        }
                        }
                        catch (InvalidOperationException ex)
                            {
                                // Lidar com a exceção aqui
                                Console.WriteLine("Ocorreu uma InvalidOperationException: " + ex.Message);
                            }

                    }
                }
                else
                {
                    // Se a chave não existe, adiciona a chave ao dicionário e define o valor como um novo dicionário
                    Processos[nomeProcesso] = new Dictionary<string, Dictionary<string, double>>();
                    double memory = allProcesses[processo].PrivateMemorySize64 / 1024.0;
                    Processos[nomeProcesso][$"{processo}"] = new Dictionary<string, double>();
                    Processos[nomeProcesso][$"{processo}"]["memo"] = memory;
                }
            }

            // Dicionario para json
            string json = JsonConvert.SerializeObject(Processos, Formatting.Indented);
            Console.WriteLine(json);

        }
    }
