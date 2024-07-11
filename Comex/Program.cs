using Comex;
using System.Text.Json;

var produtosParaTestes = new List<Produto>
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

var pedidosParaTestes = new List<Pedido>();

string mensagemBoasVindas = "Boas vindas ao COMEX";

void ExibirLogo()
{
    Console.WriteLine(@"
────────────────────────────────────────────────────────────────────────────────────────
─██████████████─██████████████─██████──────────██████─██████████████─████████──████████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██████████████░░██─██░░░░░░░░░░██─██░░░░██──██░░░░██─
─██░░██████████─██░░██████░░██─██░░░░░░░░░░░░░░░░░░██─██░░██████████─████░░██──██░░████─
─██░░██─────────██░░██──██░░██─██░░██████░░██████░░██─██░░██───────────██░░░░██░░░░██───
─██░░██─────────██░░██──██░░██─██░░██──██░░██──██░░██─██░░██████████───████░░░░░░████───
─██░░██─────────██░░██──██░░██─██░░██──██░░██──██░░██─██░░░░░░░░░░██─────██░░░░░░██─────
─██░░██─────────██░░██──██░░██─██░░██──██████──██░░██─██░░██████████───████░░░░░░████───
─██░░██─────────██░░██──██░░██─██░░██──────────██░░██─██░░██───────────██░░░░██░░░░██───
─██░░██████████─██░░██████░░██─██░░██──────────██░░██─██░░██████████─████░░██──██░░████─
─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░██──██░░░░██─
─██████████████─██████████████─██████──────────██████─██████████████─████████──████████─
────────────────────────────────────────────────────────────────────────────────────────");
    Console.WriteLine(mensagemBoasVindas);
}

async Task ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para Criar Produto");
    Console.WriteLine("Digite 2 para Listar Produtos");
    Console.WriteLine("Digite 3 para Consultar API Externa");
    Console.WriteLine("Digite 4 para Ordenar Produtos pelo Nome");
    Console.WriteLine("Digite 5 para Ordenar Produtos pelo Preço");
    Console.WriteLine("Digite 6 para Criar Pedido");
    Console.WriteLine("Digite 7 para Listar Pedidos");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
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

            produtosParaTestes.Add(produto);
            Console.WriteLine($"O Produto {produto.Nome} foi registrado com sucesso!");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Exibindo todos os produtos registrados na nossa aplicação");

            for (int i = 0; i < produtosParaTestes.Count; i++)
            {
                Console.WriteLine($"Produto: {produtosParaTestes[i].Nome}, Preço: {produtosParaTestes[i].PrecoUnitario:F2}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case 3:
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nExibindo Produtos\n");
                    string resposta = await client.GetStringAsync("http://diwserver.vps.webdock.cloud:8765/products/category/Accessories%20%26%20Supplies");

                    var resultado = JsonSerializer.Deserialize<Produto[]>(resposta);

                    foreach (var produtoDaApi in resultado)
                    {
                        Console.WriteLine($"Produto: {produtoDaApi.Nome}, Preço: {produtoDaApi.PrecoUnitario:F2}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao consultar a API: {ex.Message}");
                }
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Exibindo produtos ordenados pelo nome");

            produtosParaTestes.Sort((p1, p2) => p1.Nome.CompareTo(p2.Nome));
            for (int i = 0; i < produtosParaTestes.Count; i++)
            {
                Console.WriteLine($"Produto: {produtosParaTestes[i].Nome}, Preço: {produtosParaTestes[i].PrecoUnitario:F2}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Exibindo produtos ordenados pelo preço");

            produtosParaTestes.Sort((p1, p2) => p1.PrecoUnitario.CompareTo(p2.PrecoUnitario));
            for (int i = 0; i < produtosParaTestes.Count; i++)
            {
                Console.WriteLine($"Produto: {produtosParaTestes[i].Nome}, Preço: {produtosParaTestes[i].PrecoUnitario:F2}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case 6:
            Console.Clear();
            Console.WriteLine("Criação de Pedido");

            Console.Write("Digite o nome do Cliente: ");
            string nomeDoCliente = Console.ReadLine();
            var cliente = new Cliente(nomeDoCliente);

            var pedido = new Pedido(cliente);
            Console.WriteLine($"Pedido criado com sucesso para o cliente {pedido.Cliente.Nome}");

            while (true)
            {
                Console.Write("Deseja adicionar um item ao pedido? (s/n): ");
                string respostaAdicionarItem = Console.ReadLine();
                if (respostaAdicionarItem.ToLower() != "s")
                    break;

                Console.Write("Digite o nome do Produto: ");
                string nomeDoProdutoParaPedido = Console.ReadLine();
                var produtoParaPedido = produtosParaTestes.Find(p => p.Nome == nomeDoProdutoParaPedido);

                if (produtoParaPedido == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                    continue;
                }

                Console.Write("Digite a quantidade: ");
                int quantidadeParaPedido = int.Parse(Console.ReadLine());

                var itemDePedido = new ItemDePedido(produtoParaPedido, quantidadeParaPedido, produtoParaPedido.PrecoUnitario);
                pedido.AdicionarItemAoPedido(itemDePedido);
            }

            pedidosParaTestes.Add(pedido);
            Console.WriteLine($"O Pedido para o cliente {pedido.Cliente.Nome} foi registrado com sucesso!");
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case 7:
            Console.Clear();
            Console.WriteLine("Exibindo todos os pedidos registrados na nossa aplicação");

            for (int i = 0; i < pedidosParaTestes.Count; i++)
            {
                Console.WriteLine(pedidosParaTestes[i].ToString());
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            await ExibirOpcoesDoMenu();
            break;
        case -1:
            Console.Clear();
            Console.WriteLine("Saindo do sistema...");
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opção inválida, tente novamente.");
            await ExibirOpcoesDoMenu();
            break;
    }
}

await ExibirOpcoesDoMenu();
