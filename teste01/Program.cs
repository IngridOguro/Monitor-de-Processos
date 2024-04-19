using System;
using System.Diagnostics;
namespace teste01;
public class Program {
    public static void Main(){
         try
        {
            // Obtém todos os processos atuais em execução no sistema
            Process[] processos = Process.GetProcesses();

            Console.WriteLine("Lista de Processos:");

            foreach (Process processo in processos)
            {
                // Exibe o nome e o ID de cada processo
                Console.WriteLine($"Nome: {processo.ProcessName} | ID: {processo.Id}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar os processos: " + ex.Message);
        }
    }
}
