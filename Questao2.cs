using System.Text.Json;

namespace Desafio.Target.Sistemas
{
    public static class Questao2
    {
        public record Produto(int CodigoProduto, string DescricaoProduto, int Estoque);

        public record Dados(List<Produto> Estoque);

        public record Movimentacao(int Id, string Descricao, int CodigoProduto, int Quantidade, int EstoqueFinal);

        private static readonly JsonSerializerOptions Opcoes = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static void Executar()
        {
            string json = """
                {
                    "estoque": [
                        { "codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150 },
                        { "codigoProduto": 102, "descricaoProduto": "Caderno Universitário", "estoque": 75 },
                        { "codigoProduto": 103, "descricaoProduto": "Borracha Branca", "estoque": 200 },
                        { "codigoProduto": 104, "descricaoProduto": "Lápis Preto HB", "estoque": 320 },
                        { "codigoProduto": 105, "descricaoProduto": "Marcador de Texto Amarelo", "estoque": 90 }]
                }
                """;

            var dados = JsonSerializer.Deserialize<Dados>(json, Opcoes)!;
            var produtos = dados.Estoque;
            var movimentacoes = new List<Movimentacao>();
            int proximoId = 1;

            while (true)
            {
                Console.WriteLine("\nProdutos:");
                foreach (var p in produtos)
                    Console.WriteLine($"{p.CodigoProduto} - {p.DescricaoProduto} (estoque: {p.Estoque})");

                Console.Write("\nCódigo do produto (0 para sair): ");
                int codigo = int.Parse(Console.ReadLine()!);
                if (codigo == 0) break;

                int indice = produtos.FindIndex(p => p.CodigoProduto == codigo);
                if (indice == -1)
                {
                    Console.WriteLine("Produto não encontrado.");
                    continue;
                }

                Console.Write("Tipo (E = Entrada, S = Saída): ");
                string tipo = Console.ReadLine()!.Trim().ToUpper();

                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine()!);

                Console.Write("Descrição da movimentação: ");
                string descricao = Console.ReadLine()!;

                var produto = produtos[indice];
                int novoEstoque;

                if (tipo == "E")
                    novoEstoque = produto.Estoque + quantidade;
                else if (tipo == "S")
                    novoEstoque = produto.Estoque - quantidade;
                else
                {
                    Console.WriteLine("Tipo inválido.");
                    continue;
                }

                if (quantidade <= 0 || novoEstoque < 0)
                {
                    Console.WriteLine("Quantidade inválida ou estoque insuficiente.");
                    continue;
                }

                produtos[indice] = produto with { Estoque = novoEstoque };

                var mov = new Movimentacao(proximoId++, descricao, codigo, quantidade, novoEstoque);
                movimentacoes.Add(mov);

                Console.WriteLine($"\nMovimentação nº {mov.Id} - {mov.Descricao}");
                Console.WriteLine($"Estoque final de {produto.DescricaoProduto}: {mov.EstoqueFinal}");
            }
        }
    }
}
