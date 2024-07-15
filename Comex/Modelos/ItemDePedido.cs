namespace Comex.Modelos;

public class ItemDePedido
{
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public double PrecoUnitario { get; private set; }
    public double Subtotal { get; private set; }

    public ItemDePedido(Produto produto, int quantidade, double precoUnitario)
    {
        Produto = produto ?? throw new ArgumentNullException(nameof(produto));
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        Subtotal = quantidade * precoUnitario;
    }

    public override string ToString()
    {
        return $"Produto: {Produto.Nome}, Quantidade: {Quantidade}, Preço Unitário: {PrecoUnitario:F2}, Subtotal: {Subtotal:F2}";
    }
}
