namespace Comex.Models;

public class Livro : Produto, IIdentificavel
{
    public Livro(string nome) : base(nome)
    {
    }

    public string ISBN { get; set; }
    public int NumeroDePaginas { get; set; }

    public string Identificar()
    {
        return $"Livro: {Nome}, ISBN: {ISBN}";
    }
}
