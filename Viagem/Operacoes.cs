using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Veiculos
{
    public static class Operacoes
    {
        public static string arquivoDb = AppDomain.CurrentDomain.BaseDirectory + "Carro.json";
        public static double CalculaAutonomiaAtual(double tanqueDisponivel, double kmPorLitro, int niveldoPneu, bool Clima)
        {
            var capacidadeTotal = Math.Round(tanqueDisponivel * kmPorLitro);

            capacidadeTotal = Clima ? capacidadeTotal : capacidadeTotal - capacidadeTotal * 0.1;

            if (niveldoPneu == 2)
                return capacidadeTotal - capacidadeTotal * 0.0915;

            if (niveldoPneu == 3)
                return capacidadeTotal - capacidadeTotal * 0.0715;

            return Math.Round(capacidadeTotal);
        }

        public static void DesgastaPneuDeAcordoComAViagem(double kmAtual, Veiculo veiculo)
        {
            var StatusViagem = kmAtual * 0.1;

            if (StatusViagem >= 50)
                veiculo.NivelPneu = 2;

            if (StatusViagem >= 80)
                veiculo.NivelPneu = 3;
        }
        public static void ValidaTipoDoCombustivel(Veiculo veiculo)
        {
            Console.WriteLine("O veiculo será/está abastecido com Alcool ou Gasolina");
            var tipo = Console.ReadLine();

            if (tipo.ToUpper() == "ALCOOL")
                veiculo.AutonomiaLitro -= veiculo.AutonomiaLitro * 0.2;   
        }
      
        public static View RecuperarArquivo()
        {
            try { return JsonConvert.DeserializeObject<View>(File.ReadAllText(arquivoDb)); }
            catch (Exception) { return default; }
        }
        public static void SalvarArquivo(View Arquivo)
        {
            try { File.WriteAllText(arquivoDb, JsonConvert.SerializeObject(Arquivo)); }
            catch (JsonException ex)

            { throw ex; }
        }
    }
}
