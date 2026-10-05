# Desafio Técnico · Target Sistemas

Resolução do desafio técnico do processo seletivo para **Desenvolvedor(a) de Sistemas Jr.** na Target Sistemas.

O projeto é uma aplicação de console em **C# / .NET 10** com as três questões propostas, cada uma em sua própria classe.

## Tecnologias

- C# / .NET 10 (Console App)
- `System.Text.Json` para leitura dos dados em JSON
- `record` para modelar os dados de forma imutável
- `decimal` para valores monetários, evitando erros de arredondamento

## Como executar

**Pelo Visual Studio:** abra a solução e pressione `F5`.

**Pelo terminal:**

```bash
git clone <url-do-repositorio>
cd desafio-target-sistemas
dotnet run
```

Cada questão tem um método `Executar()`, chamado a partir do `Program.cs`:

```csharp
Questao1.Executar();
Questao2.Executar();
Questao3.Executar();
```

## Estrutura

```
Desafio.Target.Sistemas/
├── Program.cs
├── Questao1.cs   # Comissão por vendedor
├── Questao2.cs   # Movimentação de estoque
└── Questao3.cs   # Juros por atraso
```

## Questões

### 1. Cálculo de comissão por vendedor

A partir de uma lista de vendas em JSON, calcula o total de comissão de cada vendedor.

| Valor da venda | Comissão |
|---|---|
| Abaixo de R$ 100,00 | Sem comissão |
| De R$ 100,00 a R$ 499,99 | 1% |
| A partir de R$ 500,00 | 5% |

**Saída:**

```
João Silva: R$ 495,68
Maria Souza: R$ 465,95
Carlos Oliveira: R$ 379,37
Ana Lima: R$ 404,98
```

### 2. Movimentação de estoque

A partir dos produtos em JSON, permite lançar movimentações de **entrada** ou **saída** de mercadoria.

- Cada movimentação recebe um **número identificador único**, sequencial.
- Cada movimentação tem uma **descrição** informada pelo usuário.
- Ao final, o programa exibe a **quantidade final em estoque** do produto movimentado.
- São recusados: produto inexistente, tipo inválido, quantidade menor ou igual a zero e saída maior que o estoque disponível.

**Exemplo:**

```
Código do produto (0 para sair): 101
Tipo (E = Entrada, S = Saída): E
Quantidade: 50
Descrição da movimentação: Compra do fornecedor

Movimentação nº 1 - Compra do fornecedor
Estoque final de Caneta Azul: 200
```

### 3. Cálculo de juros por atraso

A partir de um valor e de uma data de vencimento, calcula os juros até a data de hoje, com multa de **2,5% ao dia**.

```
juros = valor × 0,025 × dias de atraso
```

Se a data de vencimento ainda não passou, os juros são zero. O valor deve ser digitado no formato brasileiro (ex.: `1000,50`) e a data como `dd/MM/aaaa`.

**Exemplo** (valor de R$ 1.000,00 com 5 dias de atraso):

```
Dias em atraso: 5
Juros: R$ 125,00
Valor total: R$ 1.125,00
```
