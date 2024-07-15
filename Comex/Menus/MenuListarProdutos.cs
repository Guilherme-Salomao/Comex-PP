using Comex.Data;
using Comex.Modelos;
using Comex.Utils;

namespace Comex.Menus
{
    public class MenuListarProdutos
    {
        public void ListarProdutos(ProdutoRepository produtoRepository)
        {
            Console.Clear();
            var listaDeProdutos = produtoRepository.Listar().ToList();
            Console.WriteLine("Exibindo todos os produtos registradoss na nossa aplicação");
            for (int i = 0; i < listaDeProdutos.Count; i++)
            {
                Console.WriteLine($"Produto: {listaDeProdutos[i].Nome}, Preço: {listaDeProdutos[i].PrecoUnitario:F2}");
            }
            ConsoleUtils.PausaELimpaATela();
        }
    }
}
