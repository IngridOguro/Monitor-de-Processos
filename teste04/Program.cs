using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
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
                Processos[nomeProcesso][$"{processo}"] = new Dictionary<string, double>();
                Processos[nomeProcesso][$"{processo}"]["memo"] = memory;
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

        // Exibindo o dicionário
        foreach (var entrada in Processos)
        {
            Console.WriteLine($"{entrada.Key}:");
            foreach (var innerEntry in entrada.Value)
            {
                Console.WriteLine($"{{ {innerEntry.Key}: {{ Memory : {innerEntry.Value["memo"]} }} }},");
            }
            Console.WriteLine(",");
        }
    }
}
