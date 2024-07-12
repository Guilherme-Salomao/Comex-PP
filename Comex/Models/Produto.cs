using FluentResults;

namespace Comex.Models;

public class Produto
{
    public string Nome { get; }
    public string Descricao { get; set; }
    public double PrecoUnitario { get; set; }
    public int Quantidade { get; set; }

    public Result Resultado { get; private set; }

    public Produto(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            Resultado = Result.Fail("Nome do produto não pode ser vazio.");
            return;
        }

        Nome = nome;
        Resultado = Result.Ok();
    }
}
