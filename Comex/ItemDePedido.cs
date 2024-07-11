namespace Comex;
public class ItemDePedido
{
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public double PrecoPorUnidade { get; private set; }
    public double Subtotal { get; private set; }

    public ItemDePedido(Produto produto, int quantidade, double precoPorUnidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

        Produto = produto ?? throw new ArgumentNullException(nameof(produto));
        Quantidade = quantidade;
        PrecoPorUnidade = precoPorUnidade;
        Subtotal = quantidade * precoPorUnidade;
    }

    public override string ToString()
    {
        return $"Produto: {Produto.Nome}, Quantidade: {Quantidade}, Preço por Unidade: {PrecoPorUnidade:F2}, Subtotal: {Subtotal:F2}";
    }
}
