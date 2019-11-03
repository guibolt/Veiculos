using System;
using System.Collections.Generic;
using System.Text;
using Veiculos.Enums;

namespace Veiculos
{
    public class Veiculo
    {
        public TipoDosVeiculos Tipo { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public double CapacidadeTanque { get; set; }
        public double Tanque { get; set; }
        public double AutonomiaLitro { get; set; }
        public bool Flex { get; set; }
        public string Ano { get; set; }
        public int NivelPneu { get; set; }
        public int IdDoVeiculo { get; set; } = new Random().Next(00000, 99999);
        public double AutonomiaAtual { get; set; }


        public void CadastrarVeiculo()
        {
            Console.WriteLine("\nQual é o tipo do veiculo ? Carro ou Moto\n");
            Tipo = Enum.Parse<TipoDosVeiculos>(Console.ReadLine());
             
            Console.WriteLine($"\nDigite o Fabricante do(a) {Tipo}\n" );
            Fabricante = Console.ReadLine();

            Console.WriteLine($"\nDigite o modelo do do(a) {Tipo}\n");
            Modelo = Console.ReadLine();

            Console.WriteLine($"\nDigite a Capacide total do Tanque do(a) {Tipo}\n");
            CapacidadeTanque = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"\nDigite quantos KM o(a) {Tipo} faz por litro de combustivel\n");
            AutonomiaLitro = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"\n O(a) {Tipo} é flex ?\n");
            Flex = Console.ReadLine().ToUpper() == "SIM" ? true : false;

            Console.WriteLine($"\n Digite o ano de Fabricação do(a) {Tipo}\n");
            Ano = Console.ReadLine();

            Console.WriteLine($"\n O(a) {Tipo} está com quanto de combustivel ?\n");
            Tanque = Convert.ToDouble(Console.ReadLine());
            Operacoes.ValidaTipoDoCombustivel(this);

            Console.WriteLine($"\nVeiculo cadastrado com sucesso! o Id é: {IdDoVeiculo} \n");
        }

        public double Dirigir(bool Clima, double KmAtual)
        {
            Operacoes.DesgastaPneuDeAcordoComAViagem(KmAtual,this);

            AutonomiaAtual = Operacoes.CalculaAutonomiaAtual(Tanque, AutonomiaLitro, NivelPneu, Clima);

            if (AutonomiaAtual == 0)
                return 0;

            Console.WriteLine("Por quantos Km quer dirigir ?");
            var kmAPercorrer = Convert.ToDouble(Console.ReadLine());

            if (kmAPercorrer > AutonomiaAtual)
                return 0;

            var aDescontarTanque = Math.Round(kmAPercorrer / AutonomiaLitro);
            Tanque -= Clima ? aDescontarTanque : Math.Round(aDescontarTanque + aDescontarTanque * 0.1);

            return kmAPercorrer;
        }

        public double Abastecer(double Litros)
        {
            if (Litros > CapacidadeTanque )
                return 0;

            if (Litros <= 0)
                return -1;

            Tanque += Math.Round(Litros);

            Operacoes.ValidaTipoDoCombustivel(this);

            return Tanque;
        }

      
        public override string ToString() => $"\nTipo: {Tipo} Id: {IdDoVeiculo} Fabricante: { Fabricante} Modelo: {Modelo} Capacidade do Tanque: {CapacidadeTanque} " +
            $"Flex: {Flex} Disponibilidade do Tanque {Tanque}\n ";
    
    }
}
