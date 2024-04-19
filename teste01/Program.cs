using System;
using System.Diagnostics;
namespace teste01;
public class Program {
    public static void Main(){
          // Nome do processo que você deseja monitorar
        string nomeProcesso = "notepad";

        // Busca o processo pelo nome
        Process[] processos = Process.GetProcessesByName(nomeProcesso);

        if (processos.Length > 0)
        {
            // Pega o primeiro processo encontrado (você pode iterar por todos se houver mais de um)
            Process processo = processos[0];

            try
            {
                // Obtém o consumo de memória do processo
                long memoriaConsumida = processo.WorkingSet64;

                Console.WriteLine($"Consumo de memória do processo '{nomeProcesso}': {memoriaConsumida} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar o consumo de memória do processo: " + ex.Message);
            }
            finally
            {
                // Certifique-se de liberar os recursos do processo
                processo.Dispose();
            }
        }
        else
        {
            Console.WriteLine("Nenhum processo encontrado com o nome especificado.");
        }
    }
}
