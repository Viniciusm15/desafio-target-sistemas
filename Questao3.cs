using System.Globalization;

namespace Desafio.Target.Sistemas
{
    public static class Questao3
    {
        private const decimal TaxaDiaria = 0.025m;

        public static void Executar()
        {
            var culturaBr = new CultureInfo("pt-BR");

            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine()!, culturaBr);

            Console.Write("Data de vencimento (dd/MM/aaaa): ");
            DateTime vencimento = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", culturaBr);

            int diasAtraso = (DateTime.Today - vencimento.Date).Days;
            if (diasAtraso < 0) diasAtraso = 0;

            decimal juros = valor * TaxaDiaria * diasAtraso;
            decimal total = valor + juros;

            Console.WriteLine($"\nDias em atraso: {diasAtraso}");
            Console.WriteLine($"Juros: {juros.ToString("C", culturaBr)}");
            Console.WriteLine($"Valor total: {total.ToString("C", culturaBr)}");
        }
    }
}
