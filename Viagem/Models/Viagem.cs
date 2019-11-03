using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Veiculos.Models
{
    public class Viagem
    {
        public Veiculo Veiculo { get; set; }
        public bool Clima { get; set; }
        public double DistanciaTotal { get; set; }
        public double KmAtual { get; private set; }
        public DateTime DataDaViagem { get; set; } = DateTime.Now;

        public Viagem(Veiculo veiculo, bool clima, double distancia)
        {
            Clima = clima;
            DistanciaTotal = distancia;
            Veiculo = veiculo;
        }

        public void RealizaViagem()

        {
            while (DistanciaTotal > KmAtual)
            {
                Console.WriteLine($"\nDigite 1 para Dirigir, 2 para Abastecer e 3 para ver autonomia atual do(a) {Veiculo.Tipo} \n e  4 para ver quanto falta para a viagem acabar  5 para desistir da viagem\n");
                var decisao = Console.ReadLine();
                switch (decisao)
                {
                    case "1":
                        Console.Clear();
                        var distanciaPercorrida = Veiculo.Dirigir(Clima, KmAtual);

                        if (distanciaPercorrida == 0)
                        {
                            Console.WriteLine("\nNão há combustivel disponivel, favor abastecer!\n");
                            break;
                        }

                        if (distanciaPercorrida > DistanciaTotal)
                            distanciaPercorrida = DistanciaTotal;

                        KmAtual += distanciaPercorrida;

                        Console.WriteLine($"\nSeu carro avançou {distanciaPercorrida} Km\n");

                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nQuantos litros deseja abastecer ?\n");

                        var abastecimento = Veiculo.Abastecer(Convert.ToDouble(Console.ReadLine()));

                        if (abastecimento == 0)
                            Console.WriteLine($"\nNao foi possivel abastecer, quantidade de litros escolhida superior a capacidade do tanque: {Veiculo.CapacidadeTanque}, abasteça novamente!\n");

                        if (abastecimento == -1)
                            Console.WriteLine($"Não é possivel abastecer o(a) {Veiculo.Tipo} com quantidades inferiores ou iguais a 0");

                        Console.WriteLine($" Foram Abastecidos {abastecimento} Litros!");

                        break;
                    case "3":
                        Console.Clear();
                        Operacoes.DesgastaPneuDeAcordoComAViagem(KmAtual, Veiculo);
                        Console.WriteLine($"Autonomia do(a) {Veiculo.Tipo} atual: {Operacoes.CalculaAutonomiaAtual(Veiculo.Tanque, Veiculo.AutonomiaLitro, Veiculo.NivelPneu, Clima)}");
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine($"Faltam {DistanciaTotal - KmAtual}Km para finalizar a viagem");
                        break;


                    case "5":
                        Console.Clear();
                        Console.WriteLine("Aperte enter para voltar ao menu");
                        Console.ReadLine();
                        new View().Menu();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }
            }

            Console.WriteLine("Sua viagem acabou!");
            Console.WriteLine("Enter para voltar ao menu principal!");
            Console.ReadLine();
        }

        public override string ToString() => $"Data da Viagem: {DataDaViagem} Distacia Percorrida: {DistanciaTotal}KM Veiculo utilizado: {Veiculo.Fabricante}  {Veiculo.Modelo} ";

    }
}
