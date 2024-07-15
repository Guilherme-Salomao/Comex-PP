namespace Comex.Modelos;

public class Livro : Produto, IIdentificavel
{
    public Livro(string nome) : base(nome)
    {
    }

    public string Isbn { get; set; }
    public int TotalDePaginas { get; set; }

    public string Identificar()
    {
        return $"Cliente: {Nome}, ISBN: {Isbn}";
    }
}
