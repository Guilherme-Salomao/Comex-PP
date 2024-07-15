// See https://aka.ms/new-console-template for more information
using Comex.Data;
using Comex.Menus;
using Comex.Modelos;
using System.Text.Json;

MenuCriarProduto menuCriarProduto = new MenuCriarProduto();
MenuListarProdutos menuListarProdutos = new MenuListarProdutos();
using HttpClient client = new HttpClient();
MenuConsultarApiExterna menuConsultarApiExterna = new MenuConsultarApiExterna(client);
MenuOrdenarProdutos ordenarProdutos = new MenuOrdenarProdutos();
MenuCriarPedido menuCriarPedido = new MenuCriarPedido();
MenuListarPedidos menuListarPedidos = new MenuListarPedidos();


ProdutoDAL produtoDAL = new ProdutoDAL();

ComexDbContext comexDbContext = new ComexDbContext();
ProdutoRepository produtoRepository = new ProdutoRepository(comexDbContext);

var listaDeProdutos = new List<Produto>
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

var listaDePedidos = new List<Pedido>();

string mensagemDeBoasVindas = "Boas vindas ao COMEX";

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
    Console.WriteLine(mensagemDeBoasVindas);
}

async Task ExibirOpcoesDeMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 Criar Produto");
    Console.WriteLine("Digite 2 Listar Produtos");
    Console.WriteLine("Digite 3 Consultar API Externa");
    Console.WriteLine("Digite 4 Ordenar Produtos pelo Título");
    Console.WriteLine("Digite 5 Ordenar Produtos pelo Preço");
    Console.WriteLine("Digite 6 Criar Pedido");
    Console.WriteLine("Digite 7 Listar Pedidos");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            menuCriarProduto.CriarProduto(produtoRepository);
            await ExibirOpcoesDeMenu();
            break;
        case 2:
            menuListarProdutos.ListarProdutos(produtoRepository);
            await ExibirOpcoesDeMenu();
            break;
        case 3:
            await menuConsultarApiExterna.ConsultarApiExterna();
            await ExibirOpcoesDeMenu();
            break;
        case 4:
            ordenarProdutos.OrdenarProdutosPeloTitulo(produtoRepository);
            await ExibirOpcoesDeMenu();
            break;
        case 5:
            ordenarProdutos.OrdernarProdutosPeloPreço(produtoRepository);
            await ExibirOpcoesDeMenu();
            break;
        case 6:
            menuCriarPedido.CriarPedido(listaDeProdutos, listaDePedidos);
            await ExibirOpcoesDeMenu();
            break;
        case 7:
            menuListarPedidos.ListarPedidos(listaDePedidos);
            await ExibirOpcoesDeMenu();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

await ExibirOpcoesDeMenu();






