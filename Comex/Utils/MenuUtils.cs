using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Comex.Models;

namespace Comex.Utils
{
    public static class MenuUtils
    {
        private static readonly List<Produto> lstpt = new List<Produto>
        {
            new Produto("Notebook")
            {
                Descricao = "Notebook Dell Inspiron",
                PrecoUnitario = 3500.00,
                Quantidade = 10
            },
            new Produto("Smartphone")
            {
                Descricao = "Smartphone Samsung Galaxy",
                PrecoUnitario = 1200.00,
                Quantidade = 25
            },
            new Produto("Monitor")
            {
                Descricao = "Monitor LG Ultrawide",
                PrecoUnitario = 800.00,
                Quantidade = 15
            },
            new Produto("Teclado")
            {
                Descricao = "Teclado Mecânico RGB",
                PrecoUnitario = 250.00,
                Quantidade = 50
            }
        };

        private static readonly List<Pedido> ltspd = new List<Pedido>();

        public static async Task ShowMenu()
        {
            bool sair = false;

            do
            {
                ShowOptions();
                string opcaoEscolhida = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        await CriarProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    case "3":
                        await ConsultarAPIExterna();
                        break;
                    case "4":
                        OrdenarProdutosPeloTitulo();
                        break;
                    case "5":
                        OrdenarProdutosPeloPreco();
                        break;
                    case "6":
                        await CriarPedido();
                        break;
                    case "7":
                        ListarPedidos();
                        break;
                    case "-1":
                        Console.WriteLine("Tchau tchau :)");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine();
            } while (!sair);
        }

        private static void ShowOptions()
        {
            Console.WriteLine("Digite 1 para Criar Produto");
            Console.WriteLine("Digite 2 para Listar Produtos");
            Console.WriteLine("Digite 3 para Consultar API Externa");
            Console.WriteLine("Digite 4 para Ordenar Produtos pelo Título");
            Console.WriteLine("Digite 5 para Ordenar Produtos pelo Preço");
            Console.WriteLine("Digite 6 para Criar Pedido");
            Console.WriteLine("Digite 7 para Listar Pedidos");
            Console.WriteLine("Digite -1 para Sair");
            Console.Write("\nDigite a sua opção: ");
        }

        private static async Task CriarProduto()
        {
            Console.Clear();
            Console.WriteLine("Registro de Produto");

            Console.Write("Digite o nome do Produto: ");
            string nomeDoProduto = Console.ReadLine();
            var produto = new Produto(nomeDoProduto);

            Console.Write("Digite a descrição do Produto: ");
            string descricaoDoProduto = Console.ReadLine();
            produto.Descricao = descricaoDoProduto;

            Console.Write("Digite o preço do Produto: ");
            string precoDoProduto = Console.ReadLine();
            produto.PrecoUnitario = double.Parse(precoDoProduto);

            Console.Write("Digite a quantidade do Produto: ");
            string quantidadeDoProduto = Console.ReadLine();
            produto.Quantidade = int.Parse(quantidadeDoProduto);

            lstpt.Add(produto);
            Console.WriteLine($"O Produto {produto.Nome} foi registrado com sucesso!");
            await Task.Delay(2000); // Simula um pequeno atraso para visualizar a mensagem
            Console.Clear();
        }

        private static void ListarProdutos()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Produtos\n");

            foreach (var produto in lstpt)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.PrecoUnitario:F2}, Quantidade: {produto.Quantidade}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

        private static async Task ConsultarAPIExterna()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Consultando API Externa\n");

                    string resposta = await client.GetStringAsync("http://fakestoreapi.com/products");
                    var produtos = JsonSerializer.Deserialize<List<Produto>>(resposta);

                    foreach (var produto in produtos)
                    {
                        Console.WriteLine($"Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.PrecoUnitario}");
                    }

                    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao consultar API: {ex.Message}");
                }
            }
        }

        private static void OrdenarProdutosPeloTitulo()
        {
            var produtosOrdenados = lstpt.OrderBy(p => p.Nome).ToList();
            Console.Clear();
            Console.WriteLine("Produtos ordenados pelo título:\n");

            foreach (var produto in produtosOrdenados)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.PrecoUnitario:F2}, Quantidade: {produto.Quantidade}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

        private static void OrdenarProdutosPeloPreco()
        {
            var produtosOrdenados = lstpt.OrderBy(p => p.PrecoUnitario).ToList();
            Console.Clear();
            Console.WriteLine("Produtos ordenados pelo preço:\n");

            foreach (var produto in produtosOrdenados)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Descrição: {produto.Descricao}, Preço: {produto.PrecoUnitario:F2}, Quantidade: {produto.Quantidade}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

        private static async Task CriarPedido()
        {
            Console.Clear();
            Console.WriteLine("Criando Pedido\n");

            Console.Write("Digite o nome do Cliente: ");
            string nomeCliente = Console.ReadLine();
            var cliente = new Cliente(nomeCliente); 

            var pedido = new Pedido(cliente);

            ListarProdutos();

            Console.Write("Digite o número do Produto que deseja adicionar ao pedido (ou 0 para finalizar): ");
            int numeroProduto = int.Parse(Console.ReadLine());

            while (numeroProduto != 0)
            {
                var produtoEscolhido = lstpt[numeroProduto - 1];

                Console.Write("Digite a quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());

                var itemPedido = new ItemDePedido(produtoEscolhido, quantidade, produtoEscolhido.PrecoUnitario);
                pedido.AdicionarItemAoPedido(itemPedido);

                Console.WriteLine($"Produto {produtoEscolhido.Nome} adicionado ao pedido com {quantidade} unidades.\n");

                Console.Write("Digite o número do Produto que deseja adicionar ao pedido (ou 0 para finalizar): ");
                numeroProduto = int.Parse(Console.ReadLine());
            }

            ltspd.Add(pedido);
            Console.WriteLine($"Pedido criado com sucesso para o cliente {cliente.Nome}!");
            await Task.Delay(2000);
            Console.Clear();
        }

        private static void ListarPedidos()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Pedidos\n");

            foreach (var pedido in ltspd)
            {
                Console.WriteLine($"Cliente: {pedido.Cliente.Nome}, Data do Pedido: {pedido.DataDoPedido}, Valor Total: {pedido.ValorTotal:F2}");
                Console.WriteLine("Itens do Pedido:");

                foreach (var item in pedido.ItensDoPedido)
                {
                    Console.WriteLine($"  Produto: {item.Produto.Nome}, Quantidade: {item.Quantidade}, Preço Unitário: {item.PrecoPorUnidade:F2}, Subtotal: {item.Subtotal:F2}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
