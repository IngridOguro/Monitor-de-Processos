using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;
public class Processes

{
     public static Dictionary<string, Dictionary<string, Dictionary<string, double>>> Processos = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();
    public static string ListarProcessos()
    {

        Processos["nomeProcesso"] = new Dictionary<string, Dictionary<string, double>>();
        Processos["nomeProcesso"]["processo"] = new Dictionary<string, double>();
        Processos["nomeProcesso"]["processo"]["propriedade"] = 2.343;
        string Processos_json = JsonConvert.SerializeObject(Processos, Formatting.Indented);
        return Processos_json;
    }
}
