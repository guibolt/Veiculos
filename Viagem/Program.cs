using System;

namespace Veiculos
{
    class Program
    {
        static void Main()
        {
            var start = Operacoes.RecuperarArquivo();
           start = start ?? new View();
            start.Menu();
        }
    }
}
