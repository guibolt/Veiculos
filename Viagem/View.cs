using System;
using System.Collections.Generic;
using System.Linq;
using Veiculos.Models;

namespace Veiculos
{
    public  class View
    {
        public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
        public List<Viagem> Viagens { get; set; } = new List<Viagem>();
        public void Menu()
        {
            Console.Clear();
            bool menu = true;

            while (menu)
            {
                Console.WriteLine("\nDigite 1 para Cadastrar Veiculos, 2 para ver Veiculo, 3 para viajar e 4 para sair\n");
                var decisao = Console.ReadLine();

                switch (decisao)
                {
                    case "1":
                        var novoVeiculo = new Veiculo();
                        novoVeiculo.CadastrarVeiculo();
                        Veiculos.Add(novoVeiculo);
                        Operacoes.SalvarArquivo(this);
                        break;

                    case "2":
                        Console.WriteLine("\nVeiculos registrados:\n");
                        Veiculos.ForEach(v => Console.WriteLine(v));
                        break;
                    case "3":
                        Console.WriteLine("\nSeja bem vindo(a)\n");
                        Console.WriteLine("\nO clima está bom ?\n");
                        
                        var Clima = Console.ReadLine().ToUpper() == "SIM" ? true : false;

                        Console.WriteLine("\nPor quantos km quer viajar ?\n");
                        var Distancia = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("\nVeiculos registrados:\n");
                        Veiculos.ForEach(v => Console.WriteLine(v));

                        Console.WriteLine("\nEscolha um veiculo por Id para viajar!\n");
                        var id = Convert.ToInt32(Console.ReadLine());

                        var Viagem = new Viagem(Veiculos.FirstOrDefault(c =>c.IdDoVeiculo == id), Clima,Distancia);
                        Viagem.RealizaViagem();
                        Viagens.Add(Viagem);
                        Operacoes.SalvarArquivo(this);
                        break;
                    case "4":
                        Console.WriteLine("Viagens registradas");
                        Veiculos.ForEach(v => Console.WriteLine(v));
                        break;

                    case "5":
                        menu = false;
                        break;
                      
                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }
            }
        }
    }
}
